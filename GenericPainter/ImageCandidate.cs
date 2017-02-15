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
            var bmp = new Bitmap(x,y);

            using (var graphics = Graphics.FromImage(bmp))
            {
                var imageArea = new Rectangle(0,0, x,y);
                graphics.FillRectangle(Brushes.White, imageArea);
            }

            return bmp;
        }

        public void Save(string destination)
        {
            Bitmap.Save(destination);
        }

        public float PercentageDifference => 100 * Difference / (Bitmap.Width * Bitmap.Height * 3);
    }
}
