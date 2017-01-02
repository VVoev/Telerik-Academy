namespace _01.Shapes.Figures
{
    using Abstract;

    public class Square : Shape
    {
        public Square(double side)
        {
            this.width = side;
            this.height = side;
        }
        public override double CalculateSurface()
        {
            double area = width * height;
            return area;
        }
        public override string ToString()
        {
            return string.Format("Square surface is: {0:F2}",this.CalculateSurface());
        }
    }
}
