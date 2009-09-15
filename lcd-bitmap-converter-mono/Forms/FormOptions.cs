using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();

            //restore from settings
            this.tbImageStyleFilename.Text = SavedContainer<Options>.Instance.ImageStyleFilename;
            this.tbFontStyleFilename.Text = SavedContainer<Options>.Instance.FontStyleFilename;

            this.cbFlipHorizontal.Checked = SavedContainer<Options>.Instance.XmlSavingOptions.FlipHorizontal;
            this.cbFlipVertical.Checked = SavedContainer<Options>.Instance.XmlSavingOptions.FlipVertical;
            switch (SavedContainer<Options>.Instance.XmlSavingOptions.Angle)
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

            this.cbInverseColors.Checked = SavedContainer<Options>.Instance.XmlSavingOptions.Inverse;
            this.cbAlignRight.Checked = SavedContainer<Options>.Instance.XmlSavingOptions.AlignRight;
            this.cbMirrorBytes.Checked = SavedContainer<Options>.Instance.XmlSavingOptions.MirrorEachByte;
            this.cbSetBitsByDefault.Checked = SavedContainer<Options>.Instance.SetBitsByDefault;
        }

        private void OnClick(object sender, EventArgs e)
        {
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

        private void FormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                SavedContainer<Options>.Instance.ImageStyleFilename = this.tbImageStyleFilename.Text;
                SavedContainer<Options>.Instance.FontStyleFilename = this.tbFontStyleFilename.Text;
                SavedContainer<Options>.Instance.XmlSavingOptions.FlipHorizontal = this.cbFlipHorizontal.Checked;
                SavedContainer<Options>.Instance.XmlSavingOptions.FlipVertical = this.cbFlipVertical.Checked;
                if (this.rbRotate0.Checked)
                    SavedContainer<Options>.Instance.XmlSavingOptions.Angle = RotateAngle.None;
                if (this.rbRotate90.Checked)
                    SavedContainer<Options>.Instance.XmlSavingOptions.Angle = RotateAngle.Angle90;
                if (this.rbRotate180.Checked)
                    SavedContainer<Options>.Instance.XmlSavingOptions.Angle = RotateAngle.Angle180;
                if (this.rbRotate270.Checked)
                    SavedContainer<Options>.Instance.XmlSavingOptions.Angle = RotateAngle.Angle270;

                SavedContainer<Options>.Instance.XmlSavingOptions.Inverse = this.cbInverseColors.Checked;
                SavedContainer<Options>.Instance.XmlSavingOptions.AlignRight = this.cbAlignRight.Checked;
                SavedContainer<Options>.Instance.XmlSavingOptions.MirrorEachByte = this.cbMirrorBytes.Checked;
                SavedContainer<Options>.Instance.SetBitsByDefault = this.cbSetBitsByDefault.Checked;
                SavedContainer<Options>.Save();
            }
        }
    }
}