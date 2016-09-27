using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteamLibraryManager.Controls
{
	public partial class LibraryGroup : UserControl
	{
		private SteamData steamData;

		public SteamData SteamData
		{
			get
			{
				return steamData;
			}
			set
			{
				if (steamData != value)
				{
					steamData = value;
					OnSteamDataChanged();
				}
			}
		}


		public LibraryGroup()
		{
			InitializeComponent();

			// Remove the existing columns.
			layout.ColumnCount = 0;
			layout.ColumnStyles.Clear();
		}


		protected virtual void OnSteamDataChanged()
		{
			// Remove the existing views.
			if (layout.ColumnCount > 0)
			{
				layout.Controls.Clear();
				layout.ColumnStyles.Clear();
				layout.ColumnCount = 0;
			}

			// Create new library views.
			if (steamData != null)
			{
				foreach (SteamLibrary library in steamData.Libraries)
				{
					layout.ColumnCount += 1;
					layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / steamData.Libraries.Count));

					// Create library view.
					LibraryView libraryView = CreateLibraryView(library);
					layout.SetColumn(libraryView, layout.ColumnCount - 1);
				}
			}
		}


		private LibraryView CreateLibraryView(SteamLibrary library)
		{
			LibraryView libraryView = new LibraryView(SteamData, library);
			libraryView.Parent = layout;
			libraryView.Dock = DockStyle.Fill;
			libraryView.Margin = new Padding(3, 3, 0, 3);

			return libraryView;
		}
	}
}
