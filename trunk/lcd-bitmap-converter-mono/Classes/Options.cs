﻿using System;
using System.IO;
using System.Windows.Forms;

namespace lcd_bitmap_converter_mono
{
    public class Options
    {
        private bool mOperationFlipHorizontal;
        private bool mOperationFlipVertical;
        private RotateAngle mOperationRotateAngle;
        private string mImageStyleFilename;
        private string mFontStyleFilename;

        public Options()
        {
            this.mOperationFlipHorizontal = false;
            this.mOperationFlipVertical = false;
            this.mOperationRotateAngle = RotateAngle.None;

            this.mImageStyleFilename = String.Empty;
            this.mFontStyleFilename = String.Empty;
        }

        public bool OperationFlipHorizontal
        {
            get { return this.mOperationFlipHorizontal; }
            set { this.mOperationFlipHorizontal = value; }
        }
        public bool OperationFlipVertical
        {
            get { return this.mOperationFlipVertical; }
            set { this.mOperationFlipVertical = value; }
        }
        public RotateAngle OperationRotateAngle
        {
            get { return this.mOperationRotateAngle; }
            set { this.mOperationRotateAngle = value; }
        }

        public static string ApplicationDirectory
        {
            get
            {
                return Path.GetDirectoryName(Application.ExecutablePath);
            }
        }
        public string ImageStyleFilename
        {
            get { return this.mImageStyleFilename; }
            set { this.mImageStyleFilename = value; }
        }
        public string FontStyleFilename
        {
            get { return this.mFontStyleFilename; }
            set { this.mFontStyleFilename = value; }
        }
    }
}
