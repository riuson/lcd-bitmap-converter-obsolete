using System;
using System.IO;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public class Options
    {
        private string mImageStyleFilename;
        private string mFontStyleFilename;
        private XmlSavingOptions mXmlSavingOptions;
        private bool mSetBitsByDefault;

        public Options()
        {
            this.mImageStyleFilename = String.Empty;
            this.mFontStyleFilename = String.Empty;
            this.mXmlSavingOptions = new XmlSavingOptions();
            this.mSetBitsByDefault = false;
        }

        public static string ApplicationDirectory
        {
            get
            {
                return Path.GetDirectoryName(Application.ExecutablePath);
            }
        }
        public string ImageStyleFilename
        {
            get { return this.mImageStyleFilename; }
            set { this.mImageStyleFilename = value; }
        }
        public string FontStyleFilename
        {
            get { return this.mFontStyleFilename; }
            set { this.mFontStyleFilename = value; }
        }
        public XmlSavingOptions XmlSavingOptions
        {
            get { return this.mXmlSavingOptions; }
            set { this.mXmlSavingOptions = value; }
        }
        public bool SetBitsByDefault
        {
            get { return this.mSetBitsByDefault; }
            set { this.mSetBitsByDefault = value; }
        }
    }
}
