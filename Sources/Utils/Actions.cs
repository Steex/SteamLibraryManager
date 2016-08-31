using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SteamLibraryManager
{
	public class Action
	{
		public event EventHandler Execute;
		public event EventHandler Update;

		private EventHandler executeHandler;

		private static Hashtable actionList;

		private List<ToolStripItem> toolItems;

		private bool visible = true;
		private bool enabled = true;
		private bool checkedFlag = false;
		private string text;
		private string toolTip;
		private Keys shortcutKeys;


		public bool Visible
		{
			get
			{
				return visible;
			}
			set
			{
				if (visible == value)
				{
					return;
				}
				visible = value;
				OnVisibleChanged(EventArgs.Empty);
			}
		}

		public bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				if (enabled == value)
				{
					return;
				}
				enabled = value;
				OnEnabledChanged(EventArgs.Empty);
			}
		}

		public bool Checked
		{
			get
			{
				return checkedFlag;
			}
			set
			{
				/*if (checkedFlag == value)
				{
					return;
				}/**/
				checkedFlag = value;
				OnCheckedChanged(EventArgs.Empty);
			}
		}

		public string Text
		{
			get
			{
				return text;
			}
			set
			{
				if (text == value)
				{
					return;
				}
				text = value == null ? "" : value;
				OnTextChanged(EventArgs.Empty);
			}
		}

		public string ToolTip
		{
			get
			{
				return toolTip;
			}
			set
			{
				if (toolTip == value)
				{
					return;
				}
				toolTip = value;
				OnToolTipChanged(EventArgs.Empty);
			}
		}

		public Keys ShortcutKeys
		{
			get
			{
				return shortcutKeys;
			}
			set
			{
				if (shortcutKeys == value)
				{
					return;
				}
				shortcutKeys = value;
				OnShortcutKeysChanged(EventArgs.Empty);
			}
		}


		static Action()
		{
			actionList = new Hashtable();
		}

		public Action() : this("unnamed", null, Keys.None)
		{
		}

		public Action(string text) : this(text, null, Keys.None)
		{
		}

		public Action(string text, string toolTip) : this(text, toolTip, Keys.None)
		{
		}

		public Action(string text, string toolTip, Keys shortkutKeys)
		{
			actionList.Add(this, null);

			toolItems = new List<ToolStripItem>();

			executeHandler = new EventHandler(OnExecute);

			this.text = text;
			this.toolTip = toolTip;
			this.shortcutKeys = shortkutKeys;
		}

		~Action()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				foreach (ToolStripItem item in toolItems)
				{
					item.Click -= executeHandler;
				}

				toolItems.Clear();

				actionList.Remove(this);
			}
		}


		public static void PerformToolbarButtonAction(object sender, ToolBarButtonClickEventArgs e)
		{
			object action = e.Button.Tag;
			if (action is Action)
			{
				(action as Action).OnExecute(sender, e);
			}
		}

		public static void UpdateActions(EventArgs e)
		{
			foreach (Action action in actionList.Keys)
			{
				action.OnUpdate(action, e);
			}
		}


		public void Perform(object sender, EventArgs e)
		{
			OnExecute(sender, e);
		}


		public void AttachToolItem(ToolStripItem item)
		{
			if (item != null && !toolItems.Contains(item))
			{
				toolItems.Add(item);

				item.Visible = Visible;
				item.Enabled = Enabled;
				item.Text = Text;

				// Assign the click handler.
				if (item is ToolStripSplitButton)
				{
					(item as ToolStripSplitButton).ButtonClick += executeHandler;
				}
				else
				{
					item.Click += executeHandler;
				}

				if (item is ToolStripMenuItem)
				{
					(item as ToolStripMenuItem).Checked = Checked;
					(item as ToolStripMenuItem).ShortcutKeys = ShortcutKeys;
				}
				else
				{
					item.ToolTipText = GetToolTipText();
				}

				if (item is ToolStripButton)
				{
					(item as ToolStripButton).Checked = Checked;
				}
			}
		}

		public void DetachToolItem(ToolStripItem item)
		{
			if (item != null && toolItems.Contains(item))
			{
				toolItems.Remove(item);

				// Remove the click handler.
				if (item is ToolStripSplitButton)
				{
					(item as ToolStripSplitButton).ButtonClick -= executeHandler;
				}
				else
				{
					item.Click -= executeHandler;
				}
			}
		}


		protected virtual void OnVisibleChanged(EventArgs e)
		{
			foreach (ToolStripItem item in toolItems)
			{
				item.Visible = Visible;
			}
		}

		protected virtual void OnEnabledChanged(EventArgs e)
		{
			foreach (ToolStripItem item in toolItems)
			{
				item.Enabled = Enabled;
			}
		}

		protected virtual void OnCheckedChanged(EventArgs e)
		{
			foreach (ToolStripItem item in toolItems)
			{
				if (item is ToolStripMenuItem)
				{
					(item as ToolStripMenuItem).Checked = Checked;
				}

				if (item is ToolStripButton)
				{
					(item as ToolStripButton).Checked = Checked;
				}
			}
		}

		protected virtual void OnTextChanged(EventArgs e)
		{
			foreach (ToolStripItem item in toolItems)
			{
				item.Text = Text;

				if (!(item is ToolStripMenuItem))
				{
					item.ToolTipText = GetToolTipText();
				}
			}
		}

		protected virtual void OnToolTipChanged(EventArgs e)
		{
			foreach (ToolStripItem item in toolItems)
			{
				if (!(item is ToolStripMenuItem))
				{
					item.ToolTipText = GetToolTipText();
				}
			}
		}

		protected virtual void OnShortcutKeysChanged(EventArgs e)
		{
			foreach (ToolStripItem item in toolItems)
			{
				if (item is ToolStripMenuItem)
				{
					(item as ToolStripMenuItem).ShortcutKeys = ShortcutKeys;
				}
			}
		}


		private void OnExecute(object sender, EventArgs e)
		{
			if (Execute != null)
			{
				Execute(sender, e);
			}

			UpdateActions(EventArgs.Empty);
		}

		private void OnUpdate(object sender, EventArgs e)
		{
			if (Update != null)
			{
				Update(sender, e);
			}
		}


		private string GetToolTipText()
		{
			if (ToolTip == null || ToolTip.Length == 0)
			{
				return text;
			}
			else
			{
				return toolTip;
			}
		}
	}

}
