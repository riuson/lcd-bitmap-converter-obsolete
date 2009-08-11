using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public class ImageEditorControl : UserControl, IConvertorPart
    {
		private TableLayoutPanel tlpMain;
		private TrackBar mtbBrightnessEdge;
		private BitmapEditorControl mBmpEditor;

        public ImageEditorControl()
        {
			//TableLayoutControl
			this.tlpMain = new TableLayoutPanel();
			this.Controls.Add(this.tlpMain);
			this.tlpMain.Dock = DockStyle.Fill;
			this.tlpMain.ColumnStyles.Clear();
			this.tlpMain.RowStyles.Clear();
			this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));
			this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
			this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
			this.tlpMain.BackColor = Color.Green;
			//TrackBar
			this.mtbBrightnessEdge = new TrackBar();
			this.mtbBrightnessEdge.Orientation = Orientation.Vertical;
			this.mtbBrightnessEdge.Maximum = 100;
			this.mtbBrightnessEdge.Minimum = 0;
			this.mtbBrightnessEdge.TickFrequency = 10;
			this.mtbBrightnessEdge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
			this.tlpMain.Controls.Add(this.mtbBrightnessEdge, 0, 0);
			//Bitmap Editor
			this.mBmpEditor = new BitmapEditorControl();
			this.tlpMain.Controls.Add(this.mBmpEditor, 1, 0);
			this.mBmpEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
		}
		
		protected override void Dispose (bool disposing)
		{
			this.tlpMain.Dispose();
			base.Dispose(disposing);
		}

		#region IConvertorPart
		public void LoadData()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;
			ofd.DefaultExt = ".xml";
			ofd.Filter = "XML files(*.xml)|*.xml|Bitmaps (*.bmp)|*.bmp";
			if(ofd.ShowDialog() == DialogResult.OK)
			{
			}
		}
		public void SaveData()
		{
		}
		public void SaveDataAs()
		{
		}
		#endregion
	}
}
