using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace lcd_bitmap_converter_mono
{
    public partial class FormCharSelector : Form
    {
        private string mResult;

        public FormCharSelector(Font usedFont)
        {
            InitializeComponent();
            this.lbChars.Font = usedFont;

            UnicodeHelper uc = new UnicodeHelper();
            this.lbRanges.Items.Clear();
            foreach (UnicodeRange range in uc.Ranges)
            {
                this.lbRanges.Items.Add(range);
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (sender == this.lbRanges)
            {
                UnicodeRange range = this.lbRanges.SelectedItem as UnicodeRange;
                if (range != null)
                {
                    this.lbChars.Items.Clear();
                    for (int i = range.CodeStart; i <= range.CodeEnd; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(i);
                        if (i <= UInt16.MaxValue)
                            bytes = BitConverter.GetBytes(Convert.ToUInt16(i));
                        //if (i <= Byte.MaxValue)
                        //    bytes = new byte[] { Convert.ToByte(i) };
                        char[] chars = Encoding.Unicode.GetChars(bytes);
                        if (chars.Length > 0)
                        {
                            char c = chars[0];
                            if (Char.IsLetterOrDigit(c) ||
                                Char.IsSymbol(c) ||
                                Char.IsWhiteSpace(c) ||
                                Char.IsPunctuation(c) ||
                                Char.IsSeparator(c))
                                this.lbChars.Items.Add(c);
                        }
                        chars = Encoding.UTF8.GetChars(new byte[] { 0xf0, 0x9d, 0x90, 0x80 });
                    }
                }
            }
            if (sender == this.lbChars)
            {
                if (this.lbChars.SelectedIndex >= 0)
                {
                    char c = Convert.ToChar(this.lbChars.SelectedItem);
                    UnicodeCategory category = Char.GetUnicodeCategory(c);
                    byte[] bytes = Encoding.Unicode.GetBytes(new char[] { c });
                    int number = 0;
                    if (bytes.Length == 1) number = bytes[0];
                    if (bytes.Length == 2) number = BitConverter.ToInt16(bytes, 0);
                    if (bytes.Length == 4) number = BitConverter.ToInt32(bytes, 0);
                    this.lSelectedChar.Text = String.Format("'{0}' 0x{1:X} {2}", c, number, category);
                }
            }
        }

        public string ResultString
        {
            get { return this.mResult; }
        }

        private void FormCharSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                foreach (object obj in this.lbChars.SelectedItems)
                {
                    sb.Append(Convert.ToChar(obj));
                }
                this.mResult = sb.ToString();
            }
        }
    }
}