namespace lcd_bitmap_converter_mono
{
    partial class ImageEditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox groupBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditorControl));
            this.bApplyResize = new System.Windows.Forms.Button();
            this.bShrink = new System.Windows.Forms.Button();
            this.numBottom = new System.Windows.Forms.NumericUpDown();
            this.numTop = new System.Windows.Forms.NumericUpDown();
            this.numRight = new System.Windows.Forms.NumericUpDown();
            this.numLeft = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BmpEditor = new lcd_bitmap_converter_mono.BitmapEditorControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeft)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(this.tableLayoutPanel2);
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(118, 145);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Resize";
            // 
            // bApplyResize
            // 
            this.bApplyResize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bApplyResize.AutoSize = true;
            this.bApplyResize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bApplyResize.Location = new System.Drawing.Point(58, 81);
            this.bApplyResize.Name = "bApplyResize";
            this.bApplyResize.Size = new System.Drawing.Size(43, 23);
            this.bApplyResize.TabIndex = 1;
            this.bApplyResize.Text = "Apply";
            this.bApplyResize.UseVisualStyleBackColor = true;
            this.bApplyResize.Click += new System.EventHandler(this.OnClick);
            // 
            // bShrink
            // 
            this.bShrink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bShrink.AutoSize = true;
            this.bShrink.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bShrink.Location = new System.Drawing.Point(3, 81);
            this.bShrink.Name = "bShrink";
            this.bShrink.Size = new System.Drawing.Size(47, 23);
            this.bShrink.TabIndex = 1;
            this.bShrink.Text = "Shrink";
            this.bShrink.UseVisualStyleBackColor = true;
            this.bShrink.Click += new System.EventHandler(this.OnClick);
            // 
            // numBottom
            // 
            this.numBottom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numBottom.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.numBottom, 2);
            this.numBottom.Location = new System.Drawing.Point(32, 55);
            this.numBottom.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numBottom.Name = "numBottom";
            this.numBottom.Size = new System.Drawing.Size(41, 20);
            this.numBottom.TabIndex = 0;
            this.numBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBottom.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numTop
            // 
            this.numTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numTop.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.numTop, 2);
            this.numTop.Location = new System.Drawing.Point(32, 3);
            this.numTop.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numTop.Name = "numTop";
            this.numTop.Size = new System.Drawing.Size(41, 20);
            this.numTop.TabIndex = 0;
            this.numTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTop.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numRight
            // 
            this.numRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numRight.AutoSize = true;
            this.numRight.Location = new System.Drawing.Point(59, 29);
            this.numRight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numRight.Name = "numRight";
            this.numRight.Size = new System.Drawing.Size(41, 20);
            this.numRight.TabIndex = 0;
            this.numRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numLeft
            // 
            this.numLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numLeft.AutoSize = true;
            this.numLeft.Location = new System.Drawing.Point(6, 29);
            this.numLeft.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numLeft.Name = "numLeft";
            this.numLeft.Size = new System.Drawing.Size(41, 20);
            this.numLeft.TabIndex = 0;
            this.numLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLeft.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.BmpEditor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 298);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BmpEditor
            // 
            this.BmpEditor.BackColor = System.Drawing.Color.Transparent;
            this.BmpEditor.Bmp = ((System.Drawing.Bitmap)(resources.GetObject("BmpEditor.Bmp")));
            this.BmpEditor.BrightnessEdge = 0.5F;
            this.BmpEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BmpEditor.Location = new System.Drawing.Point(3, 3);
            this.BmpEditor.Name = "BmpEditor";
            this.BmpEditor.PointsHeight = 10;
            this.BmpEditor.PointsWidth = 10;
            this.BmpEditor.Size = new System.Drawing.Size(404, 292);
            this.BmpEditor.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(groupBox1);
            this.panel1.Location = new System.Drawing.Point(413, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 151);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.numLeft, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.bApplyResize, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.numRight, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.bShrink, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.numTop, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numBottom, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(106, 107);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ImageEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ImageEditorControl";
            this.Size = new System.Drawing.Size(540, 298);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeft)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bApplyResize;
        private System.Windows.Forms.Button bShrink;
        private System.Windows.Forms.NumericUpDown numBottom;
        private System.Windows.Forms.NumericUpDown numTop;
        private System.Windows.Forms.NumericUpDown numRight;
        private System.Windows.Forms.NumericUpDown numLeft;
        public BitmapEditorControl BmpEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
