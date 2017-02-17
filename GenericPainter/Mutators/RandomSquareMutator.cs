using GenericPainter.Abstract;
using GenericPainter.Other;

namespace GenericPainter.Mutators
{
    public class RandomSquareMutator : RectangleMutator
    {
        public int Size { get; set; }

        protected override Coordinates GetSize(int maxWidth, int maxHeight)
        {
            var size = Random.Next(maxWidth < maxHeight ? maxWidth + 1 : maxHeight + 1);
            return new Coordinates(size, size);
        }
    }
}
