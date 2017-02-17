using GenericPainter.Abstract;
using GenericPainter.Other;

namespace GenericPainter.Mutators
{
    public class RandomRectangleMutator : RectangleMutator
    {
        protected override Coordinates GetSize(int maxWidth, int maxHeight)
            => new Coordinates(Random.Next(maxWidth + 1), Random.Next(maxHeight + 1));
    }
}
