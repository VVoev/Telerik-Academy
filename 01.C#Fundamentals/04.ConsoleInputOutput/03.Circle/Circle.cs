using System;

class Circle
{
    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());
        double areaCircle = Math.PI * Math.Pow(radius, 2);
        double perimeterCircle = 2 * Math.PI * radius;
        Console.WriteLine("{0:F2} {1:F2}", perimeterCircle, areaCircle);
    }
}
