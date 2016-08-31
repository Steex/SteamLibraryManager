using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SteamLibraryManager
{
	partial class MainForm
	{
		private SteamLibraryManager.Action actionExit;
		private SteamLibraryManager.Action actionOptions;
		private SteamLibraryManager.Action actionAbout;

		private void InitializeActions()
		{
			actionExit = new SteamLibraryManager.Action("E&xit");
			actionExit.AttachToolItem(menuExit);
			actionExit.Execute += actionExit_Execute;

			actionOptions = new SteamLibraryManager.Action("&Options...", "Display the configuration dialog");
			actionOptions.AttachToolItem(menuOptions);
			//actionOptions.AttachToolItem(buttonOptions);
			actionOptions.Execute += actionOptions_Execute;

			actionAbout = new SteamLibraryManager.Action("&About...");
			actionAbout.AttachToolItem(menuAbout);
			actionAbout.Execute += actionAbout_Execute;

			SteamLibraryManager.Action.UpdateActions(EventArgs.Empty);
		}


		private void actionExit_Execute(object sender, EventArgs e)
		{
			Close();
		}

		private void actionOptions_Execute(object sender, EventArgs e)
		{
			using (OptionsForm optionsForm = new OptionsForm(Config.Main.Clone()))
			{
				if (optionsForm.ShowDialog(this) == DialogResult.OK)
				{
					// Update and save the config.
					Config.SetMain(optionsForm.LocalConfig);
					Config.Main.Save();
				}
			}
		}

		private void actionAbout_Execute(object sender, EventArgs e)
		{
			MessageBox.Show(this, "About", Application.ProductName);
		}
	}
}