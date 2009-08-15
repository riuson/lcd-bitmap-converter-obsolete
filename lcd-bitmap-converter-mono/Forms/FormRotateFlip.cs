using System;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
	public class FormRotateFlip : Form
	{
		private TableLayoutPanel tlpMain;
		private CheckBox cbFlipHorizontal;
		private CheckBox cbFlipVertical;
		private RadioButton rbRotate0;
		private RadioButton rbRotate90;
		private RadioButton rbRotate180;
		private RadioButton rbRotate270;
		
		private Button bOk;
		private Button bCancel;

		public FormRotateFlip()
		{
			this.Text = "Operation";
			
			this.tlpMain = new TableLayoutPanel();
			this.Controls.Add(this.tlpMain);
			this.tlpMain.Dock = DockStyle.Fill;
			
			this.tlpMain.RowStyles.Clear();
			this.tlpMain.ColumnStyles.Clear();
			
			this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
			this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

			this.tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
			
			this.cbFlipHorizontal = new CheckBox();
			this.cbFlipHorizontal.Text = "Flip horizontal";
			this.cbFlipHorizontal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.tlpMain.Controls.Add(this.cbFlipHorizontal, 0, 0);
			
			this.cbFlipVertical = new CheckBox();
			this.cbFlipVertical.Text = "Flip vertical";
			this.cbFlipVertical.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.tlpMain.Controls.Add(this.cbFlipVertical, 1, 0);

			this.tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
			
			this.rbRotate0 = new RadioButton();
			this.rbRotate0.Text = "Don't rotate";
			this.rbRotate0.Checked = true;
			this.rbRotate0.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.tlpMain.Controls.Add(this.rbRotate0, 0, 1);
			
			this.rbRotate90 = new RadioButton();
			this.rbRotate90.Text = "Rotate 90° clockwise";
			this.rbRotate90.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.tlpMain.Controls.Add(this.rbRotate90, 1, 1);

			this.tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
			
			this.rbRotate180 = new RadioButton();
			this.rbRotate180.Text = "Rotate 180° clockwise";
			this.rbRotate180.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.tlpMain.Controls.Add(this.rbRotate180, 0, 2);
			
			this.rbRotate270 = new RadioButton();
			this.rbRotate270.Text = "Rotate 270° clockwise";
			this.rbRotate270.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.tlpMain.Controls.Add(this.rbRotate270, 1, 2);

			this.tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
			
			this.bOk = new Button();
			this.bOk.Text = "Ok";
			this.bOk.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.bOk.DialogResult = DialogResult.OK;
			this.AcceptButton = this.bOk;
			this.tlpMain.Controls.Add(this.bOk, 0, 3);
			
			this.bCancel = new Button();
			this.bCancel.Text = "Cancel";
			this.bCancel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.bCancel.DialogResult = DialogResult.Cancel;
			this.CancelButton = this.bCancel;
			this.tlpMain.Controls.Add(this.bCancel, 1, 3);
			
			this.tlpMain.AutoSize = true;
			this.tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			
			//restore from settings
			this.FlipHorizontal = SavedContainer<Options>.Instance.OperationFlipHorizontal;
			this.FlipVertical = SavedContainer<Options>.Instance.OperationFlipVertical;
			this.Angle = SavedContainer<Options>.Instance.OperationRotateAngle;
		}

		protected override void Dispose (bool disposing)
		{
			SavedContainer<Options>.Instance.OperationFlipHorizontal = this.FlipHorizontal;
			SavedContainer<Options>.Instance.OperationFlipVertical = this.FlipVertical;
			SavedContainer<Options>.Instance.OperationRotateAngle = this.Angle;
			SavedContainer<Options>.Save();
			base.Dispose (disposing);
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
				if(this.rbRotate90.Checked)
					return RotateAngle.Angle90;
				if(this.rbRotate180.Checked)
					return RotateAngle.Angle180;
				if(this.rbRotate270.Checked)
					return RotateAngle.Angle270;
				return RotateAngle.None;
			}
			set
			{
				switch(value)
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
