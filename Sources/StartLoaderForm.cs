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
	public partial class StartLoaderForm : Form
	{
		public StartLoaderForm(BackgroundWorker worker)
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
			Console.WriteLine("progress = " + e.ProgressPercentage.ToString());
			progressBar.Value = e.ProgressPercentage;
		}

		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Close();
		}

	}
}
