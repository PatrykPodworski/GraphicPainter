using GenericPainter.Abstract;
using GenericPainter.Other;

namespace GenericPainter.Mutators
{
    public class RandomRectangleMutator : RectangleMutator
    {
        protected override Coordinates GetSize(int maxWidth, int maxHeight)
            => new Coordinates(Random.Next(maxWidth), Random.Next(maxHeight));
    }
}
