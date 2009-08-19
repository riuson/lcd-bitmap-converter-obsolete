using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

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
            result.RotateFlip(variants[index]);
            return result;
        }
    }
}
