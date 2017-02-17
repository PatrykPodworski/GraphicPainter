using GenericPainter.Other;
using System;
using System.Drawing;

namespace GenericPainter.Abstract
{
    public abstract class RectangleMutator
    {
        protected readonly Random Random;
        public int ModelHeight { get; set; }
        public int ModelWidth { get; set; }

        protected RectangleMutator(Image model)
        {
            ModelHeight = model.Height;
            ModelWidth = model.Width;
            Random = new Random();
        }

        public void Mutate(ImageCandidate candidate)
        {
            var size = GetSize();

            var x0 = Random.Next(ModelWidth - size.X - 1);
            var y0 = Random.Next(ModelHeight - size.Y - 1);

            var randomColor = GetRandomColor(Random);

            for (var i = 0; i < size.Y; i++)
                for (var j = 0; j < size.X; j++)
                {
                    var color = GetAverageColor(randomColor, candidate.Bitmap.GetPixel(x0 + j, y0 + i));
                    candidate.Bitmap.SetPixel(x0 + j, y0 + i, color);
                }
        }

        protected static Color GetAverageColor(Color color1, Color color2)
        {
            return Color.FromArgb((color1.R + color2.R) / 2, (color1.G + color2.G) / 2, (color1.B + color2.B) / 2);
        }

        protected static Color GetRandomColor(Random random)
        {
            return Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
        }

        protected abstract Coordinates GetSize();
    }
}