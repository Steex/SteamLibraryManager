namespace SteamLibraryManager.Controls
{
	partial class LibraryView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.layout = new System.Windows.Forms.TableLayoutPanel();
			this.panelHeader = new System.Windows.Forms.Panel();
			this.labelCurrentSize = new System.Windows.Forms.Label();
			this.labelCurrentCount = new System.Windows.Forms.Label();
			this.labelPath = new System.Windows.Forms.Label();
			this.listGames = new System.Windows.Forms.ListBox();
			this.labelNewCount = new System.Windows.Forms.Label();
			this.labelNewSize = new System.Windows.Forms.Label();
			this.layout.SuspendLayout();
			this.panelHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// layout
			// 
			this.layout.ColumnCount = 1;
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.Controls.Add(this.panelHeader, 0, 0);
			this.layout.Controls.Add(this.listGames, 0, 1);
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(0, 0);
			this.layout.Name = "layout";
			this.layout.RowCount = 3;
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.layout.Size = new System.Drawing.Size(280, 101);
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
			this.labelPath.Location = new System.Drawing.Point(3, 3);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(272, 13);
			this.labelPath.TabIndex = 0;
			this.labelPath.Text = "<Path>";
			// 
			// listGames
			// 
			this.listGames.BackColor = System.Drawing.SystemColors.Control;
			this.listGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listGames.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listGames.FormattingEnabled = true;
			this.listGames.IntegralHeight = false;
			this.listGames.Location = new System.Drawing.Point(0, 58);
			this.listGames.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.listGames.Name = "listGames";
			this.listGames.Size = new System.Drawing.Size(280, 23);
			this.listGames.TabIndex = 1;
			// 
			// labelNewCount
			// 
			this.labelNewCount.AutoSize = true;
			this.labelNewCount.ForeColor = System.Drawing.Color.Red;
			this.labelNewCount.Location = new System.Drawing.Point(3, 35);
			this.labelNewCount.Name = "labelNewCount";
			this.labelNewCount.Size = new System.Drawing.Size(69, 13);
			this.labelNewCount.TabIndex = 0;
			this.labelNewCount.Text = "<NewCount>";
			// 
			// labelNewSize
			// 
			this.labelNewSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNewSize.ForeColor = System.Drawing.Color.Red;
			this.labelNewSize.Location = new System.Drawing.Point(177, 35);
			this.labelNewSize.Name = "labelNewSize";
			this.labelNewSize.Size = new System.Drawing.Size(98, 13);
			this.labelNewSize.TabIndex = 0;
			this.labelNewSize.Text = "<NewSize>";
			this.labelNewSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LibraryView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.layout);
			this.Name = "LibraryView";
			this.Size = new System.Drawing.Size(280, 101);
			this.layout.ResumeLayout(false);
			this.panelHeader.ResumeLayout(false);
			this.panelHeader.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel layout;
		private System.Windows.Forms.Panel panelHeader;
		private System.Windows.Forms.Label labelCurrentSize;
		private System.Windows.Forms.Label labelCurrentCount;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.ListBox listGames;
		private System.Windows.Forms.Label labelNewCount;
		private System.Windows.Forms.Label labelNewSize;
	}
}
