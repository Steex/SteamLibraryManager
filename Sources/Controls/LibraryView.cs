using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SteamLibraryManager.Controls
{
	public partial class LibraryView : UserControl
	{
		public SteamLibrary Library { get; private set; }


		public LibraryView(SteamLibrary library)
		{
			InitializeComponent();

			Library = library;

			// Init
			long totalSize = 0;
			int totalCount = 0;

			foreach (SteamApp app in Library.Apps)
			{
				totalSize += app.Size;
				totalCount += 1;

				listGames.Items.Add(app.Name);
			}

			labelPath.Text = library.Name;
			labelCurrentCount.Text = string.Format("{0} app(s)", totalCount);
			labelCurrentSize.Text = Utils.FormatGbSize(totalSize);
		}
	}
}
