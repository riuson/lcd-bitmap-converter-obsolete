using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;

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
            Graphics.FromImage(this.mBmp).FillRectangle(Brushes.White, 0, 0, this.mPointsWidth, this.mPointsHeight);
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
                        this.Invalidate();
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
            //base.OnPaint(e);
            //int xsel = 0, ysel = 0;
            float dx = (this.Width - this.Margin.Horizontal) / (float)this.mPointsWidth;
            float dy = (this.Height - this.Margin.Vertical) / (float)this.mPointsHeight;
            //горизонтальные линии
            if (dx > 10)
            {
                for (int i = 0; i <= this.mPointsWidth; i++)
                {
                    float x = this.Margin.Left + dx * i;
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
            if (dy > 10)
            {
                for (int i = 0; i <= this.mPointsHeight; i++)
                {
                    float y = this.Margin.Top + dy * i;
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
            /*for (int i = 0; i < this.mPointsWidth; i++)
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
            */
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(this.mBmp, Rectangle.FromLTRB(0 + this.Margin.Left, 0 + this.Margin.Top, this.Width - this.Margin.Right, this.Height - this.Margin.Bottom));
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
                this.mBmp.SetPixel(x, y, Color.White);
                this.mSetOnMove = false;
            }
            this.InvalidateCell(x, y);
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
            rectCell.Inflate(4, 4);
            this.Invalidate(Rectangle.Ceiling(rectCell));
        }
        private void SelectCell(int x, int y)
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
                if (this.mMouseDown)
                {
                    if (this.mSetOnMove)
                        this.mBmp.SetPixel(newX, newY, Color.Black);
                    else
                        this.mBmp.SetPixel(newX, newY, Color.White);
                }
                if(newX != oldX || newY != oldY)
                    this.InvalidateCell(newX, newY);
            }
        }
        public void SaveToXml(XmlNode node)
        {
            //separate node for bitmap's data
            //XmlNode nodeBitmap = node.AppendChild(node.OwnerDocument.CreateElement("bitmap"));
            XmlNode nodeBitmap = node;
            //bitmap info
            (nodeBitmap as XmlElement).SetAttribute("width", Convert.ToString(this.mBmp.Width, CultureInfo.InvariantCulture));
            (nodeBitmap as XmlElement).SetAttribute("height", Convert.ToString(this.mBmp.Height, CultureInfo.InvariantCulture));
            //preview node, all bits at one line
            XmlNode nodePreview = nodeBitmap.AppendChild(node.OwnerDocument.CreateElement("preview"));
            for (int y = 0; y < this.mBmp.Height; y++)
            {
                //bitmap's line
                XmlNode nodeLine = nodeBitmap.AppendChild(node.OwnerDocument.CreateElement("line"));
                (nodeLine as XmlElement).SetAttribute("index", Convert.ToString(y, CultureInfo.InvariantCulture));
                
                StringBuilder byteData = new StringBuilder();
                StringBuilder lineData = new StringBuilder();
                for (int x = 0; x < this.mBmp.Width; x++)
                {
                    if(this.mBmp.GetPixel(x, y).GetBrightness() > this.mBrightnessEdge)
                    byteData.Append("0");
                    else
                    byteData.Append("1");
                    //if byte filled or end of line
                    if((x % 8) == 7 || x == (this.mBmp.Width - 1))
                    {
                        XmlNode nodeColumn = nodeLine.AppendChild(node.OwnerDocument.CreateElement("column"));
                        (nodeColumn as XmlElement).SetAttribute("index", Convert.ToString((int)(x / 8), CultureInfo.InvariantCulture));
                        
                        //ensure what 8 bits (1 byte)
                        while(byteData.Length < 8)
                        byteData.Append("0");
                        
                        nodeColumn.InnerText = byteData.ToString();
                        lineData.Append(byteData);
                        byteData.Length = 0;
                    }
                }
                XmlNode nodePreviewLine = nodePreview.AppendChild(node.OwnerDocument.CreateElement("line"));
                nodePreviewLine.InnerText = lineData.ToString();
            }
        }
        public void LoadFromXml(XmlNode node)
        {
            int width = Convert.ToInt32(node.Attributes["width"].Value, CultureInfo.InvariantCulture);
            int height = Convert.ToInt32(node.Attributes["height"].Value, CultureInfo.InvariantCulture);
            Bitmap bmp = new Bitmap(width, height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White, 0, 0, width, height);
            for (int y = 0; y < height; y++)
            {
                string ypath = String.Format(CultureInfo.InvariantCulture, "line[@index={0}]", y);
                XmlNode nodeLine = node.SelectSingleNode(ypath);
                if(nodeLine == null)
                throw new Exception("Line node not found: " + ypath);
                for (int x = 0; x < width; x++)
                {
                    int col = Convert.ToInt32(x / 8);
                    int subx = x % 8;
                    string xpath = String.Format(CultureInfo.InvariantCulture, "column[@index={0}]", col);
                    XmlNode nodeColumn = nodeLine.SelectSingleNode(xpath);
                    if(nodeColumn == null)
                        throw new Exception("Column node not found: " + xpath);
                    string byteData = nodeColumn.InnerText;
                    if(byteData[subx] == '0')
                        bmp.SetPixel(x, y, Color.White);
                    else
                        bmp.SetPixel(x, y, Color.Black);
                }
            }
            this.mBmp = bmp;
            this.Invalidate();
        }
        public void RotateFlip(bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            int index = 0;
            if(horizontalFlip)
                index |= 1;
            if(verticalFlip)
                index |= 2;
            if(angle == RotateAngle.Angle90)
                index |= (1 << 2);
            else if(angle == RotateAngle.Angle180)
                index |= (2 << 2);
            else if(angle == RotateAngle.Angle270)
                index |= (3 << 2);
            RotateFlipType []variants = new RotateFlipType[]{
                RotateFlipType.RotateNoneFlipNone,  //0
                RotateFlipType.RotateNoneFlipX,     //1
                RotateFlipType.RotateNoneFlipY,     //2
                RotateFlipType.RotateNoneFlipXY,    //3
                RotateFlipType.Rotate90FlipNone,    //4
                RotateFlipType.Rotate90FlipX,       //5
                RotateFlipType.Rotate90FlipY,       //6
                RotateFlipType.Rotate90FlipXY,      //7
                RotateFlipType.Rotate180FlipNone,   //8
                RotateFlipType.Rotate180FlipX,
                RotateFlipType.Rotate180FlipY,
                RotateFlipType.Rotate180FlipXY,
                RotateFlipType.Rotate270FlipNone,
                RotateFlipType.Rotate270FlipX,
                RotateFlipType.Rotate270FlipY,
                RotateFlipType.Rotate270FlipXY
            };
            this.mBmp.RotateFlip(variants[index]);
            this.Invalidate();
        }
        public void Inverse()
        {
            for (int x = 0; x < this.mBmp.Width; x++)
            {
                for (int y = 0; y < this.mBmp.Height; y++)
                {
                    if(this.mBmp.GetPixel(x, y).GetBrightness() > this.mBrightnessEdge)
                        this.mBmp.SetPixel(x, y, Color.Black);
                    else
                        this.mBmp.SetPixel(x, y, Color.White);
                }
            }
            this.Invalidate();
        }
    }
}
