using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SteamLibraryManager
{
	public class SteamData
	{
		public event SteamAppChangedEventHandler AppTargetLibraryChanged;

		private string installDir;

		public List<SteamLibrary> Libraries { get; private set; }
		public List<SteamApp> Apps{ get; private set; }


		public SteamData(string installDir)
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
			Apps = new List<SteamApp>();

			foreach (SteamLibrary library in Libraries)
			{
				foreach (string manifestPath in Directory.GetFiles(library.Path, "appmanifest_*.acf"))
				{
					SteamApp app = new SteamApp(library, System.IO.Path.GetFileName(manifestPath));
					app.TargetLibraryChanged += a => { if (AppTargetLibraryChanged != null) AppTargetLibraryChanged(app); };
					Apps.Add(app);
				}
			}
		}

	}
}
