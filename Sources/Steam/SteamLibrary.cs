using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SteamLibraryManager
{
	public class SteamLibrary
	{
		public string Name { get; private set; }
		public string Path { get; private set; }
		public List<SteamApp> Apps;

		public SteamLibrary(string path)
		{
			Name = path;
			Path = System.IO.Path.Combine(path, "steamapps");

			// Read applications information.
			Apps = new List<SteamApp>();

			foreach (string manifestPath in Directory.GetFiles(Path, "appmanifest_*.acf"))
			{
				Apps.Add(new SteamApp(this, System.IO.Path.GetFileName(manifestPath)));
			}

		}
	}
}
