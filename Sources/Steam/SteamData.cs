using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SteamLibraryManager
{
	public class SteamData
	{
		private string installDir;


		public List<SteamLibrary> Libraries { get; private set; }


		public SteamData(string installDir)
		{
			this.installDir = installDir;

			// Init the main library.
			Libraries = new List<SteamLibrary>();
			Libraries.Add(new SteamLibrary(Path.Combine(installDir, "steamapps")));

			// Init additional libraries.
			try
			{
				SteamKeyValue libraryConfig = SteamKeyValue.LoadFromFile(Path.Combine(installDir, "steamapps\\libraryfolders.vdf"));
				for (int i = 1; ; ++i)
				{
					SteamKeyValue libraryData = libraryConfig.Children.Find(kv => kv.Name == i.ToString());
					if (libraryData != null)
					{
						Libraries.Add(new SteamLibrary(Path.Combine(libraryData.Value, "steamapps")));
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
		}
	}
}
