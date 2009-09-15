using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace lcd_bitmap_converter_mono
{
    public partial class FormMain : Form
    {
        ToolStripMenuItem[] mEditorMenuItems;
        public FormMain()
        {
            InitializeComponent();

            this.tcMain.TabPages.Clear();

            this.mEditorMenuItems = new ToolStripMenuItem[]{
                this.tsmiSave,
                this.tsmiSaveAs,
                this.tsmiClose,
                this.tsmiFlipHorizontal,
                this.tsmiFlipVertical,
                this.tsmiRotate180,
                this.tsmiRotate270,
                this.tsmiRotate90,
                this.tsmiInverse,
                this.tsmiConvert
            };
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
                        //if (conv != null)
                        //    conv.LoadData();
                        using (OpenFileDialog ofd = new OpenFileDialog())
                        {
                            ofd.CheckFileExists = true;
                            ofd.CheckPathExists = true;
                            ofd.DefaultExt = ".xml";
                            ofd.Filter = "XML files (*.xml)|*.xml";
                            ofd.Title = "Open xml document...";
                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(ofd.FileName);
                                XmlNode root = doc.DocumentElement;
                                if (root.Attributes["type"] != null)
                                {
                                    if (root.Attributes["type"].Value == "image")
                                    {
                                        ImageEditorPage page = new ImageEditorPage();
                                        page.LoadData(ofd.FileName);
                                        this.tcMain.TabPages.Add(page);
                                        this.tcMain.SelectedTab = page;
                                    }
                                    if (root.Attributes["type"].Value == "font")
                                    {
                                        FontEditorPage page = new FontEditorPage();
                                        page.LoadData(ofd.FileName);
                                        this.tcMain.TabPages.Add(page);
                                        this.tcMain.SelectedTab = page;
                                    }
                                }
                            }
                        }
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

        private void OnMenuOpen(object sender, EventArgs e)
        {
            if (this.tcMain.TabPages.Count == 0)
            {
                foreach (ToolStripMenuItem tsmi in this.mEditorMenuItems)
                {
                    tsmi.Enabled = false;
                }
            }
            else
            {
                foreach (ToolStripMenuItem tsmi in this.mEditorMenuItems)
                {
                    tsmi.Enabled = true;
                }
            }
        }
    }
}