using GenericPainter.Abstract;
using GenericPainter.Other;
using System.Drawing;

namespace GenericPainter.Mutators
{
    public class RandomSquareMutator : RectangleMutator
    {
        public int Size { get; set; }
        public RandomSquareMutator(Image model) : base(model)
        {
        }

        protected override Coordinates GetSize()
        {
            var size = Random.Next(ModelWidth < ModelHeight ? ModelWidth - 1 : ModelHeight - 1);
            return new Coordinates(size, size);
        }
    }
}
