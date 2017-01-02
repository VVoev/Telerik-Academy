using System;

class Triangle
{
    public double sideA { get; set; }
    public double sideB { get; set; }
    public double sideC { get; set; }
    public double semiPerimeter
    {
        get
        {
            return (sideA + sideB + sideC) / 2;
        }
    }
    public double area
    {
        get
        {
            return Math.Sqrt(semiPerimeter * 
                            (semiPerimeter - sideA) * 
                            (semiPerimeter - sideB) * 
                            (semiPerimeter - sideC));
        }
    }
}
class TriangleSurfaceByThreeSides
{
    static void Main()
    {
        Triangle currentTrianlgle = ReadTriangleSides();

        Console.WriteLine("{0:F2}", currentTrianlgle.area);
    }

    static Triangle ReadTriangleSides()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        Triangle currentTrianlgle = new Triangle() { sideA = a, sideB = b, sideC = c };
        return currentTrianlgle;
    }
}
