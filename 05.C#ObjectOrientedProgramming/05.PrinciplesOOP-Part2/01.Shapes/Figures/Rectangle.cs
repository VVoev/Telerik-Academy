namespace _01.Shapes.Figures
{
    using Abstract;

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateSurface()
        {
            return this.height * this.width;
        }
        public override string ToString()
        {
            return string.Format("Rectangle surface is: {0:F2}",this.CalculateSurface());
        }
    }
}
