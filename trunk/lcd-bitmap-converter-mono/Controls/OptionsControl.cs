using System;
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
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (sender == this.bOk)
            {
                SavedContainer<Options>.Instance.ImageStyleFilename = this.tbImageStyleFilename.Text;
                SavedContainer<Options>.Instance.FontStyleFilename = this.tbFontStyleFilename.Text;
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
    }
}
