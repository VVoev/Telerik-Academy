using System;

class PointInACircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double r = 2;
        double point = Math.Sqrt((x * x) + (y * y));
        if (point <= r)
        {
            Console.WriteLine("yes {0:F2}", point);
        }
        else
        {
            Console.WriteLine("no {0:F2}", point);
        }
    }
}
