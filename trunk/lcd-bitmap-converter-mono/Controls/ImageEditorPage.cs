using System;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public class ImageEditorPage : TabPage, IConvertorPart
    {
        private ImageEditorControl mEditor;
    
        public ImageEditorPage()
        {
            this.mEditor = new ImageEditorControl();
            this.Controls.Add(this.mEditor);
            this.mEditor.Dock = DockStyle.Fill;
        }
        protected override void Dispose (bool disposing)
        {
            this.mEditor.Dispose();
            base.Dispose (disposing);
        }
    
        #region IConvertorPart
        public void LoadData()
        {
            this.mEditor.LoadData();
        }
        public void SaveData()
        {
            this.mEditor.SaveData();
        }
        public void SaveDataAs()
        {
            this.mEditor.SaveDataAs();
        }
        public void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            this.mEditor.RotateFlip(horizontalFlip,  verticalFlip, angle);
        }
        public void Inverse()
        {
            this.mEditor.Inverse();
        }
        public void Convert()
        {
            this.mEditor.Convert();
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ImageEditorPage
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);

        }
    }
}
