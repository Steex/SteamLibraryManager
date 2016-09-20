using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace SteamLibraryManager.Details
{
	internal class PlatformUtilsImplWindows: IPlatformUtilsImpl
	{
		public PlatformUtilsImplWindows()
		{
		}

		public string ResolvePath(string path)
		{
			return Windows.SymbolicLink.GetTarget(path);
		}
	}
}
