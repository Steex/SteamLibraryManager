using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SteamLibraryManager.Details
{
	internal class PlatformUtilsImplWindows: IPlatformUtilsImpl
	{
		public PlatformUtilsImplWindows()
		{
		}

		public bool SteamIsRunning()
		{
			return Process.GetProcesses().Any(p =>
				p.ProcessName.ToLower() == "steam" &&
				p.MainModule.FileVersionInfo.LegalCopyright.ToLower().Contains("valve"));
		}

		public string ResolvePath(string path)
		{
			return Windows.SymbolicLink.GetTarget(path);
		}
	}
}
