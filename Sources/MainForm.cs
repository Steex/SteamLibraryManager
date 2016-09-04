using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace SteamLibraryManager
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitializeActions();

			SteamData steamData = new SteamData(Config.Main.SteamPath);
		}
	}
}
