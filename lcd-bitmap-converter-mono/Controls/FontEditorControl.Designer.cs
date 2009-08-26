namespace lcd_bitmap_converter_mono
{
    partial class FontEditorControl
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
            System.Windows.Forms.Label label3;
            this.lbCharacters = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bAddChar = new System.Windows.Forms.Button();
            this.bDelChar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bApplyFont = new System.Windows.Forms.Button();
            this.clbFontStyles = new System.Windows.Forms.CheckedListBox();
            this.cbFontFamilies = new System.Windows.Forms.ComboBox();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.ImageEditor = new lcd_bitmap_converter_mono.ImageEditorControl();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCharacters
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbCharacters, 2);
            this.lbCharacters.ColumnWidth = 10;
            this.lbCharacters.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbCharacters.FormattingEnabled = true;
            this.lbCharacters.IntegralHeight = false;
            this.lbCharacters.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "89"});
            this.lbCharacters.Location = new System.Drawing.Point(3, 78);
            this.lbCharacters.MultiColumn = true;
            this.lbCharacters.Name = "lbCharacters";
            this.lbCharacters.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCharacters.Size = new System.Drawing.Size(145, 60);
            this.lbCharacters.TabIndex = 0;
            this.lbCharacters.SelectedIndexChanged += new System.EventHandler(this.OnCharSelect);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 2);
            this.textBox1.Location = new System.Drawing.Point(3, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 1;
            // 
            // bAddChar
            // 
            this.bAddChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddChar.Location = new System.Drawing.Point(3, 49);
            this.bAddChar.Name = "bAddChar";
            this.bAddChar.Size = new System.Drawing.Size(69, 23);
            this.bAddChar.TabIndex = 2;
            this.bAddChar.Text = "Add";
            this.bAddChar.UseVisualStyleBackColor = true;
            this.bAddChar.Click += new System.EventHandler(this.OnClick);
            // 
            // bDelChar
            // 
            this.bDelChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bDelChar.Location = new System.Drawing.Point(78, 49);
            this.bDelChar.Name = "bDelChar";
            this.bDelChar.Size = new System.Drawing.Size(70, 23);
            this.bDelChar.TabIndex = 2;
            this.bDelChar.Text = "Delete";
            this.bDelChar.UseVisualStyleBackColor = true;
            this.bDelChar.Click += new System.EventHandler(this.OnClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bApplyFont, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.clbFontStyles, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCharacters, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbFontFamilies, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.bAddChar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bDelChar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numFontSize, 1, 6);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(295, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(151, 337);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bApplyFont
            // 
            this.bApplyFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.bApplyFont, 2);
            this.bApplyFont.Location = new System.Drawing.Point(3, 311);
            this.bApplyFont.Name = "bApplyFont";
            this.bApplyFont.Size = new System.Drawing.Size(145, 23);
            this.bApplyFont.TabIndex = 2;
            this.bApplyFont.Text = "Apply Font";
            this.bApplyFont.UseVisualStyleBackColor = true;
            this.bApplyFont.Click += new System.EventHandler(this.OnClick);
            // 
            // clbFontStyles
            // 
            this.clbFontStyles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbFontStyles.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.clbFontStyles, 2);
            this.clbFontStyles.FormattingEnabled = true;
            this.clbFontStyles.IntegralHeight = false;
            this.clbFontStyles.Location = new System.Drawing.Point(3, 211);
            this.clbFontStyles.Name = "clbFontStyles";
            this.clbFontStyles.Size = new System.Drawing.Size(145, 94);
            this.clbFontStyles.TabIndex = 3;
            // 
            // cbFontFamilies
            // 
            this.cbFontFamilies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cbFontFamilies, 2);
            this.cbFontFamilies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontFamilies.FormattingEnabled = true;
            this.cbFontFamilies.Location = new System.Drawing.Point(3, 164);
            this.cbFontFamilies.Name = "cbFontFamilies";
            this.cbFontFamilies.Size = new System.Drawing.Size(145, 21);
            this.cbFontFamilies.TabIndex = 2;
            // 
            // numFontSize
            // 
            this.numFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numFontSize.Location = new System.Drawing.Point(78, 191);
            this.numFontSize.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(70, 20);
            this.numFontSize.TabIndex = 4;
            this.numFontSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 191);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 13);
            label1.TabIndex = 5;
            label1.Text = "Font size:";
            // 
            // ImageEditor
            // 
            this.ImageEditor.BackColor = System.Drawing.Color.Transparent;
            this.ImageEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageEditor.Location = new System.Drawing.Point(0, 0);
            this.ImageEditor.Name = "ImageEditor";
            this.ImageEditor.Size = new System.Drawing.Size(295, 337);
            this.ImageEditor.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 3);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(69, 13);
            label2.TabIndex = 5;
            label2.Text = "Characters:";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 141);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 20);
            label3.TabIndex = 5;
            label3.Text = "System fonts:";
            // 
            // FontEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ImageEditor);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FontEditorControl";
            this.Size = new System.Drawing.Size(446, 337);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbCharacters;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bDelChar;
        private System.Windows.Forms.Button bAddChar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbFontFamilies;
        private System.Windows.Forms.CheckedListBox clbFontStyles;
        private System.Windows.Forms.Button bApplyFont;
        public ImageEditorControl ImageEditor;
        private System.Windows.Forms.NumericUpDown numFontSize;
    }
}
