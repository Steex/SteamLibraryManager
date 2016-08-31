using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteamLibraryManager
{
	public partial class OptionsForm : Form
	{
		public Config LocalConfig { get; private set; }


		public OptionsForm(Config configCopy)
		{
			InitializeComponent();

			LocalConfig = configCopy;

			// Prepare Steam settings.
			textSteamPath.Text = LocalConfig.SteamPath;

			// Allow exiting without saving of an incorrect data.
			buttonCancel.CausesValidation = false;

			// Limit resizing by the current size.
			MinimumSize = Size;

			// Assign tooltips.
			toolTip.SetToolTip(textSteamPath, "Path to the Steam installation folder.");
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			ProcessValidationError(textSteamPath, "");

			// Check the Steam location.
			string enteredSteamPath = textSteamPath.Text.Trim();
			if (!string.IsNullOrEmpty(enteredSteamPath))
			{
				if (!Directory.Exists(enteredSteamPath))
				{
					ProcessValidationError(textSteamPath, "Cannot find the Steam directory.");
					return;
				}

				// Check the converter directory have Steam executable.
				if (!File.Exists(Path.Combine(enteredSteamPath, "Steam.exe")))
				{
					ProcessValidationError(textSteamPath, "Cannot find the Steam executable in the specified directory.");
					return;
				}
			}

			// Store the library data.
			LocalConfig.SteamPath = enteredSteamPath;

			// Close the form.
			DialogResult = DialogResult.OK;
			Close();
		}

		
		private void ValidateControl(Control control, CancelEventHandler onValidating, EventHandler onValidated)
		{
			CancelEventArgs validatingArgs = new CancelEventArgs();
			
			if (onValidating != null)
			{
				onValidating(control, validatingArgs);
			}

			if (onValidated != null && !validatingArgs.Cancel)
			{
				onValidated(control, EventArgs.Empty);
			}
		}

		private void ProcessValidationError(Control control, string message)
		{
			bool isValid = string.IsNullOrEmpty(message);

			labelError.Visible = !isValid;
			labelError.Text = isValid ? "" : message;

			if (control != null)
			{
				control.BackColor = isValid ? SystemColors.Window : Color.FromArgb(255, 191, 191);
			}
		}


		private void textLibrarySourceRoot_Validating(object sender, CancelEventArgs e)
		{
			// Check the source root is in correct format (but allow empty paths).
			string enteredSteamPath = textSteamPath.Text.Trim();
			if (enteredSteamPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
			{
				ProcessValidationError(textSteamPath, "The source path is invalid.");
				e.Cancel = true;
				return;
			}

			// Hide an error message.
			ProcessValidationError(textSteamPath, "");
		}

		private void textLibrarySourceRoot_Validated(object sender, EventArgs e)
		{
		}

		private void textLibrarySourceRoot_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				ValidateControl(textSteamPath, textLibrarySourceRoot_Validating, textLibrarySourceRoot_Validated);
			}
		}
	}
}
