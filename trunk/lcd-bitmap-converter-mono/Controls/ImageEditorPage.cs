using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace lcd_bitmap_converter_mono
{
    public class ImageEditorPage : TabPage, IConvertorPart
    {
        private ImageEditorControl mEditor;
        private string mFileName;
    
        public ImageEditorPage()
        {
            this.mEditor = new ImageEditorControl();
            this.Controls.Add(this.mEditor);
            this.mEditor.Dock = DockStyle.Fill;
            this.mFileName = String.Empty;
        }
        protected override void Dispose (bool disposing)
        {
            this.mEditor.Dispose();
            base.Dispose (disposing);
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
                        using (FormColor2BW formC2BW = new FormColor2BW())
                        {
                            formC2BW.ImageOriginal = bmp;
                            if (formC2BW.ShowDialog() == DialogResult.OK)
                            {
                                this.mEditor.BmpEditor.Bmp = formC2BW.ImageResult;
                                this.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                                this.mFileName = ofd.FileName;
                            }
                        }
                    }
                    if (ext == ".xml")
                    {
                        this.LoadBitmapFromXml(filename);
                        this.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                        this.mFileName = ofd.FileName;
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
                    this.mEditor.BmpEditor.Bmp.Save(this.mFileName);
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
            this.mEditor.BmpEditor.RotateFlip(horizontalFlip,  verticalFlip, angle);
        }
        public void Inverse()
        {
            this.mEditor.BmpEditor.Bmp = BitmapHelper.Inverse(this.mEditor.BmpEditor.Bmp);
            this.mEditor.BmpEditor.Invalidate();
        }
        public void ConvertData()
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
                            using (XmlWriter writer = XmlWriter.Create(sfd.FileName, trans.OutputSettings))
                            {
                                XmlDocument doc = this.GetXmlDocument(
                                    SavedContainer<Options>.Instance.OperationFlipHorizontal,
                                    SavedContainer<Options>.Instance.OperationFlipVertical,
                                    SavedContainer<Options>.Instance.OperationRotateAngle,
                                    SavedContainer<Options>.Instance.InverseColors);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ImageEditorPage
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);

        }

        private void SaveBitmapToXml(string filename)
        {
            this.mFileName = filename;
            XmlDocument doc = this.GetXmlDocument(false, false, RotateAngle.None, false);
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
                            this.mEditor.BmpEditor.LoadFromXml(nodeBitmap);
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
        private XmlDocument GetXmlDocument(bool flipHorizontal, bool flipVertical, RotateAngle angle, bool inverse)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlNode root = doc.AppendChild(doc.CreateElement("data"));
            (root as XmlElement).SetAttribute("type", "image");
            (root as XmlElement).SetAttribute("filename", this.mFileName);
            (root as XmlElement).SetAttribute("name", Path.GetFileNameWithoutExtension(this.mFileName));

            XmlNode nodeDefinitions = root.AppendChild(doc.CreateElement("definitions"));
            for (int i = 0; i < 256; i++)
            {
                XmlNode nodeValue = nodeDefinitions.AppendChild(doc.CreateElement("value"));
                (nodeValue as XmlElement).SetAttribute("text", Convert.ToString(i, 2).PadLeft(8, '0'));
                (nodeValue as XmlElement).SetAttribute("byte", String.Format("{0:X2}", i));
            }

            //XmlNode nodeImage = root.AppendChild(doc.CreateElement("item"));
            XmlNode nodeBitmap = root.AppendChild(doc.CreateElement("bitmap"));
            this.mEditor.BmpEditor.SaveToXml(nodeBitmap, flipHorizontal, flipVertical, angle, inverse);
            return doc;
        }
    }
}
