using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public partial class FormColor2BW : Form
    {
        private Bitmap mOriginal;
        private Bitmap mResult;

        public FormColor2BW()
        {
            InitializeComponent();
        }

        public Bitmap ImageOriginal
        {
            get { return this.mOriginal; }
            set
            {
                this.mOriginal = value;
                this.pbOriginal.Image = value;
            }
        }

        public Bitmap ImageResult
        {
            get { return this.mResult; }
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (sender == this.tbEdge)
            {
                float edge = this.tbEdge.Value / 100.0f;
                this.mResult = BitmapHelper.GetMonochrome(this.mOriginal, edge);
                this.pbResult.Image = this.mResult;
            }
        }
    }
}