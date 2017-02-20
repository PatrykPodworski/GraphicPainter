using System;
using System.Drawing;

namespace GenericPainter.Other
{
    public class RgbImage
    {
        public RgbImage(int width, int height)
        {
            Initialize(width, height);
        }

        public RgbImage(string source)
        {
            using (var bitmap = new Bitmap(source))
            {
                Initialize(bitmap.Width, bitmap.Height);

                for (var i = 0; i < Size; i++)
                {
                    var x = i % Width;
                    var y = i / Width;

                    Red[i] = bitmap.GetPixel(x, y).R;
                    Green[i] = bitmap.GetPixel(x, y).G;
                    Blue[i] = bitmap.GetPixel(x, y).B;
                }
            }
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] Red { get; set; }
        public byte[] Green { get; set; }
        public byte[] Blue { get; set; }

        public int Size => Width * Height;

        private void Initialize(int width, int height)
        {
            Width = width;
            Height = height;

            Red = new byte[Size];
            Green = new byte[Size];
            Blue = new byte[Size];
        }

        public Image ToImage()
        {
            var image = new Bitmap(Width, Height);

            for (var i = 0; i < Size; i++)
            {
                var colour = Color.FromArgb(Red[i], Green[i], Blue[i]);
                var x = i % Width;
                var y = i / Width;

                image.SetPixel(x, y, colour);
            }

            return image;
        }

        public Color GetPixelColour(int x, int y)
        {
            var position = y * Width + x;

            var color = Color.FromArgb(Red[position], Green[position], Blue[position]);

            return color;
        }

        public void Copy(RgbImage image)
        {
            if (Size != image.Size)
            {
                throw new ArgumentException();
            }

            for (var i = 0; i < Size; i++)
            {
                Red[i] = image.Red[i];
                Blue[i] = image.Blue[i];
                Green[i] = image.Green[i];
            }
        }

        public void SetPixelColour(int x, int y, Color color)
        {
            var position = y * Width + x;

            Red[position] = color.R;
            Green[position] = color.G;
            Blue[position] = color.B;
        }

        public int GetPixelRgbValue(int x, int y)
        {
            var position = y * Width + x;

            if (position > Size)
            {
                throw new ArgumentException();
            }

            var value = Red[position] + Green[position] + Blue[position];

            return value;
        }
    }
}