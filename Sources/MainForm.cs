using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace SteamLibraryManager
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitializeActions();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			ReadSteamData();
		}


		private void ReadSteamData()
		{
			using (BackgroundWorker worker = new BackgroundWorker())
			{
				worker.WorkerReportsProgress = true;
				worker.DoWork += ReadSteamDataWorker_DoWork;
				worker.RunWorkerCompleted += ReadSteamDataWorker_Completed;

				StartLoaderForm progressForm = new StartLoaderForm(worker);
				progressForm.Show(this);

				worker.RunWorkerAsync(Config.Main.SteamPath);
			}
		}

		private void ReadSteamDataWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			SteamData steamData = new SteamData((string)e.Argument, (p) => (sender as BackgroundWorker).ReportProgress(p));
			e.Result = steamData;
		}

		private void ReadSteamDataWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			libraryView.SteamData = (SteamData)e.Result;
		}
	}
}
