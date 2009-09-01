namespace lcd_bitmap_converter_mono
{
    partial class FormOptions
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.TableLayoutPanel tlpStyles;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.GroupBox groupBox2;
            this.bSelectImageStyle = new System.Windows.Forms.Button();
            this.tbImageStyleFilename = new System.Windows.Forms.TextBox();
            this.tbFontStyleFilename = new System.Windows.Forms.TextBox();
            this.bSelectFontStyle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbFlipHorizontal = new System.Windows.Forms.CheckBox();
            this.cbFlipVertical = new System.Windows.Forms.CheckBox();
            this.rbRotate90 = new System.Windows.Forms.RadioButton();
            this.rbRotate0 = new System.Windows.Forms.RadioButton();
            this.rbRotate180 = new System.Windows.Forms.RadioButton();
            this.rbRotate270 = new System.Windows.Forms.RadioButton();
            this.cbInverseColors = new System.Windows.Forms.CheckBox();
            this.cbAlignRight = new System.Windows.Forms.CheckBox();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbMirrorBytes = new System.Windows.Forms.CheckBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tlpStyles = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            tlpStyles.SuspendLayout();
            groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(tlpStyles);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(432, 96);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Transform tables";
            // 
            // tlpStyles
            // 
            tlpStyles.AutoSize = true;
            tlpStyles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlpStyles.ColumnCount = 3;
            tlpStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpStyles.Controls.Add(label1, 0, 0);
            tlpStyles.Controls.Add(this.bSelectImageStyle, 2, 0);
            tlpStyles.Controls.Add(this.tbImageStyleFilename, 1, 0);
            tlpStyles.Controls.Add(label2, 0, 1);
            tlpStyles.Controls.Add(this.tbFontStyleFilename, 1, 1);
            tlpStyles.Controls.Add(this.bSelectFontStyle, 2, 1);
            tlpStyles.Location = new System.Drawing.Point(6, 19);
            tlpStyles.Name = "tlpStyles";
            tlpStyles.RowCount = 2;
            tlpStyles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpStyles.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpStyles.Size = new System.Drawing.Size(420, 58);
            tlpStyles.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 13);
            label1.TabIndex = 0;
            label1.Text = "Image xslt filename:";
            // 
            // bSelectImageStyle
            // 
            this.bSelectImageStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelectImageStyle.AutoSize = true;
            this.bSelectImageStyle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bSelectImageStyle.Location = new System.Drawing.Point(391, 3);
            this.bSelectImageStyle.Name = "bSelectImageStyle";
            this.bSelectImageStyle.Size = new System.Drawing.Size(26, 23);
            this.bSelectImageStyle.TabIndex = 2;
            this.bSelectImageStyle.Text = "...";
            this.bSelectImageStyle.UseVisualStyleBackColor = true;
            this.bSelectImageStyle.Click += new System.EventHandler(this.OnClick);
            // 
            // tbImageStyleFilename
            // 
            this.tbImageStyleFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImageStyleFilename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbImageStyleFilename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbImageStyleFilename.Location = new System.Drawing.Point(108, 4);
            this.tbImageStyleFilename.Name = "tbImageStyleFilename";
            this.tbImageStyleFilename.Size = new System.Drawing.Size(277, 20);
            this.tbImageStyleFilename.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 37);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(99, 13);
            label2.TabIndex = 0;
            label2.Text = "Font xslt filename:";
            // 
            // tbFontStyleFilename
            // 
            this.tbFontStyleFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFontStyleFilename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbFontStyleFilename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbFontStyleFilename.Location = new System.Drawing.Point(108, 33);
            this.tbFontStyleFilename.Name = "tbFontStyleFilename";
            this.tbFontStyleFilename.Size = new System.Drawing.Size(277, 20);
            this.tbFontStyleFilename.TabIndex = 1;
            // 
            // bSelectFontStyle
            // 
            this.bSelectFontStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelectFontStyle.AutoSize = true;
            this.bSelectFontStyle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bSelectFontStyle.Location = new System.Drawing.Point(391, 32);
            this.bSelectFontStyle.Name = "bSelectFontStyle";
            this.bSelectFontStyle.Size = new System.Drawing.Size(26, 23);
            this.bSelectFontStyle.TabIndex = 2;
            this.bSelectFontStyle.Text = "...";
            this.bSelectFontStyle.UseVisualStyleBackColor = true;
            this.bSelectFontStyle.Click += new System.EventHandler(this.OnClick);
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBox2.Controls.Add(this.tableLayoutPanel1);
            groupBox2.Location = new System.Drawing.Point(12, 114);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(283, 153);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Operation before convert";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cbFlipHorizontal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbFlipVertical, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbRotate90, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbRotate0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbRotate180, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbRotate270, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbInverseColors, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbAlignRight, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbMirrorBytes, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 115);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cbFlipHorizontal
            // 
            this.cbFlipHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFlipHorizontal.AutoSize = true;
            this.cbFlipHorizontal.Location = new System.Drawing.Point(3, 3);
            this.cbFlipHorizontal.Name = "cbFlipHorizontal";
            this.cbFlipHorizontal.Size = new System.Drawing.Size(92, 17);
            this.cbFlipHorizontal.TabIndex = 4;
            this.cbFlipHorizontal.Text = "Flip Horizontal";
            this.cbFlipHorizontal.UseVisualStyleBackColor = true;
            // 
            // cbFlipVertical
            // 
            this.cbFlipVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFlipVertical.AutoSize = true;
            this.cbFlipVertical.Location = new System.Drawing.Point(101, 3);
            this.cbFlipVertical.Name = "cbFlipVertical";
            this.cbFlipVertical.Size = new System.Drawing.Size(167, 17);
            this.cbFlipVertical.TabIndex = 4;
            this.cbFlipVertical.Text = "Flip Vertical";
            this.cbFlipVertical.UseVisualStyleBackColor = true;
            // 
            // rbRotate90
            // 
            this.rbRotate90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate90.AutoSize = true;
            this.rbRotate90.Location = new System.Drawing.Point(101, 26);
            this.rbRotate90.Name = "rbRotate90";
            this.rbRotate90.Size = new System.Drawing.Size(167, 17);
            this.rbRotate90.TabIndex = 3;
            this.rbRotate90.TabStop = true;
            this.rbRotate90.Text = "Rotate 90° Clockwise";
            this.rbRotate90.UseVisualStyleBackColor = true;
            // 
            // rbRotate0
            // 
            this.rbRotate0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate0.AutoSize = true;
            this.rbRotate0.Location = new System.Drawing.Point(3, 26);
            this.rbRotate0.Name = "rbRotate0";
            this.rbRotate0.Size = new System.Drawing.Size(92, 17);
            this.rbRotate0.TabIndex = 3;
            this.rbRotate0.TabStop = true;
            this.rbRotate0.Text = "Don\'t rotate";
            this.rbRotate0.UseVisualStyleBackColor = true;
            // 
            // rbRotate180
            // 
            this.rbRotate180.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate180.AutoSize = true;
            this.rbRotate180.Location = new System.Drawing.Point(3, 49);
            this.rbRotate180.Name = "rbRotate180";
            this.rbRotate180.Size = new System.Drawing.Size(92, 17);
            this.rbRotate180.TabIndex = 3;
            this.rbRotate180.TabStop = true;
            this.rbRotate180.Text = "Rotate 180°";
            this.rbRotate180.UseVisualStyleBackColor = true;
            // 
            // rbRotate270
            // 
            this.rbRotate270.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRotate270.AutoSize = true;
            this.rbRotate270.Location = new System.Drawing.Point(101, 49);
            this.rbRotate270.Name = "rbRotate270";
            this.rbRotate270.Size = new System.Drawing.Size(167, 17);
            this.rbRotate270.TabIndex = 3;
            this.rbRotate270.TabStop = true;
            this.rbRotate270.Text = "Rotate 90° Counter-Clockwise";
            this.rbRotate270.UseVisualStyleBackColor = true;
            // 
            // cbInverseColors
            // 
            this.cbInverseColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInverseColors.AutoSize = true;
            this.cbInverseColors.Location = new System.Drawing.Point(3, 72);
            this.cbInverseColors.Name = "cbInverseColors";
            this.cbInverseColors.Size = new System.Drawing.Size(92, 17);
            this.cbInverseColors.TabIndex = 4;
            this.cbInverseColors.Text = "Inverse";
            this.cbInverseColors.UseVisualStyleBackColor = true;
            // 
            // cbAlignRight
            // 
            this.cbAlignRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlignRight.AutoSize = true;
            this.cbAlignRight.Location = new System.Drawing.Point(101, 72);
            this.cbAlignRight.Name = "cbAlignRight";
            this.cbAlignRight.Size = new System.Drawing.Size(167, 17);
            this.cbAlignRight.TabIndex = 4;
            this.cbAlignRight.Text = "Align to right";
            this.cbAlignRight.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(290, 276);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 11;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(371, 276);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // cbMirrorBytes
            // 
            this.cbMirrorBytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMirrorBytes.AutoSize = true;
            this.cbMirrorBytes.Location = new System.Drawing.Point(3, 95);
            this.cbMirrorBytes.Name = "cbMirrorBytes";
            this.cbMirrorBytes.Size = new System.Drawing.Size(92, 17);
            this.cbMirrorBytes.TabIndex = 4;
            this.cbMirrorBytes.Text = "Mirror bytes";
            this.cbMirrorBytes.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(458, 311);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(groupBox1);
            this.Controls.Add(groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptions_FormClosing);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tlpStyles.ResumeLayout(false);
            tlpStyles.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSelectImageStyle;
        private System.Windows.Forms.TextBox tbImageStyleFilename;
        private System.Windows.Forms.TextBox tbFontStyleFilename;
        private System.Windows.Forms.Button bSelectFontStyle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox cbFlipHorizontal;
        private System.Windows.Forms.CheckBox cbFlipVertical;
        private System.Windows.Forms.RadioButton rbRotate90;
        private System.Windows.Forms.RadioButton rbRotate0;
        private System.Windows.Forms.RadioButton rbRotate180;
        private System.Windows.Forms.RadioButton rbRotate270;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.CheckBox cbInverseColors;
        private System.Windows.Forms.CheckBox cbAlignRight;
        private System.Windows.Forms.CheckBox cbMirrorBytes;

    }
}