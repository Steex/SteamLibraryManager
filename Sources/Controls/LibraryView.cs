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
		private class GridViewItem
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


		private class AppListDragData
		{
			public LibraryView Origin { get; private set; }
			public List<SteamApp> Apps { get; private set; }

			public AppListDragData(LibraryView origin)
			{
				Origin = origin;
				Apps = new List<SteamApp>();
			}
		}


		private BindingList<GridViewItem> gridViewItems;
		private Rectangle dragBoxFromMouseDown;


		private SteamData SteamData { get; set; }
		public SteamLibrary Library { get; private set; }


		public LibraryView(SteamData steamData, SteamLibrary library)
		{
			InitializeComponent();

			SteamData = steamData;
			Library = library;

			IEnumerable<SteamApp> libraryApps = SteamData.Apps.Where(a => a.OriginalLibrary == Library);

			// Init labels.
			long totalSize = 0;
			int totalCount = 0;

			foreach (SteamApp app in libraryApps)
			{
				totalSize += app.Size;
				totalCount += 1;
			}

			labelPath.Text = library.Name;
			labelCurrentCount.Text = string.Format("{0} app(s)", totalCount);
			labelCurrentSize.Text = Utils.FormatGbSize(totalSize);

			// Init grid
			gridViewItems = new BindingList<GridViewItem>();

			foreach (SteamApp app in libraryApps)
			{
				gridViewItems.Add(new GridViewItem(app));
			}

			dataGrid.DataSource = gridViewItems;
			dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dataGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dataGrid.ClearSelection();
		}


		private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			SteamApp app = gridViewItems[e.RowIndex].App;

			if (app.TargetLibrary != app.OriginalLibrary)
			{
				e.CellStyle.ForeColor = Color.Red;
			}
		}

		private void dataGrid_MouseDown(object sender, MouseEventArgs e)
		{
			dragBoxFromMouseDown = Rectangle.Empty;
			if (e.Button == MouseButtons.Left && ModifierKeys == Keys.None)
			{
				// Get the index of the item the mouse is below.
				var hitInfo = dataGrid.HitTest(e.X, e.Y);

				if (hitInfo.Type == DataGridViewHitTestType.Cell)
				{
					// Create a rectangle using the DragSize, with the mouse position being
					// at the center of the rectangle.
					Size dragSize = SystemInformation.DragSize;
					dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
				}
			}
		}

		private void dataGrid_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button.HasFlag(MouseButtons.Left))
			{
				// If the mouse moves outside the rectangle, start the drag.
				if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
				{
					dataGrid.PreventSelectionChange();

					// Prepare drag-n-drop data.
					AppListDragData dragData = new AppListDragData(this);
					foreach (DataGridViewRow selectedRow in dataGrid.SelectedRows)
					{
						dragData.Apps.Add((selectedRow.DataBoundItem as GridViewItem).App);
					}

					// Start drag-n-drop operation.
					if (dataGrid.DoDragDrop(dragData, DragDropEffects.Move) == DragDropEffects.Move)
					{
						// In case of successful move clear the moved items from the library.
						foreach (SteamApp movedApp in dragData.Apps)
						{
							gridViewItems.Remove(gridViewItems.First(i => i.App == movedApp));
						}
						
						// Suppress the automatic selection.
						dataGrid.ClearSelection();
					}
				}
			}
		}

		private void dataGrid_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(AppListDragData)))
			{
				AppListDragData dragData = (AppListDragData)e.Data.GetData(typeof(AppListDragData));
				if (dragData.Origin != this)
				{
					e.Effect = DragDropEffects.Move;
				}
			}
		}

		private void dataGrid_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(AppListDragData)))
			{
				AppListDragData dragData = (AppListDragData)e.Data.GetData(typeof(AppListDragData));

				if (dragData.Origin != this)
				{
					e.Effect = DragDropEffects.Move;

					// Determine an insert position.
					// The height offset is applying to attain more natural inserting behavior:
					// items are insert into nearest line between rows.
					Point clientPoint = dataGrid.PointToClient(new Point(e.X, e.Y));
					int heightOffset = dataGrid.Rows.Count > 0 ? dataGrid.Rows[0].Height / 2 : 0;
					var hitInfo = dataGrid.HitTest(clientPoint.X, clientPoint.Y + heightOffset);
					int insertIndex = hitInfo.RowIndex >= 0 ? hitInfo.RowIndex : gridViewItems.Count;

					// Insert the dragging items into the found position.
					foreach (SteamApp app in dragData.Apps.Reverse<SteamApp>())
					{
						gridViewItems.Insert(insertIndex, new GridViewItem(app));
					}

					// Select the moved rows.
					dataGrid.ClearSelection();
					for (int i = insertIndex; i < insertIndex + dragData.Apps.Count; ++i)
					{
						dataGrid.Rows[insertIndex].Selected = true;
					}

					// Change the target library.
					foreach (SteamApp app in dragData.Apps.Reverse<SteamApp>())
					{
						app.TargetLibrary = Library;
					}
				}
			}
		}

	}
}
