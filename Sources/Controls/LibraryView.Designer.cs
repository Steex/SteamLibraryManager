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
			this.panelFooter = new System.Windows.Forms.Panel();
			this.labelDriveName = new System.Windows.Forms.Label();
			this.panelHeader = new System.Windows.Forms.Panel();
			this.cellTooltipTimer = new System.Windows.Forms.Timer(this.components);
			this.cellTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.headerLayout = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.labelCurrentCount = new System.Windows.Forms.Label();
			this.labelCurrentSize = new System.Windows.Forms.Label();
			this.labelCurrentFreeSpace = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.labelTargetCount = new System.Windows.Forms.Label();
			this.labelTargetSize = new System.Windows.Forms.Label();
			this.labelTargetFreeSpace = new System.Windows.Forms.Label();
			this.labelPath = new System.Windows.Forms.Label();
			this.dataGrid = new SteamLibraryManager.Controls.DataGridViewEx();
			this.layout.SuspendLayout();
			this.panelFooter.SuspendLayout();
			this.panelHeader.SuspendLayout();
			this.headerLayout.SuspendLayout();
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
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.layout.Size = new System.Drawing.Size(283, 121);
			this.layout.TabIndex = 0;
			// 
			// panelFooter
			// 
			this.panelFooter.BackColor = System.Drawing.Color.Silver;
			this.panelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFooter.Controls.Add(this.labelDriveName);
			this.panelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelFooter.Location = new System.Drawing.Point(0, 99);
			this.panelFooter.Margin = new System.Windows.Forms.Padding(0);
			this.panelFooter.Name = "panelFooter";
			this.panelFooter.Size = new System.Drawing.Size(283, 22);
			this.panelFooter.TabIndex = 5;
			// 
			// labelDriveName
			// 
			this.labelDriveName.AutoSize = true;
			this.labelDriveName.Location = new System.Drawing.Point(68, 3);
			this.labelDriveName.Name = "labelDriveName";
			this.labelDriveName.Size = new System.Drawing.Size(44, 13);
			this.labelDriveName.TabIndex = 0;
			this.labelDriveName.Text = "<Drive>";
			// 
			// panelHeader
			// 
			this.panelHeader.BackColor = System.Drawing.Color.Silver;
			this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHeader.Controls.Add(this.headerLayout);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(283, 73);
			this.panelHeader.TabIndex = 0;
			// 
			// cellTooltipTimer
			// 
			this.cellTooltipTimer.Interval = 1000;
			this.cellTooltipTimer.Tick += new System.EventHandler(this.tooltipTimer_Tick);
			// 
			// headerLayout
			// 
			this.headerLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.headerLayout.ColumnCount = 4;
			this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
			this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
			this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
			this.headerLayout.Controls.Add(this.labelPath, 0, 0);
			this.headerLayout.Controls.Add(this.labelTargetFreeSpace, 3, 3);
			this.headerLayout.Controls.Add(this.labelTargetSize, 2, 3);
			this.headerLayout.Controls.Add(this.labelTargetCount, 1, 3);
			this.headerLayout.Controls.Add(this.label10, 0, 3);
			this.headerLayout.Controls.Add(this.labelCurrentFreeSpace, 3, 2);
			this.headerLayout.Controls.Add(this.labelCurrentSize, 2, 2);
			this.headerLayout.Controls.Add(this.labelCurrentCount, 1, 2);
			this.headerLayout.Controls.Add(this.label6, 0, 2);
			this.headerLayout.Controls.Add(this.label5, 3, 1);
			this.headerLayout.Controls.Add(this.label3, 1, 1);
			this.headerLayout.Controls.Add(this.label2, 2, 1);
			this.headerLayout.Location = new System.Drawing.Point(3, 3);
			this.headerLayout.Name = "headerLayout";
			this.headerLayout.RowCount = 4;
			this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.headerLayout.Size = new System.Drawing.Size(276, 65);
			this.headerLayout.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(71, 17);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Apps";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(137, 17);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Size (GB)";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(224, 17);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Free (GB)";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(0, 33);
			this.label6.Margin = new System.Windows.Forms.Padding(0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Current";
			// 
			// labelCurrentCount
			// 
			this.labelCurrentCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelCurrentCount.AutoSize = true;
			this.labelCurrentCount.Location = new System.Drawing.Point(55, 33);
			this.labelCurrentCount.Margin = new System.Windows.Forms.Padding(0);
			this.labelCurrentCount.Name = "labelCurrentCount";
			this.labelCurrentCount.Size = new System.Drawing.Size(47, 13);
			this.labelCurrentCount.TabIndex = 7;
			this.labelCurrentCount.Text = "<Count>";
			// 
			// labelCurrentSize
			// 
			this.labelCurrentSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelCurrentSize.AutoSize = true;
			this.labelCurrentSize.Location = new System.Drawing.Point(149, 33);
			this.labelCurrentSize.Margin = new System.Windows.Forms.Padding(0);
			this.labelCurrentSize.Name = "labelCurrentSize";
			this.labelCurrentSize.Size = new System.Drawing.Size(39, 13);
			this.labelCurrentSize.TabIndex = 8;
			this.labelCurrentSize.Text = "<Size>";
			// 
			// labelCurrentFreeSpace
			// 
			this.labelCurrentFreeSpace.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelCurrentFreeSpace.AutoSize = true;
			this.labelCurrentFreeSpace.Location = new System.Drawing.Point(226, 33);
			this.labelCurrentFreeSpace.Margin = new System.Windows.Forms.Padding(0);
			this.labelCurrentFreeSpace.Name = "labelCurrentFreeSpace";
			this.labelCurrentFreeSpace.Size = new System.Drawing.Size(50, 13);
			this.labelCurrentFreeSpace.TabIndex = 9;
			this.labelCurrentFreeSpace.Text = "<Space>";
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(0, 50);
			this.label10.Margin = new System.Windows.Forms.Padding(0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(38, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Target";
			// 
			// labelTargetCount
			// 
			this.labelTargetCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelTargetCount.AutoSize = true;
			this.labelTargetCount.Location = new System.Drawing.Point(55, 50);
			this.labelTargetCount.Margin = new System.Windows.Forms.Padding(0);
			this.labelTargetCount.Name = "labelTargetCount";
			this.labelTargetCount.Size = new System.Drawing.Size(47, 13);
			this.labelTargetCount.TabIndex = 11;
			this.labelTargetCount.Text = "<Count>";
			// 
			// labelTargetSize
			// 
			this.labelTargetSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelTargetSize.AutoSize = true;
			this.labelTargetSize.Location = new System.Drawing.Point(149, 50);
			this.labelTargetSize.Margin = new System.Windows.Forms.Padding(0);
			this.labelTargetSize.Name = "labelTargetSize";
			this.labelTargetSize.Size = new System.Drawing.Size(39, 13);
			this.labelTargetSize.TabIndex = 12;
			this.labelTargetSize.Text = "<Size>";
			// 
			// labelTargetFreeSpace
			// 
			this.labelTargetFreeSpace.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelTargetFreeSpace.AutoSize = true;
			this.labelTargetFreeSpace.Location = new System.Drawing.Point(226, 50);
			this.labelTargetFreeSpace.Margin = new System.Windows.Forms.Padding(0);
			this.labelTargetFreeSpace.Name = "labelTargetFreeSpace";
			this.labelTargetFreeSpace.Size = new System.Drawing.Size(50, 13);
			this.labelTargetFreeSpace.TabIndex = 13;
			this.labelTargetFreeSpace.Text = "<Space>";
			// 
			// labelPath
			// 
			this.labelPath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelPath.AutoSize = true;
			this.headerLayout.SetColumnSpan(this.labelPath, 4);
			this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPath.Location = new System.Drawing.Point(114, 1);
			this.labelPath.Margin = new System.Windows.Forms.Padding(0);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(47, 13);
			this.labelPath.TabIndex = 14;
			this.labelPath.Text = "<Path>";
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
			this.dataGrid.Location = new System.Drawing.Point(0, 76);
			this.dataGrid.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.RowHeadersVisible = false;
			this.dataGrid.RowTemplate.Height = 18;
			this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGrid.ShowCellToolTips = false;
			this.dataGrid.Size = new System.Drawing.Size(283, 23);
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
			this.Size = new System.Drawing.Size(283, 121);
			this.layout.ResumeLayout(false);
			this.panelFooter.ResumeLayout(false);
			this.panelFooter.PerformLayout();
			this.panelHeader.ResumeLayout(false);
			this.headerLayout.ResumeLayout(false);
			this.headerLayout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel layout;
		private System.Windows.Forms.Panel panelHeader;
		private DataGridViewEx dataGrid;
		private System.Windows.Forms.Timer cellTooltipTimer;
		private System.Windows.Forms.ToolTip cellTooltip;
		private System.Windows.Forms.Panel panelFooter;
		private System.Windows.Forms.Label labelDriveName;
		private System.Windows.Forms.TableLayoutPanel headerLayout;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.Label labelTargetFreeSpace;
		private System.Windows.Forms.Label labelTargetSize;
		private System.Windows.Forms.Label labelTargetCount;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label labelCurrentFreeSpace;
		private System.Windows.Forms.Label labelCurrentSize;
		private System.Windows.Forms.Label labelCurrentCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}
