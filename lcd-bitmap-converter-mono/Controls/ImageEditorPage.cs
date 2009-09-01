using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace lcd_bitmap_converter_mono
{
    public class ImageEditorPage : EditorPageBase
    {
        private ImageEditorControl mEditor;

        public ImageEditorPage()
        {
            this.mEditor = new ImageEditorControl();
            this.Controls.Add(this.mEditor);
            this.mEditor.Dock = DockStyle.Fill;

            this.mFileDialogFilter = "XML files(*.xml)|*.xml|Images (*.bmp; *.jpg; *.png)|*.bmp;*.png;*.jpg;*.jpeg";
        }
        protected override void Dispose(bool disposing)
        {
            this.mEditor.Dispose();
            base.Dispose(disposing);
        }

        #region IConvertorPart
        public override void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            this.mEditor.BmpEditor.RotateFlip(horizontalFlip, verticalFlip, angle);
        }
        public override void Inverse()
        {
            this.mEditor.BmpEditor.Bmp = BitmapHelper.Inverse(this.mEditor.BmpEditor.Bmp);
            this.mEditor.BmpEditor.Invalidate();
        }
        public override void ConvertData()
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
                                    SavedContainer<Options>.Instance.XmlSavingOptions);
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
        protected override FileProcessor GetReadProcessor(string extension)
        {
            if (extension == ".xml")
                return this.LoadBitmapFromXml;
            if (extension == ".bmp" || extension == ".jpeg" || extension == ".jpg" || extension == ".png")
                return this.LoadBitmapFromImageFile;
            return base.GetReadProcessor(extension);
        }
        protected override FileProcessor GetWriteProcessor(string extension)
        {
            if (extension == ".xml")
                return this.SaveBitmapToXml;
            if (extension == ".bmp" || extension == ".jpeg" || extension == ".jpg" || extension == ".png")
                return this.SaveBitmapToImageFile;
            return base.GetReadProcessor(extension);
        }

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

        private bool SaveBitmapToXml(string filename)
        {
            this.mFileName = filename;
            XmlDocument doc = this.GetXmlDocument(new XmlSavingOptions());
            doc.Save(filename);
            return true;
        }
        private bool SaveBitmapToImageFile(string filename)
        {
            this.mEditor.BmpEditor.Bmp.Save(this.mFileName);
            return true;
        }
        private bool LoadBitmapFromXml(string filename)
        {
            bool result = false;
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
                        {
                            this.mEditor.BmpEditor.Bmp = BitmapHelper.LoadFromXml(nodeBitmap);
                            result = true;
                        }
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
            return result;
        }
        private bool LoadBitmapFromImageFile(string filename)
        {
            bool result = false;
            Bitmap bmp = new Bitmap(filename);
            using (FormColor2BW formC2BW = new FormColor2BW())
            {
                formC2BW.ImageOriginal = bmp;
                if (formC2BW.ShowDialog() == DialogResult.OK)
                {
                    this.mEditor.BmpEditor.Bmp = formC2BW.ImageResult;
                    this.Text = Path.GetFileNameWithoutExtension(filename);
                    this.mFileName = filename;
                }
            }
            return result;
        }
        private XmlDocument GetXmlDocument(XmlSavingOptions options)
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
            BitmapHelper.SaveToXml(this.mEditor.BmpEditor.Bmp, nodeBitmap, options);
            return doc;
        }
    }
}
