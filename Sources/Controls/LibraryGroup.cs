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
		private IList<SteamLibrary> libraries;

		public IList<SteamLibrary> Libraries
		{
			get
			{
				return libraries;
			}
			set
			{
				if (libraries != value)
				{
					libraries = value;
					OnLibrariesChanged();
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


		protected virtual void OnLibrariesChanged()
		{
			// Remove the existing views.
			if (layout.ColumnCount > 0)
			{
				layout.ColumnCount = 0;
				layout.ColumnStyles.Clear();
			}

			// Create new library views.
			if (libraries != null)
			{
				foreach (SteamLibrary library in Libraries)
				{
					layout.ColumnCount += 1;
					layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / libraries.Count));

					// Create library view.
					LibraryView libraryView = CreateLibraryView(library);
					layout.SetColumn(libraryView, layout.ColumnCount - 1);
				}
			}
		}


		private LibraryView CreateLibraryView(SteamLibrary library)
		{
			LibraryView libraryView = new LibraryView(library);
			libraryView.Parent = layout;
			libraryView.Dock = DockStyle.Fill;
			libraryView.Margin = new Padding(3, 3, 0, 3);

			return libraryView;
		}
	}
}
