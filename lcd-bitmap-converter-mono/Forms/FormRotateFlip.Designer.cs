namespace lcd_bitmap_converter_mono
{
    partial class FormRotateFlip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cbFlipHorizontal = new System.Windows.Forms.CheckBox();
            this.cbFlipVertical = new System.Windows.Forms.CheckBox();
            this.rbRotate0 = new System.Windows.Forms.RadioButton();
            this.rbRotate90 = new System.Windows.Forms.RadioButton();
            this.rbRotate180 = new System.Windows.Forms.RadioButton();
            this.rbRotate270 = new System.Windows.Forms.RadioButton();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.cbFlipHorizontal, 0, 0);
            this.tlpMain.Controls.Add(this.cbFlipVertical, 1, 0);
            this.tlpMain.Controls.Add(this.rbRotate0, 0, 1);
            this.tlpMain.Controls.Add(this.rbRotate90, 1, 1);
            this.tlpMain.Controls.Add(this.rbRotate180, 0, 2);
            this.tlpMain.Controls.Add(this.rbRotate270, 1, 2);
            this.tlpMain.Controls.Add(this.bOk, 0, 3);
            this.tlpMain.Controls.Add(this.bCancel, 1, 3);
            this.tlpMain.Location = new System.Drawing.Point(10, 10);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(236, 98);
            this.tlpMain.TabIndex = 0;
            // 
            // cbFlipHorizontal
            // 
            this.cbFlipHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFlipHorizontal.AutoSize = true;
            this.cbFlipHorizontal.Location = new System.Drawing.Point(3, 3);
            this.cbFlipHorizontal.Name = "cbFlipHorizontal";
            this.cbFlipHorizontal.Size = new System.Drawing.Size(92, 17);
            this.cbFlipHorizontal.TabIndex = 0;
            this.cbFlipHorizontal.Text = "Flip Horizontal";
            this.cbFlipHorizontal.UseVisualStyleBackColor = true;
            // 
            // cbFlipVertical
            // 
            this.cbFlipVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFlipVertical.AutoSize = true;
            this.cbFlipVertical.Location = new System.Drawing.Point(101, 3);
            this.cbFlipVertical.Name = "cbFlipVertical";
            this.cbFlipVertical.Size = new System.Drawing.Size(132, 17);
            this.cbFlipVertical.TabIndex = 0;
            this.cbFlipVertical.Text = "Flip Vertical";
            this.cbFlipVertical.UseVisualStyleBackColor = true;
            // 
            // rbRotate0
            // 
            this.rbRotate0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate0.AutoSize = true;
            this.rbRotate0.Location = new System.Drawing.Point(3, 26);
            this.rbRotate0.Name = "rbRotate0";
            this.rbRotate0.Size = new System.Drawing.Size(92, 17);
            this.rbRotate0.TabIndex = 1;
            this.rbRotate0.Text = "Don\'t rotate";
            this.rbRotate0.UseVisualStyleBackColor = true;
            // 
            // rbRotate90
            // 
            this.rbRotate90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate90.AutoSize = true;
            this.rbRotate90.Checked = true;
            this.rbRotate90.Location = new System.Drawing.Point(101, 26);
            this.rbRotate90.Name = "rbRotate90";
            this.rbRotate90.Size = new System.Drawing.Size(132, 17);
            this.rbRotate90.TabIndex = 1;
            this.rbRotate90.TabStop = true;
            this.rbRotate90.Text = "Rotate 90° clockwise";
            this.rbRotate90.UseVisualStyleBackColor = true;
            // 
            // rbRotate180
            // 
            this.rbRotate180.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate180.AutoSize = true;
            this.rbRotate180.Location = new System.Drawing.Point(3, 49);
            this.rbRotate180.Name = "rbRotate180";
            this.rbRotate180.Size = new System.Drawing.Size(92, 17);
            this.rbRotate180.TabIndex = 1;
            this.rbRotate180.Text = "Rotate 180°";
            this.rbRotate180.UseVisualStyleBackColor = true;
            // 
            // rbRotate270
            // 
            this.rbRotate270.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate270.AutoSize = true;
            this.rbRotate270.Location = new System.Drawing.Point(101, 49);
            this.rbRotate270.Name = "rbRotate270";
            this.rbRotate270.Size = new System.Drawing.Size(132, 17);
            this.rbRotate270.TabIndex = 1;
            this.rbRotate270.Text = "Rotate 270° clockwise";
            this.rbRotate270.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(3, 72);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(92, 23);
            this.bOk.TabIndex = 2;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(101, 72);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(132, 23);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // FormRotateFlip
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(293, 263);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRotateFlip";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormRotateFlip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRotateFlip_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.CheckBox cbFlipHorizontal;
        private System.Windows.Forms.CheckBox cbFlipVertical;
        private System.Windows.Forms.RadioButton rbRotate0;
        private System.Windows.Forms.RadioButton rbRotate90;
        private System.Windows.Forms.RadioButton rbRotate180;
        private System.Windows.Forms.RadioButton rbRotate270;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
    }
}