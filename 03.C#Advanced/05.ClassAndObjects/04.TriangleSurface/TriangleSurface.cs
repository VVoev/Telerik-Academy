using System;

class Triangle
{
    public double triangleSide { get; set; }
    public double height { get; set; }
    public double surface
    {
        get
        {
            return (height * triangleSide) / 2;
        }
    }
}
class TriangleSurface
{

    static void Main()
    {
        Triangle side = ReadTriangleSideAndHeight();

        Console.WriteLine("{0:F2}", side.surface);
    }

    static Triangle ReadTriangleSideAndHeight()
    {
        double currentSide = double.Parse(Console.ReadLine());
        double currentHeight = double.Parse(Console.ReadLine());

        Triangle side = new Triangle() { triangleSide = currentSide, height = currentHeight };
        return side;
    }
}
