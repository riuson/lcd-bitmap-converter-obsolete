using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public partial class FormRotateFlip : Form
    {
        public FormRotateFlip()
        {
            InitializeComponent();
            //restore from settings
            this.FlipHorizontal = SavedContainer<Options>.Instance.OperationFlipHorizontal;
            this.FlipVertical = SavedContainer<Options>.Instance.OperationFlipVertical;
            this.Angle = SavedContainer<Options>.Instance.OperationRotateAngle;
        }

        private void FormRotateFlip_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavedContainer<Options>.Instance.OperationFlipHorizontal = this.FlipHorizontal;
            SavedContainer<Options>.Instance.OperationFlipVertical = this.FlipVertical;
            SavedContainer<Options>.Instance.OperationRotateAngle = this.Angle;
            SavedContainer<Options>.Save();
        }

        public bool FlipHorizontal
        {
            get { return this.cbFlipHorizontal.Checked; }
            set { this.cbFlipHorizontal.Checked = value; }
        }

        public bool FlipVertical
        {
            get { return this.cbFlipVertical.Checked; }
            set { this.cbFlipVertical.Checked = value; }
        }

        public RotateAngle Angle
        {
            get
            {
                if (this.rbRotate90.Checked)
                    return RotateAngle.Angle90;
                if (this.rbRotate180.Checked)
                    return RotateAngle.Angle180;
                if (this.rbRotate270.Checked)
                    return RotateAngle.Angle270;
                return RotateAngle.None;
            }
            set
            {
                switch (value)
                {
                    case RotateAngle.None:
                        this.rbRotate0.Checked = true;
                        break;
                    case RotateAngle.Angle90:
                        this.rbRotate90.Checked = true;
                        break;
                    case RotateAngle.Angle180:
                        this.rbRotate180.Checked = true;
                        break;
                    case RotateAngle.Angle270:
                        this.rbRotate270.Checked = true;
                        break;
                }
            }
        }
    }
}