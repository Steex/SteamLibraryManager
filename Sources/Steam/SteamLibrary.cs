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

		public SteamLibrary(string path)
		{
			Name = path;
			Path = System.IO.Path.Combine(path, "steamapps");
		}
	}
}
