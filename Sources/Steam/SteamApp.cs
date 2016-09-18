using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SteamLibraryManager
{
	public class SteamApp
	{
		public SteamLibrary OriginalLibrary { get; private set; }
		public SteamLibrary TargetLibrary { get; set; }
		public string Id { get; private set; }
		public string Name { get; private set; }
		public string InstallDir { get; private set; }
		public long Size { get; private set; }

		public SteamApp(SteamLibrary library, string manifestFile)
		{
			OriginalLibrary = library;
			TargetLibrary = library;

			string manifestPath = Path.Combine(library.Path, manifestFile);
			SteamKeyValue manifest = SteamKeyValue.LoadFromFile(manifestPath);

			// Read base settings.
			Id = manifest["AppID"].AsString();
			Name = manifest["name"].AsString();
			InstallDir = manifest["installdir"].AsString();

			// Override with user settings.
			string userSpecificName = manifest["UserConfig"]["name"].Value;
			if (!string.IsNullOrWhiteSpace(userSpecificName))
			{
				Name = userSpecificName;
			}

			// Calculate disk size.
			string installPath = Path.Combine(library.Path, "common", InstallDir);
			DirectoryInfo installDirectory = new DirectoryInfo(installPath);
			Size = installDirectory.EnumerateFiles("*.*", SearchOption.AllDirectories).Aggregate(0L, (s, f) => s += f.Length);
		}
	}
}
