using System;
using System.Drawing;

namespace GenericPainter.Other
{
    public class ImageCandidate
    {
        public RgbImage Image { get; set; }
        public float Difference { get; set; }

        public ImageCandidate(RgbImage model)
        {
            Image = new RgbImage(model.Width, model.Height);
        }

        public void Save(string destination)
        {
            Image.ToImage().Save(destination);
        }

        public void Score(RgbImage model)
        {
            if (Image.Size!=model.Size)
            {
                throw new ArgumentException();
            }

            float diff = 0;

            for (var y = 0; y < model.Height; y++)
            {
                for (var x = 0; x < model.Width; x++)
                {
                    diff += (float)Math.Abs(Image.GetPixelRgbValue(x, y) - model.GetPixelRgbValue(x, y)) / 255;
                }
            }

            Difference = diff;
        }

        public float PercentageDifference => 100 * Difference / (Image.Width * Image.Height * 3);
    }
}
