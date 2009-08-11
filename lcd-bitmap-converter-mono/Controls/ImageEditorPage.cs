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
		#endregion
	}
}
