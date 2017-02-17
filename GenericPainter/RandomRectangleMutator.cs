using System;
using System.Drawing;

namespace GenericPainter
{
    public class RandomRectangleMutator
    {
        private readonly Random _random;

        public RandomRectangleMutator()
        {
            _random = new Random();
        }

        public void Mutate(ImageCandidate candidate)
        {
            var x0 = _random.Next(candidate.Bitmap.Width - 2);
            var y0 = _random.Next(candidate.Bitmap.Height - 2);

            var sizeX = _random.Next(candidate.Bitmap.Width - x0 - 1);
            var sizeY = _random.Next(candidate.Bitmap.Height - y0 - 1);

            var randomColor = GetRandomColor(_random);

            for (var i = 0; i < sizeX; i++)
            {
                for (var j = 0; j < sizeY; j++)
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
