using System;
using System.Drawing;

namespace GenericPainter.Mutators
{
    public class RandomSquareMutator
    {
        private readonly Random _random;

        public RandomSquareMutator()
        {
            _random = new Random();
        }

        public void Mutate(ImageCandidate candidate)
        {
            var x0 = _random.Next(candidate.Bitmap.Width - 2);
            var y0 = _random.Next(candidate.Bitmap.Height - 2);

            var maxSize = x0 > y0 ? candidate.Bitmap.Width - x0 : candidate.Bitmap.Width - y0;

            var size = _random.Next(maxSize);

            var randomColor = GetRandomColor(_random);

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
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
