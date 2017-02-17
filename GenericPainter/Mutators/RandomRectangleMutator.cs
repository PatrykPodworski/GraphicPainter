using GenericPainter.Abstract;
using GenericPainter.Other;
using System.Drawing;

namespace GenericPainter.Mutators
{
    public class RandomRectangleMutator : RectangleMutator
    {
        public RandomRectangleMutator(Image model) : base(model)
        {
        }

        protected override Coordinates GetSize() => new Coordinates(Random.Next(ModelWidth - 1), Random.Next(ModelHeight - 1));

    }
}
