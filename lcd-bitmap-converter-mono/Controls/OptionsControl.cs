﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public partial class OptionsControl : UserControl
    {
        public OptionsControl()
        {
            InitializeComponent();

            this.tbImageStyleFilename.Text = SavedContainer<Options>.Instance.ImageStyleFilename;
            this.tbFontStyleFilename.Text = SavedContainer<Options>.Instance.FontStyleFilename;

            //restore from settings
            this.FlipHorizontal = SavedContainer<Options>.Instance.OperationFlipHorizontal;
            this.FlipVertical = SavedContainer<Options>.Instance.OperationFlipVertical;
            this.Angle = SavedContainer<Options>.Instance.OperationRotateAngle;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (sender == this.bOk)
            {
                SavedContainer<Options>.Instance.ImageStyleFilename = this.tbImageStyleFilename.Text;
                SavedContainer<Options>.Instance.FontStyleFilename = this.tbFontStyleFilename.Text;
                SavedContainer<Options>.Instance.OperationFlipHorizontal = this.FlipHorizontal;
                SavedContainer<Options>.Instance.OperationFlipVertical = this.FlipVertical;
                SavedContainer<Options>.Instance.OperationRotateAngle = this.Angle;
                SavedContainer<Options>.Save();
            }
            if (sender == this.bCancel)
            {
            }
            if (sender == this.bOk || sender == this.bCancel)
            {
                TabPage tp = this.Parent as TabPage;
                if (tp != null)
                {
                    TabControl tc = tp.Parent as TabControl;
                    if (tc != null)
                    {
                        tc.TabPages.Remove(tp);
                        //tp.Dispose();
                    }
                }
            }
            if (sender == this.bSelectImageStyle)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.AddExtension = true;
                    ofd.CheckFileExists = true;
                    ofd.CheckPathExists = true;
                    ofd.DefaultExt = ".xslt";
                    ofd.Filter = "XSLT files (*.xsl; *.xslt)|*.xsl;*.xslt";
                    ofd.FilterIndex = 1;
                    ofd.InitialDirectory = Options.ApplicationDirectory;
                    ofd.Multiselect = false;
                    ofd.RestoreDirectory = true;
                    ofd.ShowReadOnly = true;
                    ofd.Title = "Select XSLT file...";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        this.tbImageStyleFilename.Text = ofd.FileName;
                    }
                }
            }
            if (sender == this.bSelectFontStyle)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.AddExtension = true;
                    ofd.CheckFileExists = true;
                    ofd.CheckPathExists = true;
                    ofd.DefaultExt = ".xslt";
                    ofd.Filter = "XSLT files (*.xsl; *.xslt)|*.xsl;*.xslt";
                    ofd.FilterIndex = 1;
                    ofd.InitialDirectory = Options.ApplicationDirectory;
                    ofd.Multiselect = false;
                    ofd.RestoreDirectory = true;
                    ofd.ShowReadOnly = true;
                    ofd.Title = "Select XSLT file...";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        this.tbFontStyleFilename.Text = ofd.FileName;
                    }
                }
            }
        }

        private bool FlipHorizontal
        {
            get { return this.cbFlipHorizontal.Checked; }
            set { this.cbFlipHorizontal.Checked = value; }
        }

        private bool FlipVertical
        {
            get { return this.cbFlipVertical.Checked; }
            set { this.cbFlipVertical.Checked = value; }
        }

        private RotateAngle Angle
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
