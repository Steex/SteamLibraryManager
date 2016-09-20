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
		private int cellTooltipRow;
		private Size cellTooltipSize;
		private bool cellTooltipVisible = false;


		private SteamData SteamData { get; set; }
		private IEnumerable<SteamApp> CurrentApps { get { return SteamData.Apps.Where(a => a.OriginalLibrary == Library); } }
		private IEnumerable<SteamApp> TargetApps { get { return SteamData.Apps.Where(a => a.TargetLibrary == Library); } }
		public SteamLibrary Library { get; private set; }


		public LibraryView(SteamData steamData, SteamLibrary library)
		{
			InitializeComponent();

			SteamData = steamData;
			Library = library;

			// Init labels.
			UpdateLabels();

			// Init grid
			gridViewItems = new BindingList<GridViewItem>();

			foreach (SteamApp app in TargetApps)
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


		private void UpdateLabels()
		{
			// Calculate sizes
			int currentCount = 0;
			int targetCount = 0;
			long currentSize = 0;
			long targetSize = 0;

			long spaceToFree = 0;
			long spaceToOccupy = 0;

			foreach (SteamApp app in CurrentApps)
			{
				currentCount += 1;
				currentSize += app.Size;

				if (app.OriginalLibrary.Drive != app.TargetLibrary.Drive)
				{
					spaceToFree += app.Size;
				}
			}

			foreach (SteamApp app in TargetApps)
			{
				targetCount += 1;
				targetSize += app.Size;

				if (app.OriginalLibrary.Drive != app.TargetLibrary.Drive)
				{
					spaceToOccupy += app.Size;
				}
			}

			// Calculating the remaining space of the drive
			DriveInfo driveInfo = new DriveInfo(Library.Drive);
			long targetFreeSpace = driveInfo.AvailableFreeSpace + spaceToFree - spaceToOccupy;

			// Update labels.
			labelPath.Text = Library.Name;
			labelCurrentCount.Text = string.Format("{0} app(s)", currentCount);
			labelCurrentSize.Text = Utils.FormatGbSize(currentSize);
			labelNewCount.Text = string.Format("{0} app(s)", targetCount);
			labelNewSize.Text = Utils.FormatGbSize(targetSize);

			labelDriveName.Text = string.Format("Physical drive: {0}", Library.Drive);
			labelDriveFreeSpace.Text = string.Format("{0}", Utils.FormatGbSize(targetFreeSpace));

			labelDriveFreeSpace.ForeColor = targetFreeSpace >= 0 ? SystemColors.ControlText : Color.Red;
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

						// Update the counters.
						UpdateLabels();
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

					// Update the counters.
					UpdateLabels();
				}
			}
		}

		private void dataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			// Make sure the cursor is over the grid (fix some problems with drag-n-drop).
			if (!dataGrid.Bounds.Contains(dataGrid.Parent.PointToClient(MousePosition)))
			{
				return;
			}

			// Wait for some time before displaying tooltip.
			cellTooltipRow = e.RowIndex;
			cellTooltipTimer.Start();
		}

		private void dataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			// Prevent tooltip from displaying.
			cellTooltipTimer.Stop();

			// Hide the currently visible tooltip.
			if (cellTooltipVisible)
			{
				cellTooltipVisible = false;
				cellTooltip.Hide(dataGrid);
			}
		}

		private void dataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
		{
			// Make sure the cursor is over the grid (fix some problems with drag-n-drop).
			if (!dataGrid.Bounds.Contains(dataGrid.Parent.PointToClient(MousePosition)))
			{
				return;
			}

			// If tooltip is not displayed, reset the waiting time.
			if (!cellTooltipVisible)
			{
				cellTooltipTimer.Stop();
				cellTooltipTimer.Start();
			}
		}

		private void tooltipTimer_Tick(object sender, EventArgs e)
		{
			if (!cellTooltipVisible)
			{
				// Stop the timer.
				cellTooltipTimer.Stop();

				// Acknowledge the displaying.
				cellTooltipVisible = true;

				// Determine tooltip params.
				SteamApp app = gridViewItems[cellTooltipRow].App;
				string tooltipText = app.Name + "\r\n" + app.OriginalLibrary.Name;
				int tooltipX = dataGrid.PointToClient(Cursor.Position).X;
				int tooltipY = dataGrid.GetRowDisplayRectangle(cellTooltipRow, false).Top;

				// Fake the tooltip display and measure size.
				cellTooltip.Popup += cellTooltip_FakePopup;
				cellTooltip.Show(tooltipText, dataGrid, tooltipX, tooltipY);
				cellTooltip.Popup -= cellTooltip_FakePopup;

				// Actually display the tooltip in the corrected position.
				cellTooltip.Show(tooltipText, dataGrid, tooltipX, tooltipY - cellTooltipSize.Height);
			}
		}

		private void cellTooltip_FakePopup(object sender, PopupEventArgs e)
		{
			// Remember the size and prevent the tooltip from displaying.
			cellTooltipSize = e.ToolTipSize;
			e.Cancel = true;
		}
	}
}
