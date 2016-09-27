using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamLibraryManager.Details
{
	internal interface IPlatformUtilsImpl
	{
		bool SteamIsRunning();
		string ResolvePath(string path);
	}
}
