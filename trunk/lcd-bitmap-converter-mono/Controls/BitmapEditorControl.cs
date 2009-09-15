using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Imaging;

namespace lcd_bitmap_converter_mono
{
    public class BitmapEditorControl : UserControl
    {
        private int mPointsWidth;
        private int mPointsHeight;
        private Pen mGridPen;
        //private Pen mSelPen;
        private int mMouseOverX;
        private int mMouseOverY;
        private Bitmap mBmp;
        //private bool mSetOnMove;
        private float mBrightnessEdge;
        private Bitmap mBmpPreview;
        //private byte[] mBmpData;
        private int mScale;

        public BitmapEditorControl()
        {
            //InitializeComponent();
            this.SuspendLayout();
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "BitmapEditorControl";
            this.Size = new System.Drawing.Size(200, 160);
            this.ResumeLayout(false);

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.mGridPen = new Pen(Color.Silver);
            //this.mSelPen = new Pen(Color.Gray);
            this.mPointsHeight = 10;
            this.mPointsWidth = 10;
            this.mMouseOverX = 0;
            this.mMouseOverY = 0;

            this.mBrightnessEdge = 0.5f;

            this.mBmp = new Bitmap(this.mPointsWidth, this.mPointsHeight, PixelFormat.Format1bppIndexed);

            bool def = SavedContainer<Options>.Instance.SetBitsByDefault;
            BitmapData bmd = this.mBmp.LockBits(new Rectangle(0, 0, this.mPointsWidth, this.mPointsHeight), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            for (int x = 0; x < this.mPointsWidth; x++)
            {
                for (int y = 0; y < this.mPointsHeight; y++)
                {
                    BitmapHelper.SetPixel(bmd, x, y, def);
                }
            }
            this.mBmp.UnlockBits(bmd);

            //this.SetPixel(0, 0, true);
            //this.SetPixel(this.mPointsWidth - 1, 0, true);
            //this.SetPixel(0, this.mPointsHeight - 1, true);
            //this.SetPixel(this.mPointsWidth - 1, this.mPointsHeight - 1, true);

            this.mBmpPreview = new Bitmap(this.mPointsWidth, this.mPointsHeight);
            this.mScale = 1;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public int PointsWidth
        {
            get { return this.mPointsWidth; }
            set { this.mPointsWidth = value; }
        }
        public int PointsHeight
        {
            get { return this.mPointsHeight; }
            set { this.mPointsHeight = value; }
        }
        public float BrightnessEdge
        {
            get { return this.mBrightnessEdge; }
            set { this.mBrightnessEdge = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bitmap Bmp
        {
            get { return this.mBmp; }
            set
            {
                if (value != null)
                {
                    if (value.Width > 2 && value.Height > 2)
                    {
                        this.mBmp = value;
                        this.mPointsWidth = value.Width;
                        this.mPointsHeight = value.Height;
                        this.Invalidate();
                    }
                }
            }
        }

        private void CalcCell(int mouseX, int mouseY, out int x, out int y)
        {
            //float dx = (this.Width - this.Margin.Horizontal) / (float)this.mPointsWidth;
            //float dy = (this.Height - this.Margin.Vertical) / (float)this.mPointsHeight;

            float a = mouseX / this.mScale;
            x = Convert.ToInt32(Math.Truncate(a));
            float b = mouseY / this.mScale;
            y = Convert.ToInt32(Math.Truncate(b));
            if (x >= this.mPointsWidth || y >= this.mPointsHeight ||
                x < 0 || y < 0)
                x = y = -1;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //int xsel = 0, ysel = 0;
            //float dx = (this.Width - this.Margin.Horizontal) / (float)this.mPointsWidth;
            //float dy = (this.Height - this.Margin.Vertical) / (float)this.mPointsHeight;
            //горизонтальные линии
            //if (dx < 10)
            //{
            //    for (int i = 0; i <= this.mPointsWidth; i++)
            //    {
            //        float x = this.Margin.Left + dx * i;
            //        e.Graphics.DrawLine(
            //            this.mGridPen,
            //            //начальная точка
            //            x,
            //            0 + this.Margin.Top,
            //            //конечная точка
            //            x,
            //            this.Height - this.Margin.Bottom);
            //    }
            //    //if (i == this.mMouseOverX)
            //    //xsel = Convert.ToInt32(x);
            //}
            //вертикальные линии
            //if (dy < 10)
            //{
            //    for (int i = 0; i <= this.mPointsHeight; i++)
            //    {
            //        float y = this.Margin.Top + dy * i;
            //        e.Graphics.DrawLine(
            //            this.mGridPen,
            //            0 + this.Margin.Left,
            //            y,
            //            this.Width - this.Margin.Right,
            //            y);
            //    }
            //    //if (i == this.mMouseOverY)
            //    //ysel = Convert.ToInt32(y);
            //}
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //e.Graphics.DrawImage(this.mBmp, Rectangle.FromLTRB(0 + this.Margin.Left, 0 + this.Margin.Top, this.Width - this.Margin.Right, this.Height - this.Margin.Bottom));
            //e.Graphics.DrawImage(this.mBmp, 0, 0, this.mBmpPreview.Width, this.mBmpPreview.Height);
            this.UpdatePreview();
            e.Graphics.DrawImageUnscaled(this.mBmpPreview, 0, 0);
            //e.Graphics.DrawEllipse(this.mGridPen, Rectangle.FromLTRB(0 + this.Margin.Left, 0 + this.Margin.Top, this.Width - this.Margin.Right, this.Height - this.Margin.Bottom));
            //e.Graphics.DrawEllipse(this.mGridPen, xsel, ysel, 10, 10);
            //RectangleF rectSel = new RectangleF(xsel, ysel, dx, dy);
            //rectSel.Inflate(-1, -1);
            //e.Graphics.DrawEllipse(this.mSelPen, rectSel);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //this.CalcCell(e.X, e.Y, out this.mMouseOverX, out this.mMouseOverY);
            //this.Invalidate();
            //this.InvalidateCell(x, y);
            if (e.Button == MouseButtons.Left)
                this.SelectCell(e.X, e.Y, true);
            if (e.Button == MouseButtons.Right)
                this.SelectCell(e.X, e.Y, false);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.SelectCell(-1, -1, false);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
                this.SelectCell(e.X, e.Y, true);
            if (e.Button == MouseButtons.Right)
                this.SelectCell(e.X, e.Y, false);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        private Rectangle GetCellRect(int x, int y)
        {
            //float dx = this.Width / (float)this.mPointsWidth;
            //float dy = this.Height / (float)this.mPointsHeight;
            Rectangle rect = new Rectangle(
                0 + this.Margin.Left + x * this.mScale,
                0 + this.Margin.Top + y * this.mScale,
                this.mScale,
                this.mScale);
            return rect;
        }
        private void InvalidateCell(int x, int y)
        {
            Rectangle rectCell = this.GetCellRect(x, y);
            rectCell.Inflate(4, 4);
            this.Invalidate(rectCell);
            //this.Invalidate();
        }
        private void SelectCell(int x, int y, bool value)
        {
            bool leave = false;
            if (x < 0 && y < 0)
            {
                leave = true;
            }

            int oldX = this.mMouseOverX;
            int oldY = this.mMouseOverY;

            int newX = -1;
            int newY = -1;

            if (!leave)
            {
                this.CalcCell(x, y, out newX, out newY);
                if (newX < 0 || newX >= this.mPointsWidth || newY < 0 || newY >= this.mPointsHeight)
                    leave = true;
            }

            this.mMouseOverX = newX;
            this.mMouseOverY = newY;

            //this.InvalidateCell(oldX, oldY);
            if (!leave)
            {
                if (value)
                    this.SetPixel(newX, newY, true);
                else
                    this.SetPixel(newX, newY, false);
                this.InvalidateCell(newX, newY);
            }
        }
        private void SetPixel(int x, int y, bool value)
        {
            unsafe
            {
                BitmapData bmd = this.mBmp.LockBits(Rectangle.FromLTRB(0, 0, this.mBmp.Width, this.mBmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                byte* ptr = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x / 8);
                byte b = *ptr;

                byte mask = Convert.ToByte(0x80 >> (x % 8));
                if (value)
                    *ptr = Convert.ToByte(b | mask);
                else
                    *ptr = Convert.ToByte(b & ~mask);

                this.mBmp.UnlockBits(bmd);
            }
        }
        private bool GetPixel(int x, int y)
        {
            bool result = false;
            unsafe
            {
                BitmapData bmd = this.mBmp.LockBits(Rectangle.FromLTRB(0, 0, this.mBmp.Width, this.mBmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                byte* ptr = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x / 8);
                byte b = *ptr;

                byte mask = Convert.ToByte(0x80 >> (x % 8));
                if ((b & mask) != 0)
                    result = true;
                else
                    result = false;

                this.mBmp.UnlockBits(bmd);
            }
            return result;
        }
        private void UpdatePreview()
        {
            int scaleX = this.Width / this.mPointsWidth;
            int scaleY = this.Height / this.mPointsHeight;
            this.mScale = Math.Min(scaleX, scaleY);
            if (this.mScale == 0)
                this.mScale = 1;
            int previewWidth = this.mPointsWidth * this.mScale;
            int previewHeight = this.mPointsHeight * this.mScale;

            if (this.mBmpPreview.Width != previewWidth || this.mBmpPreview.Height != previewHeight)
            {
                //if (this.mBmpPreview != null)
                //    this.mBmpPreview.Dispose();
                //if (this.mBmpData != null)
                //    this.mBmpData = null;

                int stride = Convert.ToInt32(Math.Ceiling((float)previewWidth / 8.0f));
                this.mBmpPreview = new Bitmap(previewWidth, previewHeight, PixelFormat.Format1bppIndexed);
            }
            Rectangle rectSource = Rectangle.FromLTRB(0, 0, this.mPointsWidth - 1, this.mPointsHeight - 1);
            BitmapData bmdSource = this.mBmp.LockBits(rectSource, ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
            BitmapData bmdDestination = this.mBmpPreview.LockBits(Rectangle.FromLTRB(0, 0, previewWidth, previewHeight), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);

            for (int x = 0; x < this.mPointsWidth; x++)
            {
                //System.Diagnostics.Debug.WriteLine(" ");
                for (int y = 0; y < this.mPointsHeight; y++)
                {
                    bool value = BitmapHelper.GetPixel(bmdSource, x, y);
                    //System.Diagnostics.Debug.Write(String.Format("{0}", value ? 1 : 0));
                    int destX = x * this.mScale;
                    int destY = y * this.mScale;

                    for (int x2 = 0; x2 < this.mScale; x2++)
                    {
                        for (int y2 = 0; y2 < this.mScale; y2++)
                        {
                            if (destX + x2 >= previewWidth || destY + y2 >= previewHeight)
                            {
                            }
                            else
                            {
                                BitmapHelper.SetPixel(bmdDestination, destX + x2, destY + y2, value);
                            }
                        }
                    }
                }
            }

            this.mBmp.UnlockBits(bmdSource);
            this.mBmpPreview.UnlockBits(bmdDestination);
        }

        public void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            this.mBmp = BitmapHelper.RotateFlip(this.mBmp, horizontalFlip, verticalFlip, angle);
            this.Invalidate();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BitmapEditorControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "BitmapEditorControl";
            this.ResumeLayout(false);

        }
    }
}
