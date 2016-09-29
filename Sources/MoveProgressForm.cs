using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteamLibraryManager
{
	public partial class MoveProgressForm : Form
	{
		public class DisplayData
		{
			public string AppName { get; private set; }
			public int AppIndex { get; private set; }
			public int AppCount { get; private set; }

			public DisplayData(string appName, int appIndex, int appCount)
			{
				AppName = appName;
				AppIndex = appIndex;
				AppCount = appCount;
			}
		}


		public MoveProgressForm(BackgroundWorker worker)
		{
			InitializeComponent();

			worker.ProgressChanged += worker_ProgressChanged;
			worker.RunWorkerCompleted += worker_RunWorkerCompleted;
		}


		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			// Center the form within the bounds of the owner.
			Location = new Point(
				Owner.Location.X + (Owner.Width - Width) / 2,
				Owner.Location.Y + (Owner.Height - Height) / 2);
		}


		private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			DisplayData data = (DisplayData)e.UserState;
			int progress = (int)((float)(data.AppIndex - 1) / (float)data.AppCount * 100f);

			labelProgress.Text = string.Format("Move application {0} of {1}", data.AppIndex, data.AppCount);
			labelMovingApp.Text = data.AppName;
			progressBar.Value = progress;
		}

		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Close();
		}

	}
}
