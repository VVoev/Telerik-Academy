
namespace _01.Shapes.Abstract
{
    using Interface;

    public abstract class Shape : IShape
    {
        protected double width;
        protected double height;

        public abstract double CalculateSurface();

    }
}
