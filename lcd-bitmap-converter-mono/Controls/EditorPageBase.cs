using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;

namespace lcd_bitmap_converter_mono
{
    public class EditorPageBase : TabPage, IConvertorPart
    {
        protected string mFileDialogFilter;
        protected string mFileName;
        protected string mDataTypeName;

        public EditorPageBase()
        {
            this.BackColor = Color.Transparent;
            this.UseVisualStyleBackColor = true;

            this.mFileDialogFilter = "XML files (*.xml)|*.xml";
            this.mFileName = String.Empty;
            this.mDataTypeName = "unknown";
        }

        #region IConvertorPart Members

        public void LoadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.DefaultExt = ".*";
                ofd.Filter = this.mFileDialogFilter;
                ofd.Title = "Open " + this.mDataTypeName;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofd.FileName;
                    string ext = Path.GetExtension(filename);
                    //if (ext == ".xml")
                    {
                        FileProcessor proc = this.GetReadProcessor(ext);
                        if (proc != null)
                        {
                            if (proc(filename))
                            {
                                this.Text = Path.GetFileNameWithoutExtension(filename);
                                this.mFileName = filename;
                            }
                        }
                    }
                }
            }
        }

        public void SaveData()
        {
            if (String.IsNullOrEmpty(this.mFileName))
                this.SaveDataAs();
            else
            {
                string ext = Path.GetExtension(this.mFileName);
                FileProcessor proc = this.GetWriteProcessor(ext);
                if (proc != null)
                    proc(this.mFileName);
            }
        }

        public void SaveDataAs()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.CheckPathExists = true;
                sfd.DefaultExt = ".*";
                sfd.Filter = this.mFileDialogFilter;
                sfd.OverwritePrompt = true;
                sfd.Title = "Save " + this.mDataTypeName + "...";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.mFileName = sfd.FileName;
                    this.SaveData();
                }
            }
        }

        public virtual void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void Inverse()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void ConvertData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void Close()
        {
            bool cancel = false;
            if (this.HasChanges)
            {
                DialogResult res = MessageBox.Show("Save changes?", "Close file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    this.SaveData();
                if (res == DialogResult.Cancel)
                    cancel = true;
            }
            if (!cancel)
            {
                if (this.Parent != null && this.Parent is TabControl)
                {
                    TabControl tc = this.Parent as TabControl;
                    tc.TabPages.Remove(this);
                }
            }
        }
        #endregion

        protected virtual FileProcessor GetReadProcessor(string extension)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        protected virtual FileProcessor GetWriteProcessor(string extension)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        protected virtual XmlDocument GetXmlDocument()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        protected virtual bool HasChanges
        {
            get { return false; }
        }
    }
}
