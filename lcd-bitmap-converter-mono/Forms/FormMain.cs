using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.tcMain.TabPages.Clear();
        }

        private void OnMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

                IConvertorPart conv = null;
                if (this.tcMain.SelectedTab != null && this.tcMain.SelectedTab is IConvertorPart)
                    conv = this.tcMain.SelectedTab as IConvertorPart;

                if (tsmi != null)
                {
                    if (tsmi == this.tsmiQuit)
                    {
                        this.Close();
                    }
                    if (sender == this.tsmiNewImage)
                    {
                        ImageEditorPage page = new ImageEditorPage();
                        this.tcMain.TabPages.Add(page);
                        page.Text = "New Image";
                    }
                    if (sender == this.tsmiNewFont)
                    {
                        FontEditorPage page = new FontEditorPage();
                        this.tcMain.TabPages.Add(page);
                        page.Text = "New Font";
                    }
                    if (sender == this.tsmiOpen)
                    {
                        if (conv != null)
                            conv.LoadData();
                    }
                    if (sender == this.tsmiSave)
                    {
                        if (conv != null)
                            conv.SaveData();
                    }
                    if (sender == this.tsmiSaveAs)
                    {
                        if (conv != null)
                            conv.SaveDataAs();
                    }
                    if (sender == this.tsmiFlipHorizontal)
                    {
                        if (conv != null)
                            conv.RotateFlip(true, false, RotateAngle.None);
                    }
                    if (sender == this.tsmiFlipVertical)
                    {
                        if (conv != null)
                            conv.RotateFlip(false, true, RotateAngle.None);
                    }
                    if (sender == this.tsmiRotate90)
                    {
                        if (conv != null)
                            conv.RotateFlip(false, false, RotateAngle.Angle90);
                    }
                    if (sender == this.tsmiRotate180)
                    {
                        if (conv != null)
                            conv.RotateFlip(false, false, RotateAngle.Angle180);
                    }
                    if (sender == this.tsmiRotate270)
                    {
                        if (conv != null)
                            conv.RotateFlip(false, false, RotateAngle.Angle270);
                    }
                    if (sender == this.tsmiInverse)
                    {
                        if (conv != null)
                            conv.Inverse();
                    }
                    if (sender == this.tsmiOptions)
                    {
                        //if (this.mOptionsPage == null)
                        //{
                        //    this.mOptionsPage = new OptionsPage();
                        //}
                        //if(!this.tcMain.TabPages.Contains(this.mOptionsPage))
                        //{
                        //    this.tcMain.TabPages.Add(this.mOptionsPage);
                        //}
                        //this.tcMain.SelectedTab = this.mOptionsPage;
                        using (FormOptions opts = new FormOptions())
                        {
                            opts.ShowDialog();
                        }
                    }
                    if (sender == this.tsmiConvert)
                    {
                        if (conv != null)
                            conv.ConvertData();
                    }
                    if (sender == this.tsmiClose)
                    {
                        if (conv != null)
                        {
                            //conv.SaveData();
                            conv.Close();
                            (conv as TabPage).Dispose();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n" + exc.StackTrace);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavedContainer<Options>.Save();
        }
    }
}