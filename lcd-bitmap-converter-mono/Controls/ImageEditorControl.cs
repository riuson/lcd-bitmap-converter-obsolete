using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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
		private Bitmap mEdgeCopy;

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
			//this.tlpMain.BackColor = Color.Green;
			//TrackBar
			//this.mtbBrightnessEdge = new TrackBar();
			//this.mtbBrightnessEdge.Orientation = Orientation.Vertical;
			//this.mtbBrightnessEdge.Maximum = 100;
			//this.mtbBrightnessEdge.Minimum = 0;
			//this.mtbBrightnessEdge.TickFrequency = 10;
			//this.mtbBrightnessEdge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
			//this.tlpMain.Controls.Add(this.mtbBrightnessEdge, 0, 0);
			//this.mtbBrightnessEdge.ValueChanged += OnTrackBarChange;
			//Bitmap Editor
			this.mBmpEditor = new BitmapEditorControl();
			this.tlpMain.Controls.Add(this.mBmpEditor, 1, 0);
			this.mBmpEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			this.mEdgeCopy = null;
		}
		
		protected override void Dispose (bool disposing)
		{
			this.tlpMain.Dispose();
			base.Dispose(disposing);
		}
		
		private void OnTrackBarChange(object sender, EventArgs ea)
		{
			if(this.mEdgeCopy == null)
			{
				this.mEdgeCopy = this.mBmpEditor.Bmp;
				//MessageBox.Show("copied");
			}
			float edge = (float)this.mtbBrightnessEdge.Value / 100.0f;
			this.mBmpEditor.Bmp = this.GetMonochrome(this.mEdgeCopy, edge);
			//MessageBox.Show(edge.ToString());
		}
		
        private ColorMatrix ColorMatrixBW
        {
            get
            {
				ColorMatrix colorMatrixBW;
                float[][] matrixItemsBW ={
                    new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                    new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                    new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}};
                colorMatrixBW = new ColorMatrix(matrixItemsBW);
                return colorMatrixBW;
            }
        }

		private Bitmap GetMonochrome(Bitmap bmp, float edge)
		{
			Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
			
			ImageAttributes imageAtt = new ImageAttributes();
			imageAtt.SetColorMatrix(this.ColorMatrixBW, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			
			Graphics.FromImage(bmp2).DrawImage(
				bmp,
				Rectangle.FromLTRB(0, 0, bmp2.Width, bmp2.Height),
				0.0f,
				0.0f,
				bmp2.Width,
				bmp2.Height,
				GraphicsUnit.Pixel,
				imageAtt);
			
			for (int i = 0; i < bmp2.Width; i++)
			{
				for (int j = 0; j < bmp2.Height; j++)
				{
					float br = bmp2.GetPixel(i, j).GetBrightness();
					//Console.WriteLine(br.ToString());
					if(br > edge)
						bmp2.SetPixel(i, j, Color.Transparent);
					else
						bmp2.SetPixel(i, j, Color.Black);
				}
			}
			return bmp2;
		}

		#region IConvertorPart
		public void LoadData()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;
			ofd.DefaultExt = ".xml";
			ofd.Filter = "XML files(*.xml)|*.xml|Bitmaps (*.bmp)|*.bmp|Images (*.bmp; *.jpg; *.png)|*.bmp;*.png;*.jpg;*.jpeg";
			if(ofd.ShowDialog() == DialogResult.OK)
			{
				string filename = ofd.FileName;
				string ext = Path.GetExtension(filename);
				//MessageBox.Show(filename);
				if(ext == ".bmp" || ext == ".jpeg" || ext == ".jpg" || ext == ".png")
				{
					Bitmap bmp = new Bitmap(filename);
					//Image im = Image.FromFile(filename);
					this.mBmpEditor.Bmp = this.GetMonochrome(bmp, 0.5f);
				}
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
