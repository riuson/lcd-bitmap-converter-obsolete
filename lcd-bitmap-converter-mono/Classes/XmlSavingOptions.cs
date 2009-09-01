using System;
using System.Collections.Generic;
using System.Text;

namespace lcd_bitmap_converter_mono
{
    public class XmlSavingOptions
    {
        private bool mFlipHorizontal;
        private bool mFlipVertical;
        private RotateAngle mAngle;
        private bool mInverse;
        private bool mAlignRight;
        private bool mMirrorEachByte;

        public XmlSavingOptions()
        {
            this.mFlipHorizontal = false;
            this.mFlipVertical = false;
            this.mAngle = RotateAngle.None;
            this.mInverse = false;
            this.mAlignRight = false;
            this.mMirrorEachByte = false;
        }
        public XmlSavingOptions(bool flipHorizontal, bool flipVertical, RotateAngle angle, bool inverse, bool alignRight, bool mirrorEachByte)
        {
            this.mFlipHorizontal = flipHorizontal;
            this.mFlipVertical = flipVertical;
            this.mAngle = angle;
            this.mInverse = inverse;
            this.mAlignRight = alignRight;
            this.mMirrorEachByte = mirrorEachByte;
        }

        public bool FlipHorizontal
        {
            get { return this.mFlipHorizontal; }
            set { this.mFlipHorizontal = value; }
        }
        public bool FlipVertical
        {
            get { return this.mFlipVertical; }
            set { this.mFlipVertical = value; }
        }
        public RotateAngle Angle
        {
            get { return this.mAngle; }
            set { this.mAngle = value; }
        }
        public bool Inverse
        {
            get { return this.mInverse; }
            set { this.mInverse = value; }
        }
        public bool AlignRight
        {
            get { return this.mAlignRight; }
            set { this.mAlignRight = value; }
        }
        public bool MirrorEachByte
        {
            get { return this.mMirrorEachByte; }
            set { this.mMirrorEachByte = value; }
        }
    }
}
