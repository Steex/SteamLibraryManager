namespace SteamLibraryManager
{
	partial class MoveProgressForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelMovingApp = new System.Windows.Forms.Label();
			this.labelProgress = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// labelMovingApp
			// 
			this.labelMovingApp.AutoSize = true;
			this.labelMovingApp.Location = new System.Drawing.Point(12, 68);
			this.labelMovingApp.Name = "labelMovingApp";
			this.labelMovingApp.Size = new System.Drawing.Size(75, 13);
			this.labelMovingApp.TabIndex = 8;
			this.labelMovingApp.Text = "<Moving app>";
			// 
			// labelProgress
			// 
			this.labelProgress.AutoSize = true;
			this.labelProgress.Location = new System.Drawing.Point(12, 51);
			this.labelProgress.Name = "labelProgress";
			this.labelProgress.Size = new System.Drawing.Size(60, 13);
			this.labelProgress.TabIndex = 7;
			this.labelProgress.Text = "<Progress>";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(419, 31);
			this.label1.TabIndex = 6;
			this.label1.Text = "Moving is in progress. This will take some time at which the application will not" +
    " respond to user\'s actions.";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 86);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(419, 23);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 5;
			// 
			// MoveProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 121);
			this.ControlBox = false;
			this.Controls.Add(this.labelMovingApp);
			this.Controls.Add(this.labelProgress);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MoveProgressForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Moving progress";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelMovingApp;
		private System.Windows.Forms.Label labelProgress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar;


	}
}