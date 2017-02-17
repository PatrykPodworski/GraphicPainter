using System;
using System.Drawing;

namespace GenericPainter
{
    public class ImageCandidate
    {
        public Bitmap Bitmap { get; set; }
        public Bitmap Model { get; set; }
        public float Difference { get; set; }

        public ImageCandidate(Image model)
        {
            Model = model.Clone() as Bitmap;
            Bitmap = GenerateBaseCandidate(model.Width, model.Height);
        }

        private static Bitmap GenerateBaseCandidate(int x, int y)
        {
            var bmp = new Bitmap(x, y);

            using (var graphics = Graphics.FromImage(bmp))
            {
                var imageArea = new Rectangle(0, 0, x, y);
                graphics.FillRectangle(Brushes.White, imageArea);
            }

            return bmp;
        }

        public void Save(string destination)
        {
            Bitmap.Save(destination);
        }

        public void Score()
        {
            float diff = 0;

            for (var y = 0; y < Model.Height; y++)
            {
                for (var x = 0; x < Model.Width; x++)
                {
                    diff += (float)Math.Abs(Bitmap.GetPixel(x, y).R - Model.GetPixel(x, y).R) / 255;
                    diff += (float)Math.Abs(Bitmap.GetPixel(x, y).G - Model.GetPixel(x, y).G) / 255;
                    diff += (float)Math.Abs(Bitmap.GetPixel(x, y).B - Model.GetPixel(x, y).B) / 255;
                }
            }

            Difference = diff;
        }

        public float PercentageDifference => 100 * Difference / (Bitmap.Width * Bitmap.Height * 3);
    }
}
