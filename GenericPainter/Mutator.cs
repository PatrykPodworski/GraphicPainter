using System;
using System.Drawing;
using System.Threading;

namespace GenericPainter
{
    public class Mutator
    {
        public int SizeOfRectangle { get; private set; }
        private readonly Random _random;

        public Mutator(int sizeOfRectangle)
        {
            SizeOfRectangle = sizeOfRectangle;
            _random = new Random();
        }

        public void Mutate(ImageCandidate candidate)
        {
            var x0 = _random.Next(candidate.Bitmap.Width - 9);
            var y0 = _random.Next(candidate.Bitmap.Height - 9);
            var randomColor = GetRandomColor(_random);

            for (var i = 0; i < SizeOfRectangle; i++)
            {
                for (var j = 0; j < SizeOfRectangle; j++)
                {
                    var color = GetAverageColor(randomColor, candidate.Bitmap.GetPixel(x0 + i, y0 + j));
                    candidate.Bitmap.SetPixel(x0 + i, y0 + j, color);
                }
            }
        }

        private static int CalculateDifference(ImageCandidate candidate, Bitmap model, int x, int y)
        {
            var candidateColor = candidate.Bitmap.GetPixel(x, y);
            var modelColor = model.GetPixel(x, y);

            return Math.Abs(candidateColor.ToArgb() - modelColor.ToArgb());
        }

        private static Color GetAverageColor(Color color1, Color color2)
        {
            return Color.FromArgb((color1.R + color2.R) / 2, (color1.G + color2.G) / 2, (color1.B + color2.B) / 2);
        }

        private static Color GetRandomColor(Random random)
        {
            return Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
        }
    }
}
