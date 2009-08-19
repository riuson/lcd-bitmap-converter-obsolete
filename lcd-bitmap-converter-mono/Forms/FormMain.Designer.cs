namespace lcd_bitmap_converter_mono
{
    partial class FormMain
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRotate90 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRotate180 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRotate270 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInverse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(229, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(131, 6);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewImage,
            this.tsmiNewFont,
            this.tsmiOpen,
            this.tsmiSave,
            this.tsmiSaveAs,
            toolStripSeparator4,
            this.tsmiQuit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "File";
            // 
            // tsmiNewImage
            // 
            this.tsmiNewImage.Name = "tsmiNewImage";
            this.tsmiNewImage.Size = new System.Drawing.Size(134, 22);
            this.tsmiNewImage.Text = "New Image";
            this.tsmiNewImage.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiNewFont
            // 
            this.tsmiNewFont.Name = "tsmiNewFont";
            this.tsmiNewFont.Size = new System.Drawing.Size(134, 22);
            this.tsmiNewFont.Text = "New Font";
            this.tsmiNewFont.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(134, 22);
            this.tsmiOpen.Text = "Open...";
            this.tsmiOpen.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(134, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Size = new System.Drawing.Size(134, 22);
            this.tsmiSaveAs.Text = "Save As...";
            this.tsmiSaveAs.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(134, 22);
            this.tsmiQuit.Text = "Quit";
            this.tsmiQuit.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFlipHorizontal,
            this.tsmiFlipVertical,
            toolStripSeparator2,
            this.tsmiRotate90,
            this.tsmiRotate180,
            this.tsmiRotate270,
            toolStripSeparator3,
            this.tsmiInverse,
            this.tsmiConvert,
            toolStripSeparator1,
            this.tsmiOptions});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(39, 20);
            this.tsmiEdit.Text = "Edit";
            // 
            // tsmiFlipHorizontal
            // 
            this.tsmiFlipHorizontal.Name = "tsmiFlipHorizontal";
            this.tsmiFlipHorizontal.Size = new System.Drawing.Size(232, 22);
            this.tsmiFlipHorizontal.Text = "Flip Horizontal";
            this.tsmiFlipHorizontal.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiFlipVertical
            // 
            this.tsmiFlipVertical.Name = "tsmiFlipVertical";
            this.tsmiFlipVertical.Size = new System.Drawing.Size(232, 22);
            this.tsmiFlipVertical.Text = "Flip Vertical";
            this.tsmiFlipVertical.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiRotate90
            // 
            this.tsmiRotate90.Name = "tsmiRotate90";
            this.tsmiRotate90.Size = new System.Drawing.Size(232, 22);
            this.tsmiRotate90.Text = "Rotate 90° Clockwise";
            this.tsmiRotate90.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiRotate180
            // 
            this.tsmiRotate180.Name = "tsmiRotate180";
            this.tsmiRotate180.Size = new System.Drawing.Size(232, 22);
            this.tsmiRotate180.Text = "Rotate 180°";
            this.tsmiRotate180.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiRotate270
            // 
            this.tsmiRotate270.Name = "tsmiRotate270";
            this.tsmiRotate270.Size = new System.Drawing.Size(232, 22);
            this.tsmiRotate270.Text = "Rotate 90° Counter-Clockwise";
            this.tsmiRotate270.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiInverse
            // 
            this.tsmiInverse.Name = "tsmiInverse";
            this.tsmiInverse.Size = new System.Drawing.Size(232, 22);
            this.tsmiInverse.Text = "Inverse";
            this.tsmiInverse.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiConvert
            // 
            this.tsmiConvert.Name = "tsmiConvert";
            this.tsmiConvert.Size = new System.Drawing.Size(232, 22);
            this.tsmiConvert.Text = "Convert...";
            this.tsmiConvert.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.Name = "tsmiOptions";
            this.tsmiOptions.Size = new System.Drawing.Size(232, 22);
            this.tsmiOptions.Text = "Options...";
            this.tsmiOptions.Click += new System.EventHandler(this.OnMenuItemClick);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(714, 413);
            this.tcMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(706, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 212);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 437);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "LCD Bitmap Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewFont;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiInverse;
        private System.Windows.Forms.ToolStripMenuItem tsmiConvert;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tsmiFlipVertical;
        private System.Windows.Forms.ToolStripMenuItem tsmiRotate90;
        private System.Windows.Forms.ToolStripMenuItem tsmiRotate180;
        private System.Windows.Forms.ToolStripMenuItem tsmiRotate270;

    }
}