using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;

namespace lcd_bitmap_converter_mono
{
    public class BitmapHelper
    {
        public static void SetPixel(BitmapData bmd, int x, int y, bool value)
        {
            unsafe
            {
                //byte* ptr = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x / 8);
                //byte b = *ptr;

                //byte* ptr2 = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x / 8);
                //int counter = bmd.Height * bmd.Stride;
                //while (counter-- > 0)
                //    System.Diagnostics.Debug.WriteLine(String.Format("{0:X2} ", *ptr2));

                //byte mask = Convert.ToByte(0x80 >> (x % 8));
                //if (value)
                //    *ptr = Convert.ToByte(b | mask);
                //else
                //    *ptr = Convert.ToByte(b & ~mask);
                byte* p = (byte*)bmd.Scan0.ToPointer();
                int index = y * bmd.Stride + (x >> 3);
                byte mask = (byte)(0x80 >> (x & 0x7));
                if (value)
                    p[index] |= mask;
                else
                    p[index] &= (byte)(mask ^ 0xff);
            }
        }
        public static bool GetPixel(BitmapData bmd, int x, int y)
        {
            bool result = false;
            unsafe
            {
                byte* ptr = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x / 8);
                byte b = *ptr;

                //byte* ptr2 = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x / 8);
                //int counter = bmd.Height * bmd.Stride;
                //while (counter-- > 0)
                //    System.Diagnostics.Debug.WriteLine(String.Format("{0:X2} ", *ptr2));

                byte mask = Convert.ToByte(0x80 >> (x % 8));
                if ((b & mask) != 0)
                    result = true;
                else
                    result = false;
            }
            return result;
        }
        public static Bitmap RotateFlip(Bitmap bmp, bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            Bitmap result = (Bitmap)bmp.Clone();
            // flip
            if (horizontalFlip || verticalFlip)
            {
                result = bmp.Clone(Rectangle.FromLTRB(0, 0, bmp.Width, bmp.Height), PixelFormat.Format1bppIndexed);
                unsafe
                {
                    BitmapData bmdSrc = bmp.LockBits(Rectangle.FromLTRB(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                    BitmapData bmdDst = result.LockBits(Rectangle.FromLTRB(0, 0, result.Width, result.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            bool bit = GetPixel(bmdSrc, x, y);
                            //only vertical
                            if (!horizontalFlip && verticalFlip)
                                SetPixel(bmdDst, x, bmp.Height - y - 1, bit);
                            //only horizontal
                            if (horizontalFlip && !verticalFlip)
                                SetPixel(bmdDst, bmp.Width - x - 1, y, bit);
                            //vertical & horizontal
                            if (horizontalFlip && verticalFlip)
                                SetPixel(bmdDst, bmp.Width - x - 1, bmp.Height - y - 1, bit);
                        }
                    }
                    bmp.UnlockBits(bmdSrc);
                    result.UnlockBits(bmdDst);
                }
            }
            if (angle == RotateAngle.Angle180)
            {
                Bitmap result2 = result.Clone(Rectangle.FromLTRB(0, 0, result.Width, result.Height), PixelFormat.Format1bppIndexed);
                unsafe
                {
                    BitmapData bmdSrc = result.LockBits(Rectangle.FromLTRB(0, 0, result.Width, result.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                    BitmapData bmdDst = result2.LockBits(Rectangle.FromLTRB(0, 0, result2.Width, result2.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                    for (int x = 0; x < result.Width; x++)
                    {
                        for (int y = 0; y < result.Height; y++)
                        {
                            bool bit = GetPixel(bmdSrc, x, y);
                            SetPixel(bmdDst, result.Width - x - 1, result.Height - y - 1, bit);
                        }
                    }
                    result.UnlockBits(bmdSrc);
                    result2.UnlockBits(bmdDst);
                    result = result2;
                }
            }
            if (angle == RotateAngle.Angle90 || angle == RotateAngle.Angle270)
            {
                //Bitmap result2 = result.Clone(Rectangle.FromLTRB(0, 0, result.Height, result.Width), PixelFormat.Format1bppIndexed);
                Bitmap result2 = new Bitmap(result.Height, result.Width, PixelFormat.Format1bppIndexed);
                unsafe
                {
                    BitmapData bmdSrc = result.LockBits(Rectangle.FromLTRB(0, 0, result.Width, result.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                    BitmapData bmdDst = result2.LockBits(Rectangle.FromLTRB(0, 0, result2.Width, result2.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                    for (int x = 0; x < result.Width; x++)
                    {
                        for (int y = 0; y < result.Height; y++)
                        {
                            bool bit = GetPixel(bmdSrc, x, y);
                            if (angle == RotateAngle.Angle90)
                                SetPixel(bmdDst, result2.Width - y - 1, x, bit);
                            if (angle == RotateAngle.Angle270)
                                SetPixel(bmdDst, y, result2.Height - x - 1, bit);
                        }
                    }
                    result.UnlockBits(bmdSrc);
                    result2.UnlockBits(bmdDst);
                    result = result2;
                }
            }

            return result;
        }
        public static Bitmap RotateFlip2(Bitmap bmp, bool horizontalFlip, bool verticalFlip, RotateAngle angle)
        {
            int index = 0;
            if (horizontalFlip)
                index |= 1;
            if (verticalFlip)
                index |= 2;
            if (angle == RotateAngle.Angle90)
                index |= (1 << 2);
            else if (angle == RotateAngle.Angle180)
                index |= (2 << 2);
            else if (angle == RotateAngle.Angle270)
                index |= (3 << 2);
            RotateFlipType[] variants = new RotateFlipType[]{
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
            Bitmap result = (Bitmap)bmp.Clone();
            bmp.Save("1.bmp");
            result.RotateFlip(variants[index]);
            result.Save("2.bmp");
            return result;
        }
        public static Bitmap GetMonochrome(Bitmap bmp, float edge)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format1bppIndexed);
            BitmapData bmd = bmp2.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    float br = bmp.GetPixel(i, j).GetBrightness();
                    //Console.WriteLine(br.ToString());
                    if (br > edge)
                        //bmp2.SetPixel(i, j, Color.White);
                        BitmapHelper.SetPixel(bmd, i, j, true);
                    else
                        //bmp2.SetPixel(i, j, Color.Black);
                        BitmapHelper.SetPixel(bmd, i, j, false);
                }
            }
            bmp2.UnlockBits(bmd);
            return bmp2;
        }
        public static Bitmap Resize(Bitmap bmp, int left, int top, int right, int bottom)
        {
            Bitmap result = bmp;// (Bitmap)bmp.Clone();
            //check on allowed
            if (0 - left >= bmp.Width ||
                0 - top >= bmp.Height ||
                bmp.Width + right <= 0 ||
                bmp.Height + bottom <= 0 ||
                bmp.Width + left + right <= 0 ||
                bmp.Height + top + bottom <= 0)
            {
                //System.Windows.Forms.MessageBox.Show("Invalid arguments, resize not possible.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                throw new Exception("Invalid arguments, resize not possible.");
            }
            else
            {
                //calc source coordinates
                result = new Bitmap(bmp.Width + left + right, bmp.Height + top + bottom, PixelFormat.Format1bppIndexed);
                int srcLeft = (left > 0 ? 0 : -left);
                int srcWidth = (right <= 0 ? bmp.Width + right - srcLeft : bmp.Width - srcLeft);
                int srcTop = (top > 0 ? 0 : -top);
                int srcHeight = (bottom <= 0 ? bmp.Height + bottom - srcTop : bmp.Height - srcTop);
                //calc destination coordinates
                int destLeft = (left <= 0 ? 0 : left);
                int destTop = (top <= 0 ? 0 : top);

                //string msg = String.Format("Copy from ({0}, {1} * {2}, {3}) to {4}, {5}",
                //    srcLeft, srcTop, srcWidth, srcHeight, destLeft, destTop);
                //System.Windows.Forms.MessageBox.Show(msg);
                //copy
                BitmapData bmdSrc = bmp.LockBits(new Rectangle(srcLeft, srcTop, srcWidth, srcHeight), ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
                BitmapData bmdDest = result.LockBits(new Rectangle(destLeft, destTop, srcWidth, srcHeight), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
                for (int x = 0; x < srcWidth; x++)
                {
                    for (int y = 0; y < srcHeight; y++)
                    {
                        //if (GetPixel(bmdSrc, srcLeft + x, srcTop + y))
                        //    SetPixel(bmdDest, destLeft + x, destTop + y, true);
                        //else
                        //    SetPixel(bmdDest, destLeft + x, destTop + y, false);
                        SetPixel(
                            bmdDest,
                            x,
                            y,
                            GetPixel(bmdSrc, x, y));
                    }
                }
                result.UnlockBits(bmdDest);
                bmp.UnlockBits(bmdSrc);
            }
            return result;
        }
        public static Rectangle CalcShrink(Bitmap bmp)
        {
            bool def = SavedContainer<Options>.Instance.SetBitsByDefault;
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //calc source coordinates
            BitmapData bmdSrc = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
            //check left
            bool end = false;
            int x, y;
            for (x = 0, end = false; x < bmp.Width && !end; x++)
            {
                for (y = 0; y < bmp.Height && !end; y++)
                {
                    if (GetPixel(bmdSrc, x, y) != def)
                    {
                        rect.X = x;
                        end = true;
                    }
                }
            }
            //check right
            for (x = bmp.Width - 1, end = false; x >= 0 && !end; x--)
            {
                for (y = 0; y < bmp.Height && !end; y++)
                {
                    if (GetPixel(bmdSrc, x, y) != def)
                    {
                        rect.Width = x - rect.X + 1;
                        end = true;
                    }
                }
            }
            //check top
            for (y = 0, end = false; y < bmp.Height && !end; y++)
            {
                for (x = 0; x < bmp.Width && !end; x++)
                {
                    if (GetPixel(bmdSrc, x, y) != def)
                    {
                        rect.Y = y;
                        end = true;
                    }
                }
            }
            //check bottom
            for (y = bmp.Height - 1, end = false; y >= 0 && !end; y--)
            {
                for (x = bmp.Width - 1; x >= 0 && !end; x--)
                {
                    if (GetPixel(bmdSrc, x, y) != def)
                    {
                        rect.Height = y - rect.Y + 1;
                        end = true;
                    }
                }
            }
            bmp.UnlockBits(bmdSrc);
            return rect;
        }
        public static Bitmap GetCharacterBitmap(char c, Font font, FontWidthMode widthMode, int width, float edge)
        {
            bool setByDef = SavedContainer<Options>.Instance.SetBitsByDefault;

            Size sz = TextRenderer.MeasureText(new string(c, 1), font);
            Bitmap bmp;
            if (widthMode == FontWidthMode.Monospaced)
                bmp = new Bitmap(width, sz.Height);
            else
                bmp = new Bitmap(sz.Width, sz.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle((setByDef ? Brushes.White : Brushes.Black), 0, 0, bmp.Width, bmp.Height);
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            gr.DrawString(new string(c, 1), font, (setByDef ? Brushes.Black : Brushes.White), 0, 0);
            bmp = GetMonochrome(bmp, edge);
            if (widthMode == FontWidthMode.Proportional)
            {
                Rectangle shrink = BitmapHelper.CalcShrink(bmp);
                int left = -shrink.X;
                int top = -shrink.Y;
                int right = -(bmp.Width - shrink.Width - shrink.X);
                int bottom = -(bmp.Height - shrink.Height - shrink.Y);

                left++;
                right++;
                bmp = BitmapHelper.Resize(bmp, left, 0, right, 0);
            }
            return bmp;
        }
        public static Bitmap Inverse(Bitmap srcBmp)
        {
            Bitmap bmp = srcBmp.Clone(Rectangle.FromLTRB(0, 0, srcBmp.Width, srcBmp.Height), PixelFormat.Format1bppIndexed);
            unsafe
            {
                BitmapData bmd = bmp.LockBits(Rectangle.FromLTRB(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        //if (bmp.GetPixel(x, y).GetBrightness() > this.mBrightnessEdge)
                        //    bmp.SetPixel(x, y, Color.Black);
                        //else
                        //    bmp.SetPixel(x, y, Color.White);
                        byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride) + (x / 8);
                        byte b = *row;
                        byte mask = Convert.ToByte(0x80 >> (x % 8));
                        *row = Convert.ToByte(b ^ mask);
                    }
                }
                bmp.UnlockBits(bmd);
            }
            return bmp;
        }
        public static void SaveToXml(Bitmap sourceBitmap, XmlNode node, XmlSavingOptions options)
        {
            Bitmap bmp = BitmapHelper.RotateFlip(sourceBitmap, options.FlipHorizontal, options.FlipVertical, options.Angle);
            if (options.Inverse)
                bmp = BitmapHelper.Inverse(bmp);
            if ((bmp.Width % 8) != 0)
            {
                if (options.AlignRight)
                    bmp = BitmapHelper.Resize(bmp, 8 - bmp.Width % 8, 0, 0, 0);
            }
            //separate node for bitmap's data
            //XmlNode nodeBitmap = node.AppendChild(node.OwnerDocument.CreateElement("bitmap"));
            XmlNode nodeBitmap = node;
            //bitmap info
            (nodeBitmap as XmlElement).SetAttribute("width", Convert.ToString(sourceBitmap.Width, CultureInfo.InvariantCulture));
            (nodeBitmap as XmlElement).SetAttribute("height", Convert.ToString(sourceBitmap.Height, CultureInfo.InvariantCulture));
            //preview node, all bits at one line
            XmlNode nodePreview = nodeBitmap.AppendChild(node.OwnerDocument.CreateElement("preview"));

            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);

            for (int y = 0; y < bmp.Height; y++)
            {
                //bitmap's line
                XmlNode nodeLine = nodeBitmap.AppendChild(node.OwnerDocument.CreateElement("line"));
                (nodeLine as XmlElement).SetAttribute("index", Convert.ToString(y, CultureInfo.InvariantCulture));

                StringBuilder byteData = new StringBuilder();
                StringBuilder lineData = new StringBuilder();
                for (int x = 0; x < bmp.Width; x++)
                {
                    //if (bmp.GetPixel(x, y).GetBrightness() > this.mBrightnessEdge)
                    if (BitmapHelper.GetPixel(bmd, x, y))
                        byteData.Append("1");
                    else
                        byteData.Append("0");
                    //if byte filled or end of line
                    if ((x % 8) == 7 || x == (bmp.Width - 1))
                    {
                        XmlNode nodeColumn = nodeLine.AppendChild(node.OwnerDocument.CreateElement("column"));
                        (nodeColumn as XmlElement).SetAttribute("index", Convert.ToString((int)(x / 8), CultureInfo.InvariantCulture));

                        //ensure what 8 bits (1 byte)
                        while (byteData.Length < 8)
                            byteData.Append("0");

                        nodeColumn.InnerText = byteData.ToString();
                        lineData.Append(byteData);
                        if (options.MirrorEachByte)
                        {
                            string str = byteData.ToString();
                            byteData.Length = 0;
                            foreach (char c in str)
                            {
                                byteData.Insert(0, c);
                            }
                            nodeColumn.InnerText = byteData.ToString();
                        }
                        byteData.Length = 0;
                    }
                }
                lineData = lineData.Replace('0', '_').Replace('1', '#');
                XmlNode nodePreviewLine = nodePreview.AppendChild(node.OwnerDocument.CreateElement("line"));
                nodePreviewLine.InnerText = lineData.ToString();
            }
            bmp.UnlockBits(bmd);
        }
        public static Bitmap LoadFromXml(XmlNode node)
        {
            int width = Convert.ToInt32(node.Attributes["width"].Value, CultureInfo.InvariantCulture);
            int height = Convert.ToInt32(node.Attributes["height"].Value, CultureInfo.InvariantCulture);
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format1bppIndexed);

            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            for (int y = 0; y < height; y++)
            {
                string ypath = String.Format(CultureInfo.InvariantCulture, "line[@index={0}]", y);
                XmlNode nodeLine = node.SelectSingleNode(ypath);
                if (nodeLine == null)
                    throw new Exception("Line node not found: " + ypath);
                for (int x = 0; x < width; x++)
                {
                    int col = Convert.ToInt32(x / 8);
                    int subx = x % 8;
                    string xpath = String.Format(CultureInfo.InvariantCulture, "column[@index={0}]", col);
                    XmlNode nodeColumn = nodeLine.SelectSingleNode(xpath);
                    if (nodeColumn == null)
                        throw new Exception("Column node not found: " + xpath);
                    string byteData = nodeColumn.InnerText;
                    if (byteData[subx] == '0')
                        //bmp.SetPixel(x, y, Color.White);
                        BitmapHelper.SetPixel(bmd, x, y, false);
                    else
                        //bmp.SetPixel(x, y, Color.Black);
                        BitmapHelper.SetPixel(bmd, x, y, true);
                }
            }
            bmp.UnlockBits(bmd);
            return bmp;
        }
    }
}
