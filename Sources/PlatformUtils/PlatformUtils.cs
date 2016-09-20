using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamLibraryManager
{
	static class PlatformUtils
	{
		static PlatformUtils()
		{
			impl = new Details.PlatformUtilsImplWindows();
		}

		private static Details.IPlatformUtilsImpl impl = null;


		public static string ResolvePath(string path)
		{
			return impl.ResolvePath(path);
		}
	}
}
