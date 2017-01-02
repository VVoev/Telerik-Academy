using System;

class Triangle
{
    public double sideA { get; set; }
    public double sideB { get; set; }
    public double angle { get; set; }
    public double angleInRadians
    {
        get
        {
            return angle * Math.PI / 180;
        }
    }
    public double area
    {
        get
        {
            return sideA * sideB * Math.Sin(angleInRadians) / 2;
        }
    }
}
class TriangleSurfaceByTwoSidesAndAngle
{
    static void Main()
    {
        Triangle currentTriangle = ReadTriangleSidesAndAngle();

        Console.WriteLine("{0:F2}", currentTriangle.area);
    }

    static Triangle ReadTriangleSidesAndAngle()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double angleBetweenTwoSides = double.Parse(Console.ReadLine());
        Triangle currentTriangle = new Triangle() { sideA = a, sideB = b, angle = angleBetweenTwoSides };
        return currentTriangle;
    }
}
