namespace _01.Shapes.Figures
{
    using Abstract;

    public class Triangle : Shape
    {
        public Triangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateSurface()
        {
            double surface = this.width * this.height / 2.0;
            return surface;
        }

        public override string ToString()
        {
            return string.Format("Triangle surface is: {0:F2}",this.CalculateSurface());
        }
    }
}
