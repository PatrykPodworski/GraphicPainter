namespace GenericPainter.Other
{
    public class RgbImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] Red { get; set; }
        public byte[] Green { get; set; }
        public byte[] Blue { get; set; }

        public RgbImage(int width, int height)
        {
            Width = width;
            Height = height;

            Red = new byte[width * height];
            Green = new byte[width * height];
            Blue = new byte[width * height];
        }
    }
}
