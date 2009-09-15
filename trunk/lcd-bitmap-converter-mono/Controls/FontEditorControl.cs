using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace lcd_bitmap_converter_mono
{
    public partial class FontEditorControl : UserControl
    {
        private FontContainer mFontCont;
        private Char mLastSelectedChar;
        public FontEditorControl()
        {
            InitializeComponent();
            this.lbCharacters.Items.Clear();

            this.mFontCont = new FontContainer();

            FontFamily[] fams = FontFamily.Families;
            foreach (FontFamily fam in fams)
            {
                this.cbFontFamilies.Items.Add(fam.GetName(CultureInfo.InvariantCulture.LCID));
            }
            if (this.cbFontFamilies.Items.Contains(this.lbCharacters.Font.FontFamily.GetName(CultureInfo.InvariantCulture.LCID)))
            {
                FontFamily family = this.lbCharacters.Font.FontFamily;
                this.cbFontFamilies.SelectedItem = family.GetName(CultureInfo.CurrentUICulture.LCID);
                this.mFontCont.FontFamily = family;
            }
            else
                this.cbFontFamilies.SelectedIndex = 0;

            this.numFontSize.Value = Convert.ToDecimal(this.lbCharacters.Font.Size);

            this.clbFontStyles.Items.Clear();
            Array styles = Enum.GetValues(typeof(FontStyle));
            foreach (object style in styles)
            {
                this.clbFontStyles.Items.Add(style);
            }

            this.cbWidthMode.Items.Clear();
            Array widthModes = Enum.GetValues(typeof(FontWidthMode));
            foreach (object mode in widthModes)
            {
                this.cbWidthMode.Items.Add(mode);
            }
            this.cbWidthMode.SelectedIndex = 0;

            this.mLastSelectedChar = '\x00';
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (sender == this.bAddChar)
            {
                string str = this.tbNewCharacters.Text;
                if (!String.IsNullOrEmpty(str))
                {
                    //for (int i = 0; i < str.Length; i++)
                    //{
                    //    char c = str[i];
                    //    if (!this.mFontCont.CharBitmaps.ContainsKey(c))
                    //    {
                    //        //this.mFontCont.CharBitmaps.Add(c, BitmapHelper.GetCharacterBitmap(c, this.lbCharacters.Font));
                    //        this.lbCharacters.Items.Add(c);
                    //    }
                    //}
                    this.mFontCont.Append(str);
                    this.lbCharacters.Items.Clear();
                    foreach (char c in this.mFontCont.CharBitmaps.Keys)
                    {
                        this.lbCharacters.Items.Add(c);
                    }
                }
            }
            if (sender == this.bDelChar)
            {
                if (this.lbCharacters.SelectedIndices.Count > 0)
                {
                    for (int i = this.lbCharacters.SelectedIndices.Count - 1; i >= 0; i--)
                    {
                        int index = this.lbCharacters.SelectedIndices[i];
                        char c = Convert.ToChar(this.lbCharacters.Items[index]);
                        this.lbCharacters.Items.RemoveAt(index);
                        this.mFontCont.CharBitmaps.Remove(c);
                    }
                }
            }
            if (sender == this.bApplyFont)
            {
                try
                {
                    FontFamily family = new FontFamily(Convert.ToString(this.cbFontFamilies.SelectedItem));
                    FontStyle fs = new FontStyle();
                    foreach (object obj in this.clbFontStyles.CheckedItems)
                    {
                        fs |= (FontStyle)obj;
                    }
                    Font fnt = new Font(family, Convert.ToInt32(this.numFontSize.Value), fs, GraphicsUnit.Pixel);
                    this.tbNewCharacters.Font = fnt;
                    this.lbCharacters.Font = fnt;
                    StringBuilder sb = new StringBuilder();
                    foreach (object obj in this.lbCharacters.Items)
                    {
                        sb.Append(Convert.ToChar(obj));
                    }

                    this.mFontCont.WidthMode = (FontWidthMode)this.cbWidthMode.SelectedItem;
                    this.mFontCont.Edge = this.tbEdge.Value;
                    this.mFontCont.Initialize(sb.ToString(), fnt);

                    int maxWidth = 0;
                    foreach (Bitmap bmp in this.mFontCont.CharBitmaps.Values)
                    {
                        if (bmp.Width > maxWidth)
                            maxWidth = bmp.Width;
                    }
                    this.lbCharacters.ColumnWidth = maxWidth;
                    this.mLastSelectedChar = '\x00';

                    this.OnCharSelect(this.lbCharacters, EventArgs.Empty);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (sender == this.bSelectChars)
            {
                using (FormCharSelector form = new FormCharSelector(this.mFontCont.Font))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        this.tbNewCharacters.Text = form.ResultString;
                    }
                }
            }
        }

        private void OnCharSelect(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb != null && lb.SelectedIndex >= 0)
            {
                char c = Convert.ToChar(lb.SelectedItem);
                if (this.mFontCont.CharBitmaps.ContainsKey(c))
                {
                    if (this.mLastSelectedChar != '\x00' && this.mFontCont.CharBitmaps.ContainsKey(this.mLastSelectedChar))
                    {
                        this.mFontCont.CharBitmaps[this.mLastSelectedChar] = this.ImageEditor.BmpEditor.Bmp;
                    }
                    Bitmap bmp = this.mFontCont.CharBitmaps[c];
                    this.ImageEditor.BmpEditor.Bmp = bmp;
                    this.mLastSelectedChar = c;
                }
            }
        }

        public FontContainer FontContainer
        {
            get { return this.mFontCont; }
        }

        public void ApplyContainer()
        {
            this.lbCharacters.Items.Clear();
            foreach (KeyValuePair<Char, Bitmap> pair in this.mFontCont.CharBitmaps)
            {
                this.lbCharacters.Items.Add(pair.Key);
            }
            if (this.cbFontFamilies.Items.Contains(this.mFontCont.FontFamily.GetName(CultureInfo.InvariantCulture.LCID)))
                this.cbFontFamilies.SelectedItem = this.mFontCont.FontFamily.GetName(CultureInfo.InvariantCulture.LCID);
            this.numFontSize.Value = Convert.ToDecimal(this.mFontCont.Size);
            Array styles = Enum.GetValues(typeof(FontStyle));
            int index = 0;
            foreach (object style in styles)
            {
                FontStyle fs = (FontStyle)style;
                this.clbFontStyles.SetItemChecked(index, ((this.mFontCont.Style & fs) == fs));
                index++;
            }
            this.lbCharacters.Font = this.mFontCont.Font;
            this.tbNewCharacters.Font = this.mFontCont.Font;
        }
    }
}
