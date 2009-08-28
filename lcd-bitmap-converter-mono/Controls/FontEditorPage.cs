using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Globalization;

namespace lcd_bitmap_converter_mono
{
    public class FontEditorPage : TabPage, IConvertorPart
    {
        private FontEditorControl mFontEdCtrl;
        private string mFileName;

        public FontEditorPage()
        {
            this.mFontEdCtrl = new FontEditorControl();
            this.Controls.Add(this.mFontEdCtrl);
            this.mFontEdCtrl.Dock = DockStyle.Fill;
            this.BackColor = Color.Transparent;
            this.UseVisualStyleBackColor = true;
            this.mFileName = String.Empty;
        }
        protected override void Dispose(bool disposing)
        {
            this.mFontEdCtrl.Dispose();
            base.Dispose(disposing);
        }

        #region IConvertorPart Members

        public void LoadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.DefaultExt = ".xml";
                ofd.Filter = "XML files(*.xml)|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofd.FileName;
                    string ext = Path.GetExtension(filename);
                    if (ext == ".xml")
                    {
                        this.LoadFontFromXml(filename);
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
                if (ext == ".xml")
                    this.SaveFontToXml(this.mFileName);
            }
        }

        public void SaveDataAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.CheckPathExists = true;
                sfd.DefaultExt = ".bmp";
                sfd.Filter = "XML files (*.xml)|*.xml";
                sfd.OverwritePrompt = true;
                sfd.Title = "Save font file...";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.mFileName = sfd.FileName;
                    this.SaveData();
                }
            }
        }

        public void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            this.mFontEdCtrl.ImageEditor.BmpEditor.RotateFlip(horizontalFlip, verticalFlip, angle);
        }

        public void Inverse()
        {
            this.mFontEdCtrl.ImageEditor.BmpEditor.Bmp = BitmapHelper.Inverse(this.mFontEdCtrl.ImageEditor.BmpEditor.Bmp);
        }

        public void ConvertData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void SaveFontToXml(string filename)
        {
            this.mFileName = filename;
            XmlDocument doc = this.GetXmlDocument(false, false, RotateAngle.None, false);
            doc.Save(filename);
        }
        private void LoadFontFromXml(string filename)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlNode root = doc.DocumentElement;
                if (root.Attributes["type"] != null)
                {
                    if (root.Attributes["type"].Value == "font")
                    {
                        XmlNodeList nodesChar = root.SelectNodes("char");
                        if (nodesChar != null && nodesChar.Count > 0)
                        {
                            List<byte> bytes = new List<byte>();
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

                                if (root["family"] != null)
                                    this.mFontEdCtrl.FontContainer.FontFamily = root["family"].InnerText;
                                if (root["size"] != null)
                                    this.mFontEdCtrl.FontContainer.Size = Convert.ToInt32(root["size"].InnerText, CultureInfo.InvariantCulture);
                                if (root["style"] != null)
                                    this.mFontEdCtrl.FontContainer.Style = (FontStyle)Enum.Parse(typeof(FontStyle), root["style"].InnerText);

                                this.mFontEdCtrl.ApplyContainer();
                            }
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
        }
        private XmlDocument GetXmlDocument(bool flipHorizontal, bool flipVertical, RotateAngle angle, bool inverse)
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
            root.AppendChild(doc.CreateElement("family")).InnerText = Enum.Format(typeof(FontStyle), this.mFontEdCtrl.FontContainer.Style, "g"); ;
            XmlNode nodeCharset = root.AppendChild(doc.CreateElement("characters"));

            XmlNode nodeDefinitions = root.AppendChild(doc.CreateElement("definitions"));
            for (int i = 0; i < 256; i++)
            {
                XmlNode nodeValue = nodeDefinitions.AppendChild(doc.CreateElement("value"));
                (nodeValue as XmlElement).SetAttribute("text", Convert.ToString(i, 2).PadLeft(8, '0'));
                (nodeValue as XmlElement).SetAttribute("byte", String.Format("{0:X2}", i));
            }
            StringBuilder allChars = new StringBuilder();
            foreach (char c in this.mFontEdCtrl.FontContainer.CharBitmaps.Keys)
            {
                allChars.Append(c);
                XmlNode nodeChar = root.AppendChild(doc.CreateElement("char"));
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
                BitmapHelper.SaveToXml(this.mFontEdCtrl.FontContainer.CharBitmaps[c], nodeBitmap, flipHorizontal, flipVertical, angle, inverse);
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
