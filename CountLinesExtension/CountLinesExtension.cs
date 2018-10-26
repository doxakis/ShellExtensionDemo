using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountLinesExtension
{
	[ComVisible(true)]
	[COMServerAssociation(AssociationType.ClassOfExtension, ".txt")]
	public class CountLinesExtension : SharpContextMenu
	{
		protected override bool CanShowMenu()
		{
			//  We will always show the menu.
			return true;
		}
		
		protected override ContextMenuStrip CreateMenu()
		{
			//  Create the menu strip.
			var menu = new ContextMenuStrip();

			//  Create a 'count lines' item.
			var itemCountLines = new ToolStripMenuItem
			{
				Text = "Count Lines",
				Image = Resource.icon
			};

			//  When we click, we'll call the 'CountLines' function.
			itemCountLines.Click += (sender, args) => CountLines();

			//  Add the item to the context menu.
			menu.Items.Add(itemCountLines);

			//  Return the menu.
			return menu;
		}

		private void CountLines()
		{
			//  Builder for the output.
			var builder = new StringBuilder();

			//  Go through each file.
			foreach (var filePath in SelectedItemPaths)
			{
				//  Count the lines.
				builder.AppendLine(string.Format("{0} - {1} Lines",
				  Path.GetFileName(filePath), File.ReadAllLines(filePath).Length));
			}

			//  Show the ouput.
			MessageBox.Show(builder.ToString());
		}
	}
}
