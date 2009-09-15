using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public class FontContainer
    {
        private Dictionary<Char, Bitmap> mCharBitmaps;
        private FontWidthMode mWidthMode;
        private Font mFont;
        private int mMaxWidth;
        private int mEdge;

        public FontContainer()
        {
            this.mCharBitmaps = new Dictionary<char, Bitmap>();
            //this.mFontFamily = "Arial";
            //this.mSize = 14;
            //this.mStyle = FontStyle.Regular;
            this.mWidthMode = FontWidthMode.None;
            this.mFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            this.mEdge = 5;
        }

        public void Initialize(string characters, Font font)
        {
            this.mCharBitmaps.Clear();
            this.mFont = font;
            this.mMaxWidth = 0;
            this.Append(characters);
        }

        public void Append(string characters)
        {
            int width = 0;
            if (this.mWidthMode == FontWidthMode.Monospaced)
            {
                foreach (char c in characters)
                {
                    Size sz = TextRenderer.MeasureText(new string(c, 1), this.mFont);
                    if (sz.Width > width)
                        width = sz.Width;
                }
                foreach (char c in this.mCharBitmaps.Keys)
                {
                    Size sz = TextRenderer.MeasureText(new string(c, 1), this.mFont);
                    if (sz.Width > width)
                        width = sz.Width;
                }
            }
            foreach (char c in characters)
            {
                if (!this.mCharBitmaps.ContainsKey(c))
                    this.mCharBitmaps.Add(c, BitmapHelper.GetCharacterBitmap(c, this.mFont, this.mWidthMode, width, this.mEdge * 0.1f));
            }
        }

        public Dictionary<Char, Bitmap> CharBitmaps
        {
            get { return this.mCharBitmaps; }
        }

        public FontFamily FontFamily
        {
            get { return this.mFont.FontFamily; }
            set
            {
                //this.mFontFamily = value;
                if (this.mFont.FontFamily != value)
                    this.mFont = new Font(value, this.mFont.Size, this.mFont.Style, GraphicsUnit.Pixel);
            }
        }
        public float Size
        {
            get { return this.mFont.Size; }
            set
            {
                //this.mSize = value;
                if (Math.Abs(this.mFont.Size - value) > 0.1)
                    this.mFont = new Font(this.mFont.FontFamily, value, this.mFont.Style, GraphicsUnit.Pixel);
            }
        }
        public FontStyle Style
        {
            get { return this.mFont.Style; }
            set
            {
                //this.mStyle = value;
                if (this.mFont.Style != value)
                    this.mFont = new Font(this.mFont, value);
            }
        }
        public FontWidthMode WidthMode
        {
            get { return this.mWidthMode; }
            set { this.mWidthMode = value; }
        }
        public Font Font
        {
            get { return this.mFont; }
            set { this.mFont = value; }
        }
        public int Edge
        {
            get { return this.mEdge; }
            set { this.mEdge = value; }
        }
    }
}
