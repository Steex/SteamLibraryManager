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
		/// <summary>
		/// Adapter of a Steam application to display with DataGridView
		/// </summary>
		public class GridViewItem
		{
			[Browsable(false)]
			public SteamApp App { get; private set; }
			public string Name { get; private set; }
			public string Size { get; private set; }

			public GridViewItem(SteamApp app)
			{
				App = app;
				Name = app.Name;
				Size = Utils.FormatGbSize(app.Size);
			}
		}

		private BindingList<GridViewItem> gridViewItems;


		public SteamLibrary Library { get; private set; }


		public LibraryView(SteamLibrary library)
		{
			InitializeComponent();

			Library = library;

			// Init labels.
			long totalSize = 0;
			int totalCount = 0;

			foreach (SteamApp app in Library.Apps)
			{
				totalSize += app.Size;
				totalCount += 1;
			}

			labelPath.Text = library.Name;
			labelCurrentCount.Text = string.Format("{0} app(s)", totalCount);
			labelCurrentSize.Text = Utils.FormatGbSize(totalSize);


			// Init grid
			gridViewItems = new BindingList<GridViewItem>();

			foreach (SteamApp app in Library.Apps)
			{
				gridViewItems.Add(new GridViewItem(app));
			}

			dataGrid.DataSource = gridViewItems;
			dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

		private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex == 2)
			{
				e.CellStyle.ForeColor = Color.Red;
			}
		}


	}
}
