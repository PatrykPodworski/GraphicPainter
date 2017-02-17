using GenericPainter.Abstract;
using GenericPainter.Other;

namespace GenericPainter.Mutators
{
    public class FixedSquareMutator : RectangleMutator
    {
        public int RectangleSize { get; set; }

        public FixedSquareMutator() : base()
        {
            RectangleSize = 10;
        }

        protected override Coordinates GetSize(int maxWidth, int maxHeight)
        {
            var size = RectangleSize;

            if (maxHeight < size)
            {
                size = maxHeight;
            }

            if (maxWidth < size)
            {
                size = maxWidth;
            }

            return new Coordinates(size, size);
        }
    }
}
