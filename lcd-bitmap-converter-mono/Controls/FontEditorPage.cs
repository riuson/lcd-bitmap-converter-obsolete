using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Xml.Xsl;

namespace lcd_bitmap_converter_mono
{
    public class FontEditorPage : EditorPageBase
    {
        private FontEditorControl mFontEdCtrl;

        public FontEditorPage()
            : base()
        {
            this.mFontEdCtrl = new FontEditorControl();
            this.Controls.Add(this.mFontEdCtrl);
            this.mFontEdCtrl.Dock = DockStyle.Fill;
        }
        protected override void Dispose(bool disposing)
        {
            this.mFontEdCtrl.Dispose();
            base.Dispose(disposing);
        }

        public override void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            this.mFontEdCtrl.ImageEditor.BmpEditor.RotateFlip(horizontalFlip, verticalFlip, angle);
        }

        public override void Inverse()
        {
            this.mFontEdCtrl.ImageEditor.BmpEditor.Bmp = BitmapHelper.Inverse(this.mFontEdCtrl.ImageEditor.BmpEditor.Bmp);
        }

        public override void ConvertData()
        {
            string xsltFilename = SavedContainer<Options>.Instance.FontStyleFilename;
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
                                writer.Close();
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

        protected override FileProcessor GetReadProcessor(string extension)
        {
            if (extension == ".xml")
                return LoadFontFromXml;
            return null;
        }
        protected override FileProcessor GetWriteProcessor(string extension)
        {
            if (extension == ".xml")
                return SaveFontToXml;
            return null;
        }

        private bool SaveFontToXml(string filename)
        {
            XmlDocument doc = this.GetXmlDocument(new XmlSavingOptions());
            doc.Save(filename);
            return true;
        }
        private bool LoadFontFromXml(string filename)
        {
            bool result = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlNode root = doc.DocumentElement;
                if (root.Attributes["type"] != null)
                {
                    if (root.Attributes["type"].Value == "font")
                    {
                        XmlNodeList nodesChar = root.SelectNodes("chars/char");
                        if (nodesChar != null && nodesChar.Count > 0)
                        {
                            List<byte> bytes = new List<byte>();
                            this.mFontEdCtrl.FontContainer.CharBitmaps.Clear();
                            foreach (XmlNode nodeChar in nodesChar)
                            {
                                XmlNodeList nodeEncodingBytes = nodeChar.SelectNodes("encoding[@codepage=65001]/bytes/byte");
                                bytes.Clear();
                                foreach (XmlNode nodeByte in nodeEncodingBytes)
                                {
                                    bytes.Add(Convert.ToByte(nodeByte.InnerText, 16));
                                }
                                char c = Encoding.UTF8.GetString(bytes.ToArray())[0];

                                XmlNode nodeBitmap = nodeChar["bitmap"];
                                Bitmap charBitmap = BitmapHelper.LoadFromXml(nodeBitmap);
                                this.mFontEdCtrl.FontContainer.CharBitmaps.Add(c, charBitmap);
                            }

                            if (root["family"] != null)
                                this.mFontEdCtrl.FontContainer.FontFamily = root["family"].InnerText;
                            if (root["size"] != null)
                                this.mFontEdCtrl.FontContainer.Size = Convert.ToInt32(root["size"].InnerText, CultureInfo.InvariantCulture);
                            if (root["style"] != null)
                                this.mFontEdCtrl.FontContainer.Style = (FontStyle)Enum.Parse(typeof(FontStyle), root["style"].InnerText);

                            this.mFontEdCtrl.ApplyContainer();
                            result = true;
                        }
                        else
                            throw new Exception("Invalid format of file, 'char' nodes not found");
                    }
                    else
                        throw new Exception("Invalid format of file, attribute 'type' must be equal to 'font'");
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
        private XmlDocument GetXmlDocument(XmlSavingOptions options)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlNode root = doc.AppendChild(doc.CreateElement("data"));
            (root as XmlElement).SetAttribute("type", "font");
            (root as XmlElement).SetAttribute("filename", this.mFileName);
            (root as XmlElement).SetAttribute("name", Path.GetFileNameWithoutExtension(this.mFileName));

            //(root as XmlElement).SetAttribute("family", this.mFontEdCtrl.FontContainer.FontFamily);
            //(root as XmlElement).SetAttribute("size", Convert.ToString(this.mFontEdCtrl.FontContainer.Size, CultureInfo.InvariantCulture));
            //string stylestr = Enum.Format(typeof(FontStyle), this.mFontEdCtrl.FontContainer.Style, "g");
            //(root as XmlElement).SetAttribute("style", stylestr);
            //FontStyle fs = (FontStyle)Enum.Parse(typeof(FontStyle), stylestr);
            root.AppendChild(doc.CreateElement("family")).InnerText = this.mFontEdCtrl.FontContainer.FontFamily;
            root.AppendChild(doc.CreateElement("size")).InnerText = Convert.ToString(this.mFontEdCtrl.FontContainer.Size, CultureInfo.InvariantCulture);
            root.AppendChild(doc.CreateElement("style")).InnerText = Enum.Format(typeof(FontStyle), this.mFontEdCtrl.FontContainer.Style, "g"); ;
            XmlNode nodeCharset = root.AppendChild(doc.CreateElement("string"));

            XmlNode nodeDefinitions = root.AppendChild(doc.CreateElement("definitions"));
            for (int i = 0; i < 256; i++)
            {
                XmlNode nodeValue = nodeDefinitions.AppendChild(doc.CreateElement("value"));
                (nodeValue as XmlElement).SetAttribute("text", Convert.ToString(i, 2).PadLeft(8, '0'));
                (nodeValue as XmlElement).SetAttribute("byte", String.Format("{0:X2}", i));
            }
            StringBuilder allChars = new StringBuilder();
            XmlNode nodeChars = root.AppendChild(doc.CreateElement("chars"));
            foreach (char c in this.mFontEdCtrl.FontContainer.CharBitmaps.Keys)
            {
                allChars.Append(c);
                XmlNode nodeChar = nodeChars.AppendChild(doc.CreateElement("char"));
                (nodeChar as XmlElement).SetAttribute("character", Convert.ToString(c));
                //(nodeChar as XmlElement).SetAttribute("unicode", this.Bytes2String(Encoding.Unicode.GetBytes(new char[] { c })));
                //(nodeChar as XmlElement).SetAttribute("utf7", this.Bytes2String(Encoding.UTF7.GetBytes(new char[] { c })));
                //(nodeChar as XmlElement).SetAttribute("utf8", this.Bytes2String(Encoding.UTF8.GetBytes(new char[] { c })));
                //(nodeChar as XmlElement).SetAttribute("utf32", this.Bytes2String(Encoding.UTF32.GetBytes(new char[] { c })));
                //(nodeChar as XmlElement).SetAttribute("ascii", this.Bytes2String(Encoding.ASCII.GetBytes(new char[] { c })));
                this.AddCharAtEncoding(Encoding.ASCII, c, nodeChar);
                this.AddCharAtEncoding(Encoding.Unicode, c, nodeChar);
                this.AddCharAtEncoding(Encoding.UTF32, c, nodeChar);
                this.AddCharAtEncoding(Encoding.UTF7, c, nodeChar);
                this.AddCharAtEncoding(Encoding.UTF8, c, nodeChar);
                XmlNode nodeBitmap = nodeChar.AppendChild(doc.CreateElement("bitmap"));
                BitmapHelper.SaveToXml(this.mFontEdCtrl.FontContainer.CharBitmaps[c], nodeBitmap, options);
            }
            nodeCharset.InnerText = allChars.ToString();
            return doc;
        }
        private void AddCharAtEncoding(Encoding enc, char c, XmlNode node)
        {
            XmlNode nodeData = node.AppendChild(node.OwnerDocument.CreateElement("encoding"));
            //nodeData.AppendChild(node.OwnerDocument.CreateElement("name")).InnerText = enc.EncodingName;
            //nodeData.AppendChild(node.OwnerDocument.CreateElement("codepage")).InnerText = Convert.ToString(enc.CodePage, CultureInfo.InvariantCulture);
            //nodeData.AppendChild(node.OwnerDocument.CreateElement("singlebyte")).InnerText = Convert.ToString(enc.IsSingleByte, CultureInfo.InvariantCulture);
            (nodeData as XmlElement).SetAttribute("name", enc.EncodingName);
            (nodeData as XmlElement).SetAttribute("codepage", Convert.ToString(enc.CodePage, CultureInfo.InvariantCulture));
            (nodeData as XmlElement).SetAttribute("singlebyte", Convert.ToString(enc.IsSingleByte, CultureInfo.InvariantCulture));
            XmlNode nodeBytes = nodeData.AppendChild(node.OwnerDocument.CreateElement("bytes"));
            foreach (byte b in enc.GetBytes(new char[] { c }))
            {
                nodeBytes.AppendChild(node.OwnerDocument.CreateElement("byte")).InnerText = String.Format(CultureInfo.InvariantCulture, "{0:X2}", b);
            }
        }
    }
}
