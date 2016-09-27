using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace SteamLibraryManager
{
	public delegate void SteamDataChangedEventHandler(SteamData data);


	public class SteamData
	{
		public delegate void ProgressChangedEventHandler(int percent);

		public event SteamDataChangedEventHandler ChangesDiscarded;
		public event SteamAppChangedEventHandler AppTargetLibraryChanged;


		private string installDir;

		public List<SteamLibrary> Libraries { get; private set; }
		public List<SteamApp> Apps{ get; private set; }


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

	}
}
