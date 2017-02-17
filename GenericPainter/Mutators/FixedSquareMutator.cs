using GenericPainter.Abstract;
using GenericPainter.Other;
using System.Drawing;

namespace GenericPainter.Mutators
{
    public class FixedSquareMutator : RectangleMutator
    {
        public int RectangleSize { get; set; }

        public FixedSquareMutator(Image model) : base(model)
        {
            RectangleSize = 10;
        }

        protected override Coordinates GetSize() => new Coordinates(RectangleSize, RectangleSize);
    }
}
