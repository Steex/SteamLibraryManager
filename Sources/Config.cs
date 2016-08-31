using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace SteamLibraryManager
{
	public class Config
	{
		private static readonly string registryRootName = @"Software\SteexSoft\SteamLibraryManager";


		// Steam location.
		public string SteamPath { get; set; }


		// The config used by application.
		public static Config Main { get; private set; }


		static Config()
		{
			Main = new Config();
		}

		private Config()
		{
			SteamPath = "";
		}

		public Config Clone()
		{
			Config copy = new Config();

			copy.SteamPath = SteamPath;

			return copy;
		}


		public static void SetMain(Config config)
		{
			Main = config.Clone();
		}


		public void Init()
		{
			if (Registry.CurrentUser.OpenSubKey(registryRootName) != null)
			{
				Load();
				return;
			}

			// Steam location.
			SteamPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "");

			// All done.
			Save();
		}

		public void Load()
		{
			RegistryKey settingsRoot = Registry.CurrentUser.OpenSubKey(registryRootName);
			if (settingsRoot != null)
			{
				// Steam location.
				SteamPath = Utils.ReadRegistryValue(settingsRoot, "SteamPath", SteamPath);

				// All done.
				settingsRoot.Close();
			}
		}

		public void Save()
		{
			try
			{
				RegistryKey settingsRoot = Registry.CurrentUser.CreateSubKey(registryRootName);
				if (settingsRoot != null)
				{
					// Steam location.
					Utils.WriteRegistryValue(settingsRoot, "SteamPath", SteamPath);

					// All done.
					settingsRoot.Close();
				}
			}
			catch
			{
			}
		}
	}
}
