using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace lcd_bitmap_converter_mono
{
    public class FontContrainer
    {
        private Dictionary<Char, Bitmap> mCharBitmaps;
        private string mFontFamily;
        private int mSize;
        private FontStyle mStyle;

        public FontContrainer()
        {
            this.mCharBitmaps = new Dictionary<char, Bitmap>();
            this.mFontFamily = "Arial";
            this.mSize = 14;
            this.mStyle = FontStyle.Regular;
        }

        public void Initialize(string characters, Font font)
        {
            this.mCharBitmaps.Clear();
            foreach (char c in characters)
            {
                this.mCharBitmaps.Add(c, BitmapHelper.GetCharacterBitmap(c, font));
            }
        }

        public Dictionary<Char, Bitmap> CharBitmaps
        {
            get { return this.mCharBitmaps; }
        }

        public string FontFamily
        {
            get { return this.mFontFamily; }
            set { this.mFontFamily = value; }
        }
        public int Size
        {
            get { return this.mSize; }
            set { this.mSize = value; }
        }
        public FontStyle Style
        {
            get { return this.mStyle; }
            set { this.mStyle = value; }
        }
    }
}
