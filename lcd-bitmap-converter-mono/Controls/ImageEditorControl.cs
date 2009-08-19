using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace lcd_bitmap_converter_mono
{
    public class ImageEditorControl : UserControl, IConvertorPart
    {
        private TableLayoutPanel tlpMain;
        //private TrackBar mtbBrightnessEdge;
        private BitmapEditorControl mBmpEditor;
        private Bitmap mEdgeCopy;
        private string mFileName;

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
            this.mFileName = String.Empty;
        }

        protected override void Dispose(bool disposing)
        {
            this.tlpMain.Dispose();
            base.Dispose(disposing);
        }

        //private void OnTrackBarChange(object sender, EventArgs ea)
        //{
        //    if(this.mEdgeCopy == null)
        //    {
        //        this.mEdgeCopy = this.mBmpEditor.Bmp;
        //        //MessageBox.Show("copied");
        //    }
        //    float edge = (float)this.mtbBrightnessEdge.Value / 100.0f;
        //    this.mBmpEditor.Bmp = this.GetMonochrome(this.mEdgeCopy, edge);
        //    //MessageBox.Show(edge.ToString());
        //}

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
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format1bppIndexed);

            //ImageAttributes imageAtt = new ImageAttributes();
            //imageAtt.SetColorMatrix(this.ColorMatrixBW, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            //Graphics.FromImage(bmp2).DrawImage(
            //    bmp,
            //    Rectangle.FromLTRB(0, 0, bmp2.Width, bmp2.Height),
            //    0.0f,
            //    0.0f,
            //    bmp2.Width,
            //    bmp2.Height,
            //    GraphicsUnit.Pixel,
            //    imageAtt);

            BitmapData bmd = bmp2.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    float br = bmp.GetPixel(i, j).GetBrightness();
                    //Console.WriteLine(br.ToString());
                    if (br > edge)
                        //bmp2.SetPixel(i, j, Color.White);
                        BitmapHelper.SetPixel(bmd, i, j, true);
                    else
                        //bmp2.SetPixel(i, j, Color.Black);
                        BitmapHelper.SetPixel(bmd, i, j, false);
                }
            }
            bmp2.UnlockBits(bmd);
            return bmp2;
        }

        private XmlDocument GetXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlNode root = doc.AppendChild(doc.CreateElement("data"));
            (root as XmlElement).SetAttribute("type", "image");
            (root as XmlElement).SetAttribute("filename", this.mFileName);
            (root as XmlElement).SetAttribute("name", Path.GetFileNameWithoutExtension(this.mFileName));
            //XmlNode nodeImage = root.AppendChild(doc.CreateElement("item"));
            XmlNode nodeBitmap = root.AppendChild(doc.CreateElement("bitmap"));
            this.mBmpEditor.SaveToXml(nodeBitmap);
            return doc;
        }
        private void SaveBitmapToXml(string filename)
        {
            this.mFileName = filename;
            XmlDocument doc = this.GetXmlDocument();
            doc.Save(filename);
        }

        private void LoadBitmapFromXml(string filename)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlNode root = doc.DocumentElement;
                if (root.Attributes["type"] != null)
                {
                    if (root.Attributes["type"].Value == "image")
                    {
                        XmlNode nodeBitmap = root.SelectSingleNode("bitmap");
                        if (nodeBitmap != null)
                            this.mBmpEditor.LoadFromXml(nodeBitmap);
                        else
                            throw new Exception("Invalid format of file, 'bitmap' node not found");
                    }
                    else
                        throw new Exception("Invalid format of file, attribute 'type' must be equal to 'image'");
                }
                else
                    throw new Exception("Invalid format of file, attribute 'type' not defined");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error while loading file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #region IConvertorPart
        public void LoadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.DefaultExt = ".xml";
                ofd.Filter = "Bitmaps (*.bmp)|*.bmp|Images (*.bmp; *.jpg; *.png)|*.bmp;*.png;*.jpg;*.jpeg|XML files(*.xml)|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofd.FileName;
                    string ext = Path.GetExtension(filename);
                    //MessageBox.Show(filename);
                    if (ext == ".bmp" || ext == ".jpeg" || ext == ".jpg" || ext == ".png")
                    {
                        Bitmap bmp = new Bitmap(filename);
                        //Image im = Image.FromFile(filename);
                        this.mBmpEditor.Bmp = this.GetMonochrome(bmp, 0.5f);
                    }
                    if (ext == ".xml")
                    {
                        this.LoadBitmapFromXml(filename);
                    }
                }
            }
        }
        public void SaveData()
        {
            if (String.IsNullOrEmpty(this.mFileName))
                this.SaveDataAs();
            else
            {
                string ext = Path.GetExtension(this.mFileName);
                if (ext == ".bmp")
                    this.mBmpEditor.Bmp.Save(this.mFileName);
                if (ext == ".xml")
                    this.SaveBitmapToXml(this.mFileName);
            }
        }
        public void SaveDataAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.CheckPathExists = true;
                sfd.DefaultExt = ".bmp";
                sfd.Filter = "*Bitmaps (*.bmp)|*.bmp|XML files (*.xml)|*.xml";
                sfd.OverwritePrompt = true;
                sfd.Title = "Save file...";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.mFileName = sfd.FileName;
                    this.SaveData();
                }
            }
        }
        public void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            this.mBmpEditor.RotateFlip(horizontalFlip, verticalFlip, angle);
        }
        public void Inverse()
        {
            this.mBmpEditor.Inverse();
        }
        public void Convert()
        {
            string xsltFilename = SavedContainer<Options>.Instance.ImageStyleFilename;
            if (String.IsNullOrEmpty(xsltFilename))
            {
                MessageBox.Show("Conversion not possible, because xslt file not specified.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else if (!File.Exists(xsltFilename))
            {
                MessageBox.Show("Conversion not possible, because specified xslt file not exists.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.AddExtension = true;
                        sfd.CheckPathExists = true;
                        sfd.DefaultExt = ".c";
                        sfd.Filter = "All files (*.*)|*.*";
                        sfd.OverwritePrompt = true;
                        sfd.Title = "Save file...";

                        XslCompiledTransform trans = new XslCompiledTransform();
                        trans.Load(xsltFilename);

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            XmlWriterSettings settings = new XmlWriterSettings();
                            settings.CloseOutput = true;
                            settings.ConformanceLevel = ConformanceLevel.Fragment;
                            settings.Encoding = Encoding.UTF8;
                            //settings.

                            using (XmlWriter writer = XmlWriter.Create(sfd.FileName, trans.OutputSettings))
                            {
                                XmlDocument doc = this.GetXmlDocument();
                                trans.Transform(doc, writer);
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
