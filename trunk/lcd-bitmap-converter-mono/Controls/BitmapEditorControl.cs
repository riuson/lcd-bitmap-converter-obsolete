using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

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
        private bool mMouseDown;
        private bool mSetOnMove;
        private float mBrightnessEdge;

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

            this.mBmp = new Bitmap(this.mPointsWidth, this.mPointsHeight);
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
                    }
                }
            }
        }

        private void CalcCell(int mouseX, int mouseY, out int x, out int y)
        {
            float dx = (this.Width - this.Margin.Horizontal) / (float)this.mPointsWidth;
            float dy = (this.Height - this.Margin.Vertical) / (float)this.mPointsHeight;

            float a = (mouseX - this.Margin.Left) / dx;
            x = Convert.ToInt32(Math.Truncate(a));
            float b = (mouseY - this.Margin.Top) / dy;
            y = Convert.ToInt32(Math.Truncate(b));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //int xsel = 0, ysel = 0;
            float dx = (this.Width - this.Margin.Horizontal) / (float)this.mPointsWidth;
            float dy = (this.Height - this.Margin.Vertical) / (float)this.mPointsHeight;
            //горизонтальные линии
            for (int i = 0; i <= this.mPointsWidth; i++)
            {
                float x = this.Margin.Left + dx * i;
                if (dx > 10)
                {
                    e.Graphics.DrawLine(
                        this.mGridPen,
                        //начальная точка
                        x,
                        0 + this.Margin.Top,
                        //конечная точка
                        x,
                        this.Height - this.Margin.Bottom);
                }
                //if (i == this.mMouseOverX)
                    //xsel = Convert.ToInt32(x);
            }
            //вертикальные линии
            for (int i = 0; i <= this.mPointsHeight; i++)
            {
                float y = this.Margin.Top + dy * i;
                if (dy > 10)
                {
                    e.Graphics.DrawLine(
                        this.mGridPen,
                        0 + this.Margin.Left,
                        y,
                        this.Width - this.Margin.Right,
                        y);
                }
                //if (i == this.mMouseOverY)
                    //ysel = Convert.ToInt32(y);
            }
            for (int i = 0; i < this.mPointsWidth; i++)
            {
                for (int j = 0; j < this.mPointsHeight; j++)
                {
                    Color pixelColor = this.mBmp.GetPixel(i, j);
                    RectangleF cellRect = this.GetCellRect(i, j);
                    if(dx > 10 && dy > 10)
                    cellRect.Inflate(-1, -1);
                    float br = pixelColor.GetBrightness();
                    if (br > this.mBrightnessEdge)
                        e.Graphics.FillRectangle(Brushes.Black, cellRect);
                    else
                        e.Graphics.FillRectangle(Brushes.Wheat, cellRect);
                }
            }
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
            this.SelectCell(e.X, e.Y);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.mMouseDown = false;
            this.SelectCell(-1, -1);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mMouseDown = true;
            int x, y;
            this.CalcCell(e.X, e.Y, out x, out y);
            if (this.mBmp.GetPixel(x, y).GetBrightness() > this.mBrightnessEdge)
            {
                this.mBmp.SetPixel(x, y, Color.Black);
                this.mSetOnMove = true;
            }
            else
            {
                this.mBmp.SetPixel(x, y, Color.Transparent);
                this.mSetOnMove = false;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.mMouseDown = false;
        }

        private RectangleF GetCellRect(int x, int y)
        {
            float dx = (this.Width - this.Margin.Horizontal) / (float)this.mPointsWidth;
            float dy = (this.Height - this.Margin.Vertical) / (float)this.mPointsHeight;
            RectangleF rect = new RectangleF(
                0 + this.Margin.Left + x * dx,
                0 + this.Margin.Top + y * dy,
                dx,
                dy);
            return rect;
        }
        private void InvalidateCell(int x, int y)
        {
            RectangleF rectCell = this.GetCellRect(x, y);
            this.Invalidate(Rectangle.Ceiling(rectCell));
        }
        private void SelectCell(int x, int y)
        {
            bool reset = false;
            if (x < 0 && y < 0)
            {
                reset = true;
            }

            //int oldX = this.mMouseOverX;
            //int oldY = this.mMouseOverY;

            int newX = -1;
            int newY = -1;

            if (!reset)
            {
                this.CalcCell(x, y, out newX, out newY);
                if (newX < 0 || newX >= this.mPointsWidth || newY < 0 || newY >= this.mPointsHeight)
                    reset = true;
            }

            this.mMouseOverX = newX;
            this.mMouseOverY = newY;

            //this.InvalidateCell(oldX, oldY);
            if (!reset)
            {
                if (this.mMouseDown)
                {
                    if (this.mSetOnMove)
                        this.mBmp.SetPixel(newX, newY, Color.Black);
                    else
                        this.mBmp.SetPixel(newX, newY, Color.Transparent);
                }
                this.InvalidateCell(newX, newY);
            }
        }
    }
}
