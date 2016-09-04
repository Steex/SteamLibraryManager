using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SteamLibraryManager.Controls
{
	public class DataGridViewEx : DataGridView
	{
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
		private const int WM_SETREDRAW = 11; 


		[Category("Behavior")]
		[DefaultValue(true)]
		public bool AllowMultiRowDrag { get; set; }


		private DataGridViewCell holdedCellToSelect = null;


		public DataGridViewEx()
			: base()
		{
			AllowMultiRowDrag = true;
		}


		public void PreventSelectionChange()
		{
			holdedCellToSelect = null;
		}


		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			List<DataGridViewCell> selectedCells = null;

			// Intercept left clicks without modifier keys.
			if (AllowMultiRowDrag &&
				(e.Button & MouseButtons.Left) == MouseButtons.Left &&
				ModifierKeys == Keys.None)
			{
				HitTestInfo hitInfo = HitTest(e.X, e.Y);

				// If the empty space is clicked then clean the selection.
				if (hitInfo.Type == DataGridViewHitTestType.None)
				{
					ClearSelection();
				}
				// If a selected cell is clicked, remember the current selection
				// and temporary suspend the control redrawing.
				else if (hitInfo.Type == DataGridViewHitTestType.Cell &&
					this[hitInfo.ColumnIndex, hitInfo.RowIndex].Selected)
				{
					selectedCells = SelectedCells.OfType<DataGridViewCell>().ToList();
					holdedCellToSelect = this[hitInfo.ColumnIndex, hitInfo.RowIndex];
					SendMessage(this.Handle, WM_SETREDRAW, false, 0);
				}
			}

			// Perform base processing.
			base.OnMouseDown(e);

			// Restore selection if necessary and resume the control redrawing.
			if (holdedCellToSelect != null)
			{
				ClearSelection();
				foreach (var cell in selectedCells)
				{
					cell.Selected = true;
				}
				SendMessage(this.Handle, WM_SETREDRAW, true, 0);
			}
		}

		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			// Apply the pending selection change, if any.
			if (holdedCellToSelect != null)
			{
				ClearSelection();
				holdedCellToSelect.Selected = true;
				holdedCellToSelect = null;
			}

			// Perform base processing.
			base.OnMouseUp(e);
		}
	}
}
