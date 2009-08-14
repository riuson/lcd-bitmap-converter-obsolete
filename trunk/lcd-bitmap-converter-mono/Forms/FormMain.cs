using System;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
	public class FormMain : Form
	{
		#region controls
		private MenuStrip mMainMenu;
		private TabControl tcMain;
		#endregion
		
		public FormMain()
		{
			#region MainMenu
			this.mMainMenu = new MenuStrip();
			this.Controls.Add(this.mMainMenu);
			this.mMainMenu.Dock = DockStyle.Top;

			//item "File"
			ToolStripDropDownButton tsddb = new ToolStripDropDownButton("File");
			this.mMainMenu.Items.Add(tsddb);
			
			//item "File -> New Image"
			ToolStripMenuItem tsmi = new ToolStripMenuItem("New Image");
			tsmi.Name = "New Image";
			tsmi.Click += this.OnMenuItemClick;
			tsddb.DropDownItems.Add(tsmi);
			
			//item "File -> New Font"
			tsmi = new ToolStripMenuItem("New Font");
			tsmi.Name = "New Font";
			tsmi.Click += this.OnMenuItemClick;
			tsddb.DropDownItems.Add(tsmi);
			
			//item "File -> Open"
			tsmi = new ToolStripMenuItem("Open...");
			tsmi.Name = "Open";
			tsmi.Click += this.OnMenuItemClick;
			tsddb.DropDownItems.Add(tsmi);
			
			//item "File -> Save"
			tsmi = new ToolStripMenuItem("Save");
			tsmi.Name = "Save";
			tsmi.Click += this.OnMenuItemClick;
			tsddb.DropDownItems.Add(tsmi);
			
			//item "File -> Save As"
			tsmi = new ToolStripMenuItem("Save As...");
			tsmi.Name = "Save As";
			tsmi.Click += this.OnMenuItemClick;
			tsddb.DropDownItems.Add(tsmi);
			
			//item "File -> Exit"
			tsmi = new ToolStripMenuItem("Quit");
			tsmi.Name = "Quit";
			tsmi.Click += this.OnMenuItemClick;
			tsddb.DropDownItems.Add(tsmi);

			//item "Operation"
			tsddb = new ToolStripDropDownButton("Operation");
			this.mMainMenu.Items.Add(tsddb);
			
			//item "Operation -> Flip/Rotate"
			tsmi = new ToolStripMenuItem("Flip/Rotate...");
			tsmi.Name = "FlipRotate";
			tsmi.Click += this.OnMenuItemClick;
			tsddb.DropDownItems.Add(tsmi);
			
			#endregion
			
			#region TabControl
			this.tcMain = new TabControl();
			this.Controls.Add(this.tcMain);
			this.tcMain.Dock = DockStyle.Fill;
			this.tcMain.BringToFront();
			
			//TabPage page=  new TabPage("Image");
			//page.Controls.Add(new BitmapEditorControl());
			//this.tcMain.TabPages.Add(page);
			#endregion
		}
		
		protected override void Dispose (bool disposing)
		{
			//
			base.Dispose(disposing);
		}
		private void OnMenuItemClick(object sender, EventArgs ea)
		{
			try
			{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			if(tsmi != null)
			{
				switch (tsmi.Name)
				{
					case "Quit":
						this.Close();
						break;
					case "New Image":
					{
						//TabPage page = new TabPage("New Image");
						//this.tcMain.TabPages.Add(page);
						//ImageEditorControl editor = new ImageEditorControl();
						//page.Controls.Add(editor);
						//editor.Dock = DockStyle.Fill;
						ImageEditorPage page = new ImageEditorPage();
						this.tcMain.TabPages.Add(page);
						page.Text = "New Image";
						break;
					}
					case "Open":
					{
						if(this.tcMain.SelectedTab != null &&
						   this.tcMain.SelectedTab is IConvertorPart)
						{
							(this.tcMain.SelectedTab as IConvertorPart).LoadData();
						}
						break;
					}
					case "Save":
					{
						if(this.tcMain.SelectedTab != null &&
						   this.tcMain.SelectedTab is IConvertorPart)
						{
							(this.tcMain.SelectedTab as IConvertorPart).SaveData();
						}
						break;
					}
					case "FlipRotate":
					{
						if(this.tcMain.SelectedTab != null &&
						   this.tcMain.SelectedTab is IConvertorPart)
						{
							using(FormSwap form = new FormSwap())
							{
								if(form.ShowDialog() == DialogResult.OK)
								{
									(this.tcMain.SelectedTab as IConvertorPart).RotateFlip(
										form.FlipHorizontal,
										form.FlipVertical,
										form.Angle);
								}
							}
						}
						break;
					}
					default:
						break;
				}
			}
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message + "\n" + exc.StackTrace);
			}
		}

//        private void InitializeComponent()
//        {
//            this.SuspendLayout();
//            // 
//            // FormMain
//            // 
//            this.ClientSize = new System.Drawing.Size(295, 266);
//            this.Name = "FormMain";
//            this.ResumeLayout(false);
//
//        }
	}
}
