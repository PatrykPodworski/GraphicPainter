using System;
using System.Drawing;

namespace GenericPainter.Mutators
{
    public class FixedSquareMutator
    {
        private readonly Random _random;
        public int RectangleSize { get; set; }

        public FixedSquareMutator()
        {
            _random = new Random();
            RectangleSize = 10;
        }

        public void Mutate(ImageCandidate candidate)
        {
            var x0 = _random.Next(candidate.Bitmap.Width - 11);
            var y0 = _random.Next(candidate.Bitmap.Height - 11);

            var randomColor = GetRandomColor(_random);

            for (var i = 0; i < RectangleSize; i++)
            {
                for (var j = 0; j < RectangleSize; j++)
                {
                    var color = GetAverageColor(randomColor, candidate.Bitmap.GetPixel(x0 + i, y0 + j));
                    candidate.Bitmap.SetPixel(x0 + i, y0 + j, color);
                }
            }
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
