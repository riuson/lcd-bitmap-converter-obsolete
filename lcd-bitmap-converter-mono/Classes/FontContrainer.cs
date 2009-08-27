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

        public FontContrainer()
        {
            this.mCharBitmaps = new Dictionary<char, Bitmap>();
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
    }
}
