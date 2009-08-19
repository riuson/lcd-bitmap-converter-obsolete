namespace lcd_bitmap_converter_mono
{
    partial class OptionsControl
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.tbImageStyleFilename = new System.Windows.Forms.TextBox();
            this.bSelectImageStyle = new System.Windows.Forms.Button();
            this.tlpStyles = new System.Windows.Forms.TableLayoutPanel();
            this.tbFontStyleFilename = new System.Windows.Forms.TextBox();
            this.bSelectFontStyle = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.tlpStyles.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 13);
            label1.TabIndex = 0;
            label1.Text = "Image xslt filename:";
            // 
            // tbImageStyleFilename
            // 
            this.tbImageStyleFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImageStyleFilename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbImageStyleFilename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tbImageStyleFilename.Location = new System.Drawing.Point(108, 7);
            this.tbImageStyleFilename.Name = "tbImageStyleFilename";
            this.tbImageStyleFilename.Size = new System.Drawing.Size(277, 20);
            this.tbImageStyleFilename.TabIndex = 1;
            // 
            // bSelectImageStyle
            // 
            this.bSelectImageStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelectImageStyle.AutoSize = true;
            this.bSelectImageStyle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bSelectImageStyle.Location = new System.Drawing.Point(391, 5);
            this.bSelectImageStyle.Name = "bSelectImageStyle";
            this.bSelectImageStyle.Size = new System.Drawing.Size(26, 23);
            this.bSelectImageStyle.TabIndex = 2;
            this.bSelectImageStyle.Text = "...";
            this.bSelectImageStyle.UseVisualStyleBackColor = true;
            this.bSelectImageStyle.Click += new System.EventHandler(this.OnClick);
            // 
            // tlpStyles
            // 
            this.tlpStyles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpStyles.ColumnCount = 3;
            this.tlpStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpStyles.Controls.Add(label1, 0, 0);
            this.tlpStyles.Controls.Add(this.bSelectImageStyle, 2, 0);
            this.tlpStyles.Controls.Add(this.tbImageStyleFilename, 1, 0);
            this.tlpStyles.Controls.Add(label2, 0, 1);
            this.tlpStyles.Controls.Add(this.tbFontStyleFilename, 1, 1);
            this.tlpStyles.Controls.Add(this.bSelectFontStyle, 2, 1);
            this.tlpStyles.Location = new System.Drawing.Point(3, 3);
            this.tlpStyles.Name = "tlpStyles";
            this.tlpStyles.RowCount = 2;
            this.tlpStyles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStyles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStyles.Size = new System.Drawing.Size(420, 68);
            this.tlpStyles.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 44);
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
            this.tbFontStyleFilename.Location = new System.Drawing.Point(108, 41);
            this.tbFontStyleFilename.Name = "tbFontStyleFilename";
            this.tbFontStyleFilename.Size = new System.Drawing.Size(277, 20);
            this.tbFontStyleFilename.TabIndex = 1;
            // 
            // bSelectFontStyle
            // 
            this.bSelectFontStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelectFontStyle.AutoSize = true;
            this.bSelectFontStyle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bSelectFontStyle.Location = new System.Drawing.Point(391, 39);
            this.bSelectFontStyle.Name = "bSelectFontStyle";
            this.bSelectFontStyle.Size = new System.Drawing.Size(26, 23);
            this.bSelectFontStyle.TabIndex = 2;
            this.bSelectFontStyle.Text = "...";
            this.bSelectFontStyle.UseVisualStyleBackColor = true;
            this.bSelectFontStyle.Click += new System.EventHandler(this.OnClick);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(348, 82);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.OnClick);
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.Location = new System.Drawing.Point(267, 82);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 4;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.OnClick);
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tlpStyles);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(426, 108);
            this.tlpStyles.ResumeLayout(false);
            this.tlpStyles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbImageStyleFilename;
        private System.Windows.Forms.Button bSelectImageStyle;
        private System.Windows.Forms.TableLayoutPanel tlpStyles;
        private System.Windows.Forms.TextBox tbFontStyleFilename;
        private System.Windows.Forms.Button bSelectFontStyle;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOk;

    }
}
