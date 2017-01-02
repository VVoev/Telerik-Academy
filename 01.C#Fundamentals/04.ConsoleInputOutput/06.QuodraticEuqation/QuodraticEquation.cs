using System;

class QuodraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double discriminant = b * b - 4 * a * c;
        double xOne = ((-b + Math.Sqrt(discriminant)) / (2 * a));
        double xTwo = ((-b - Math.Sqrt(discriminant)) / (2 * a));

        if (discriminant >= 0)
        {
            Console.WriteLine("{0:F2}", Math.Min(xOne, xTwo));
            if (xOne != xTwo)
            {
                Console.WriteLine("{0:F2}", Math.Max(xOne, xTwo));
            }
        }
        else
        {
            Console.WriteLine("no real roots");
        }
    }
}
