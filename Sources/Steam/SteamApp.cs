using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SteamLibraryManager
{
	public class SteamApp
	{
		public string Library { get; private set; }
		public string Id { get; private set; }
		public string Name { get; private set; }
		public string InstallDir { get; private set; }
		public long Size { get; private set; }

		public SteamApp(string library, string manifestFile)
		{
			Library = library;

			string manifestPath = Path.Combine(library, "steamapps", manifestFile);
			SteamKeyValue manifest = SteamKeyValue.LoadFromFile(manifestPath);

			Id = manifest["AppID"].AsString();
			Name = manifest["name"].AsString();
			InstallDir = manifest["installdir"].AsString();

			string installPath = Path.Combine(library, "steamapps\\common", InstallDir);
			DirectoryInfo installDirectory = new DirectoryInfo(installPath);
			Size = installDirectory.EnumerateFiles("*.*", SearchOption.AllDirectories).Aggregate(0L, (s, f) => s += f.Length);
		}
	}
}
