namespace lcd_bitmap_converter_mono
{
    partial class FormCharSelector
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.lbRanges = new System.Windows.Forms.ListBox();
            this.lbChars = new System.Windows.Forms.ListBox();
            this.lSelectedChar = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.bCancel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.bOk, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbRanges, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbChars, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lSelectedChar, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(465, 369);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 0;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(384, 369);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 0;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            // 
            // lbRanges
            // 
            this.lbRanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lbRanges, 3);
            this.lbRanges.FormattingEnabled = true;
            this.lbRanges.IntegralHeight = false;
            this.lbRanges.Location = new System.Drawing.Point(3, 3);
            this.lbRanges.Name = "lbRanges";
            this.lbRanges.Size = new System.Drawing.Size(537, 104);
            this.lbRanges.TabIndex = 1;
            this.lbRanges.SelectedIndexChanged += new System.EventHandler(this.OnClick);
            // 
            // lbChars
            // 
            this.lbChars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lbChars, 3);
            this.lbChars.FormattingEnabled = true;
            this.lbChars.IntegralHeight = false;
            this.lbChars.Location = new System.Drawing.Point(3, 113);
            this.lbChars.MultiColumn = true;
            this.lbChars.Name = "lbChars";
            this.lbChars.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbChars.Size = new System.Drawing.Size(537, 250);
            this.lbChars.TabIndex = 1;
            this.lbChars.SelectedIndexChanged += new System.EventHandler(this.OnClick);
            // 
            // lSelectedChar
            // 
            this.lSelectedChar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lSelectedChar.AutoSize = true;
            this.lSelectedChar.BackColor = System.Drawing.Color.Transparent;
            this.lSelectedChar.Location = new System.Drawing.Point(3, 374);
            this.lSelectedChar.Name = "lSelectedChar";
            this.lSelectedChar.Size = new System.Drawing.Size(0, 13);
            this.lSelectedChar.TabIndex = 2;
            // 
            // FormCharSelector
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(543, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCharSelector";
            this.Text = "Characters selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCharSelector_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.ListBox lbRanges;
        private System.Windows.Forms.ListBox lbChars;
        private System.Windows.Forms.Label lSelectedChar;
    }
}