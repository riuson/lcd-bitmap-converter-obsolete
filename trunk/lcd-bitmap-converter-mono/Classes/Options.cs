using System;

namespace lcd_bitmap_converter_mono
{
    public class Options
    {
        private bool mOperationFlipHorizontal;
        private bool mOperationFlipVertical;
        private RotateAngle mOperationRotateAngle;

        public Options()
        {
            this.mOperationFlipHorizontal = false;
            this.mOperationFlipVertical = false;
            this.mOperationRotateAngle = RotateAngle.None;
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
    }
}
