using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiffSelector
{
	class Program
	{
		static void Main(string[] args)
		{
			string fileName = "";
			string arguments = "";

			try
			{
				if(args.Length < 4)
				{
					throw new ArgumentException();
				}

				if(args[0] != "/diffViewer1")
				{
					throw new ArgumentException();
				}

				int startDiffViewer2 = -1;
				for(int i = 1; i < args.Length; i++)
				{
					if(args[i] == "/diffViewer2")
					{
						startDiffViewer2 = i;
						break;
					}
				}

				if(startDiffViewer2 < 0)
				{
					throw new ArgumentException();
				}

				int viewerIndex = 1;
				int nextViewerIndex = startDiffViewer2;
				if((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
				{
					viewerIndex = startDiffViewer2 + 1;
					nextViewerIndex = args.Length;
				}

				fileName = args[viewerIndex];

				int numArguments = nextViewerIndex - viewerIndex - 1;
				for(int i = 0; i < numArguments; i++)
				{
					if(i > 0)
					{
						arguments += " ";
					}

					arguments += "\"" + args[viewerIndex + 1 + i] + "\"";
				}
			}
			catch(ArgumentException)
			{
				MessageBox.Show("Usage: DiffSelector.exe /diffViewer1 <external diff viewer 1 cmd line> /diffViewer2 <external diff viewer 2 cmd line>\n\n" +
					"Put path inside double quotes (\") if it contains spaces!\n\nExample:\n" +
					"DiffSelector.exe /diffViewer1 \"C:\\Selectron\\VisualDiff.exe\" -lf %base -rf %mine -lft %bname -rft %yname " +
					"/diffViewer2 \"C:\\Program Files\\Beyond Compare 5\\BComp.exe\" %base %mine /title1=%bname /title2=%yname /leftreadonly", "DiffSelector");
				return;
			}

			try
			{
				Process.Start(fileName, arguments);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Cannot start diff viewer:\n" + ex.Message, "DiffSelector", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
