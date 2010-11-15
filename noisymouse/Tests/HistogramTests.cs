using System.Drawing;
using NUnit.Framework;
using Source;

namespace Tests
{
    //[TestFixture]
    public class HistogramTests
    {
        [Test]
        public void GenerateHistogramValuesTest()
        {
            Bitmap bitmap = new Bitmap(3, 1);
            bitmap.SetPixel(0, 0, Color.FromArgb(255, 255, 255, 255));
            bitmap.SetPixel(1, 0, Color.FromArgb(255, 128, 128, 128));
            bitmap.SetPixel(2, 0, Color.FromArgb(255, 0, 0, 0));

            Histogram histogram = new Histogram(bitmap);

            Assert.AreEqual(1, histogram.Values[0]);
            Assert.AreEqual(1, histogram.Values[1]);
            Assert.AreEqual(1, histogram.Values[2]);
        }

        [Test]
        public void HistogramQualityValueTest()
        {
            Bitmap bitmap = new Bitmap(3, 1);
            bitmap.SetPixel(0, 0, Color.FromArgb(255, 255, 255, 255));
            bitmap.SetPixel(1, 0, Color.FromArgb(255, 255, 255, 255));
            bitmap.SetPixel(2, 0, Color.FromArgb(255, 0, 0, 0));

            Histogram histogram = new Histogram(bitmap);

            Assert.AreEqual(10, histogram.QualityValue);

            histogram.GenerateHistogram(bitmap);
            Assert.AreEqual(10, histogram.QualityValue);
        }

        [Test]
        public void HistogramQualityValueMiddleTest()
        {
            Bitmap bitmap = new Bitmap(5, 1);
            bitmap.SetPixel(0, 0, Color.FromArgb(255, 128, 128, 128));
            bitmap.SetPixel(1, 0, Color.FromArgb(255, 128, 128, 128));
            bitmap.SetPixel(2, 0, Color.FromArgb(255, 128, 128, 128));
            bitmap.SetPixel(3, 0, Color.FromArgb(255, 0, 0, 0));
            bitmap.SetPixel(4, 0, Color.FromArgb(255, 0, 0, 0));

            Histogram histogram = new Histogram(bitmap);

            Assert.AreEqual(5, histogram.QualityValue);
        }
    }
}
