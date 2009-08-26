using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public class FontEditorPage : TabPage, IConvertorPart
    {
        private FontEditorControl mFontEdCtrl;
        public FontEditorPage()
        {
            this.mFontEdCtrl = new FontEditorControl();
            this.Controls.Add(this.mFontEdCtrl);
            this.mFontEdCtrl.Dock = DockStyle.Fill;
        }
        protected override void Dispose(bool disposing)
        {
            this.mFontEdCtrl.Dispose();
            base.Dispose(disposing);
        }

        #region IConvertorPart Members

        public void LoadData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveDataAs()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Inverse()
        {
            this.mFontEdCtrl.ImageEditor.BmpEditor.Bmp = BitmapHelper.Inverse(this.mFontEdCtrl.ImageEditor.BmpEditor.Bmp);
        }

        public void ConvertData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
