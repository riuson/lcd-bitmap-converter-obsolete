using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Xml;
using System.IO;
using System.Xml.Xsl;

namespace lcd_bitmap_converter_mono
{
    public partial class ImageEditorControl : UserControl
    {
        public ImageEditorControl()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (sender == this.bShrink)
            {
                Rectangle rect = BitmapHelper.CalcShrink(this.BmpEditor.Bmp);
                this.numLeft.Value = -rect.X;
                this.numTop.Value = -rect.Y;
                this.numRight.Value = -(this.BmpEditor.Bmp.Width - rect.Width - rect.X);
                this.numBottom.Value = -(this.BmpEditor.Bmp.Height - rect.Height - rect.Y);
            }
            if (sender == this.bApplyResize)
            {
                int left = Convert.ToInt32(this.numLeft.Value);
                int top = Convert.ToInt32(this.numTop.Value);
                int right = Convert.ToInt32(this.numRight.Value);
                int bottom = Convert.ToInt32(this.numBottom.Value);

                this.BmpEditor.Bmp = BitmapHelper.Resize(this.BmpEditor.Bmp, left, top, right, bottom);
            }
            if (sender == this.bImport)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.CheckFileExists = true;
                    ofd.CheckPathExists = true;
                    ofd.DefaultExt = ".*";
                    ofd.Filter = "Windows Bitmap (*.bmp)|*.bmp";
                    ofd.Title = "Open image file";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string filename = ofd.FileName;
                        Bitmap bmp = new Bitmap(filename);
                        using (FormColor2BW formC2BW = new FormColor2BW())
                        {
                            formC2BW.ImageOriginal = bmp;
                            if (formC2BW.ShowDialog() == DialogResult.OK)
                            {
                                this.BmpEditor.Bmp = formC2BW.ImageResult;
                            }
                        }
                    }
                }
            }
            if (sender == this.bExport)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.AddExtension = true;
                    sfd.CheckPathExists = true;
                    sfd.DefaultExt = ".*";
                    sfd.Filter = "Windows Bitmap (*.bmp)|*.bmp";
                    sfd.OverwritePrompt = true;
                    sfd.Title = "Save image file...";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        this.BmpEditor.Bmp.Save(sfd.FileName);
                    }
                }
            }
        }
    }
}
