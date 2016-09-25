namespace SteamLibraryManager.Controls
{
	partial class LibraryView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.layout = new System.Windows.Forms.TableLayoutPanel();
			this.panelHeader = new System.Windows.Forms.Panel();
			this.labelNewSize = new System.Windows.Forms.Label();
			this.labelCurrentSize = new System.Windows.Forms.Label();
			this.labelNewCount = new System.Windows.Forms.Label();
			this.labelCurrentCount = new System.Windows.Forms.Label();
			this.labelPath = new System.Windows.Forms.Label();
			this.cellTooltipTimer = new System.Windows.Forms.Timer(this.components);
			this.cellTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.panelFooter = new System.Windows.Forms.Panel();
			this.labelDriveFreeSpace = new System.Windows.Forms.Label();
			this.labelDriveName = new System.Windows.Forms.Label();
			this.dataGrid = new SteamLibraryManager.Controls.DataGridViewEx();
			this.layout.SuspendLayout();
			this.panelHeader.SuspendLayout();
			this.panelFooter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// layout
			// 
			this.layout.ColumnCount = 1;
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.Controls.Add(this.panelFooter, 0, 2);
			this.layout.Controls.Add(this.panelHeader, 0, 0);
			this.layout.Controls.Add(this.dataGrid, 0, 1);
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(0, 0);
			this.layout.Name = "layout";
			this.layout.RowCount = 3;
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.layout.Size = new System.Drawing.Size(280, 102);
			this.layout.TabIndex = 0;
			// 
			// panelHeader
			// 
			this.panelHeader.BackColor = System.Drawing.Color.Silver;
			this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHeader.Controls.Add(this.labelNewSize);
			this.panelHeader.Controls.Add(this.labelCurrentSize);
			this.panelHeader.Controls.Add(this.labelNewCount);
			this.panelHeader.Controls.Add(this.labelCurrentCount);
			this.panelHeader.Controls.Add(this.labelPath);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(280, 55);
			this.panelHeader.TabIndex = 0;
			// 
			// labelNewSize
			// 
			this.labelNewSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNewSize.Location = new System.Drawing.Point(177, 35);
			this.labelNewSize.Name = "labelNewSize";
			this.labelNewSize.Size = new System.Drawing.Size(98, 13);
			this.labelNewSize.TabIndex = 0;
			this.labelNewSize.Text = "<NewSize>";
			this.labelNewSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelCurrentSize
			// 
			this.labelCurrentSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentSize.Location = new System.Drawing.Point(177, 19);
			this.labelCurrentSize.Name = "labelCurrentSize";
			this.labelCurrentSize.Size = new System.Drawing.Size(98, 13);
			this.labelCurrentSize.TabIndex = 0;
			this.labelCurrentSize.Text = "<CurrentSize>";
			this.labelCurrentSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelNewCount
			// 
			this.labelNewCount.AutoSize = true;
			this.labelNewCount.Location = new System.Drawing.Point(3, 35);
			this.labelNewCount.Name = "labelNewCount";
			this.labelNewCount.Size = new System.Drawing.Size(69, 13);
			this.labelNewCount.TabIndex = 0;
			this.labelNewCount.Text = "<NewCount>";
			// 
			// labelCurrentCount
			// 
			this.labelCurrentCount.AutoSize = true;
			this.labelCurrentCount.Location = new System.Drawing.Point(3, 19);
			this.labelCurrentCount.Name = "labelCurrentCount";
			this.labelCurrentCount.Size = new System.Drawing.Size(81, 13);
			this.labelCurrentCount.TabIndex = 0;
			this.labelCurrentCount.Text = "<CurrentCount>";
			// 
			// labelPath
			// 
			this.labelPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPath.Location = new System.Drawing.Point(3, 3);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(272, 13);
			this.labelPath.TabIndex = 0;
			this.labelPath.Text = "<Path>";
			// 
			// cellTooltipTimer
			// 
			this.cellTooltipTimer.Interval = 1000;
			this.cellTooltipTimer.Tick += new System.EventHandler(this.tooltipTimer_Tick);
			// 
			// panelFooter
			// 
			this.panelFooter.BackColor = System.Drawing.Color.Silver;
			this.panelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFooter.Controls.Add(this.labelDriveName);
			this.panelFooter.Controls.Add(this.labelDriveFreeSpace);
			this.panelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelFooter.Location = new System.Drawing.Point(0, 80);
			this.panelFooter.Margin = new System.Windows.Forms.Padding(0);
			this.panelFooter.Name = "panelFooter";
			this.panelFooter.Size = new System.Drawing.Size(280, 22);
			this.panelFooter.TabIndex = 5;
			// 
			// labelDriveFreeSpace
			// 
			this.labelDriveFreeSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDriveFreeSpace.Location = new System.Drawing.Point(142, 3);
			this.labelDriveFreeSpace.Name = "labelDriveFreeSpace";
			this.labelDriveFreeSpace.Size = new System.Drawing.Size(133, 13);
			this.labelDriveFreeSpace.TabIndex = 0;
			this.labelDriveFreeSpace.Text = "<FreeSpace>";
			this.labelDriveFreeSpace.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelDriveName
			// 
			this.labelDriveName.AutoSize = true;
			this.labelDriveName.Location = new System.Drawing.Point(3, 3);
			this.labelDriveName.Name = "labelDriveName";
			this.labelDriveName.Size = new System.Drawing.Size(44, 13);
			this.labelDriveName.TabIndex = 0;
			this.labelDriveName.Text = "<Drive>";
			// 
			// dataGrid
			// 
			this.dataGrid.AllowDrop = true;
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.AllowUserToResizeColumns = false;
			this.dataGrid.AllowUserToResizeRows = false;
			this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.ColumnHeadersVisible = false;
			this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid.Location = new System.Drawing.Point(0, 58);
			this.dataGrid.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.RowHeadersVisible = false;
			this.dataGrid.RowTemplate.Height = 18;
			this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGrid.ShowCellToolTips = false;
			this.dataGrid.Size = new System.Drawing.Size(280, 22);
			this.dataGrid.TabIndex = 4;
			this.dataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGrid_CellFormatting);
			this.dataGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellMouseEnter);
			this.dataGrid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellMouseLeave);
			this.dataGrid.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_CellMouseMove);
			this.dataGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGrid_DragDrop);
			this.dataGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGrid_DragEnter);
			this.dataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseDown);
			this.dataGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseMove);
			// 
			// LibraryView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.layout);
			this.Name = "LibraryView";
			this.Size = new System.Drawing.Size(280, 102);
			this.layout.ResumeLayout(false);
			this.panelHeader.ResumeLayout(false);
			this.panelHeader.PerformLayout();
			this.panelFooter.ResumeLayout(false);
			this.panelFooter.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel layout;
		private System.Windows.Forms.Panel panelHeader;
		private System.Windows.Forms.Label labelCurrentSize;
		private System.Windows.Forms.Label labelCurrentCount;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.Label labelNewCount;
		private System.Windows.Forms.Label labelNewSize;
		private DataGridViewEx dataGrid;
		private System.Windows.Forms.Timer cellTooltipTimer;
		private System.Windows.Forms.ToolTip cellTooltip;
		private System.Windows.Forms.Panel panelFooter;
		private System.Windows.Forms.Label labelDriveFreeSpace;
		private System.Windows.Forms.Label labelDriveName;
	}
}
