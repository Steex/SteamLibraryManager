using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace SteamLibraryManager
{
	public delegate void SteamDataChangedEventHandler(SteamData data);


	public class SteamData
	{
		public delegate void ProgressChangedEventHandler(int percent);

		public event SteamDataChangedEventHandler ChangesDiscarded;
		public event SteamAppChangedEventHandler AppTargetLibraryChanged;
		public event SteamAppChangedEventHandler AppMoved;


		private string installDir;

		public List<SteamLibrary> Libraries { get; private set; }
		public List<SteamApp> Apps{ get; private set; }
		public bool HasPendingChanges
		{
			get
			{
				return Apps.Any(app => app.OriginalLibrary != app.TargetLibrary);
			}
		}


		public SteamData(string installDir, ProgressChangedEventHandler onLoadProgerss = null)
		{
			this.installDir = installDir;

			// Init the main library.
			Libraries = new List<SteamLibrary>();
			Libraries.Add(new SteamLibrary(installDir));

			// Init additional libraries.
			try
			{
				SteamKeyValue libraryConfig = SteamKeyValue.LoadFromFile(Path.Combine(installDir, "steamapps\\libraryfolders.vdf"));

				for (int i = 1; ; ++i)
				{
					SteamKeyValue libraryData = libraryConfig[i.ToString()];
					if (libraryData != SteamKeyValue.Invalid)
					{
						Libraries.Add(new SteamLibrary(libraryData.Value));
					}
					else
					{
						break;
					}
				}
			}
			catch
			{
				// TODO: Process exception.
			}

			// Read applications information.
			int appCount = Libraries.Aggregate(0, (count, lib) => count + Directory.GetFiles(lib.Path, "appmanifest_*.acf").Count());
			int appLoaded = 0;

			Apps = new List<SteamApp>();
			if (onLoadProgerss != null)
			{
				onLoadProgerss(0);
			}

			foreach (SteamLibrary library in Libraries)
			{
				foreach (string manifestPath in Directory.GetFiles(library.Path, "appmanifest_*.acf"))
				{
					SteamApp app = new SteamApp(library, System.IO.Path.GetFileName(manifestPath));
					app.TargetLibraryChanged += a => { if (AppTargetLibraryChanged != null) AppTargetLibraryChanged(app); };
					Apps.Add(app);

					appLoaded += 1;
					if (onLoadProgerss != null)
					{
						onLoadProgerss((int)((float)appLoaded / (float)appCount * 100f));
					}
				}
			}
		}

		public void DiscardChanges()
		{
			foreach (SteamApp app in Apps)
			{
				app.TargetLibrary = app.OriginalLibrary;
			}

			if (ChangesDiscarded != null)
			{
				ChangesDiscarded(this);
			}
		}

		public void ApplyChanges(Form calleeForm)
		{
			ApplyChanges_Start(calleeForm);
		}


		private void ApplyChanges_Start(Form calleeForm)
		{
			using (BackgroundWorker worker = new BackgroundWorker())
			{
				worker.WorkerReportsProgress = true;
				worker.DoWork += ApplyChangesWorker_DoWork;
				worker.RunWorkerCompleted += ApplyChangesWorker_Completed;

				MoveProgressForm progressForm = new MoveProgressForm(worker);
				progressForm.Show(calleeForm);

				worker.RunWorkerAsync(Config.Main.SteamPath);
			}
		}

		private void ApplyChangesWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			List<SteamApp> pendingApps = Apps.Where(a => a.TargetLibrary != a.OriginalLibrary).ToList();
			int appsMoved = 0;

			foreach (SteamApp app in pendingApps)
			{
				(sender as BackgroundWorker).ReportProgress(0, new MoveProgressForm.DisplayData(app.Name, appsMoved + 1, pendingApps.Count));
				
				try
				{
					string manifestName = string.Format("appmanifest_{0}.acf", app.Id);
					string originalManifestPath = Path.Combine(app.OriginalLibrary.Path, manifestName);
					string targetManifestPath = Path.Combine(app.TargetLibrary.Path, manifestName);

					string originalDirectoryPath = Path.Combine(app.OriginalLibrary.Path, "common", app.InstallDir);
					string targetDirectoryPath = Path.Combine(app.TargetLibrary.Path, "common", app.InstallDir);

					if (app.TargetLibrary.Drive == app.OriginalLibrary.Drive)
					{
						// Fast move applications between libraries on the same disk.
						Directory.Move(originalDirectoryPath, targetDirectoryPath);
						File.Move(originalManifestPath, targetManifestPath);
					}
					else
					{
						// Copy and delete applications on different disks.
						Utils.SafeMoveDirectory(originalDirectoryPath, targetDirectoryPath);
						File.Move(originalManifestPath, targetManifestPath);
					}
				}
				catch (System.Exception ex)
				{
					int n = 5;
				}

				app.ApplyMoving();

				if (AppMoved != null)
				{
					AppMoved(app);
				}

				++appsMoved;
			}

			(sender as BackgroundWorker).ReportProgress(0, new MoveProgressForm.DisplayData("", pendingApps.Count, pendingApps.Count));
		}
		
		private void ApplyChangesWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
		}
	}
}
