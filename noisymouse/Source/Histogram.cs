using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Source
{
    public interface IHistogram
    {
        int[] Values { get; set; }
        int QualityValue { get; set; }
        Histogram GenerateHistogram(Bitmap aBitmap);
        int GetMaxIndex();
    }

    public class Histogram : IHistogram
    {
        private int[] _values;
        private int _qualityValue;

        public int[] Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public int QualityValue
        {
            get { return _qualityValue; }
            set { _qualityValue = value; }
        }

        public Histogram()
        {
        }

        public Histogram(Bitmap aBitmap)
        {
            GenerateHistogram(aBitmap);
        }

        public Histogram GenerateHistogram(Bitmap aBitmap)
        {
            _values = new int[10];
            BitmapData bitmapData = aBitmap.LockBits(new Rectangle(0, 0, aBitmap.Width, aBitmap.Height), ImageLockMode.ReadOnly,
                                          aBitmap.PixelFormat);
            try
            {
                int pixelSize = (aBitmap.PixelFormat == PixelFormat.Format24bppRgb) ? 3 : 4;

                unsafe
                {
                    int width = aBitmap.Width;
                    int height = aBitmap.Height;

                    byte* p = (byte*)bitmapData.Scan0;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++, p += pixelSize)
                        {
                            _values[(int)(10 * (p[0] + p[1] + p[2]) / ((float)3 * 256))]++;
                        }
                    }

                }
            }
            finally
            {
                aBitmap.UnlockBits(bitmapData);
            }

            _qualityValue = GetMaxIndex();

            return this;
        }




        public int GetMaxIndex()
        {
            int[] copy = new int[10];
            _values.CopyTo(copy, 0);

            Array.Sort(copy);
            
            return Array.IndexOf(_values, copy[copy.Length - 1]);
        }

    }
}
