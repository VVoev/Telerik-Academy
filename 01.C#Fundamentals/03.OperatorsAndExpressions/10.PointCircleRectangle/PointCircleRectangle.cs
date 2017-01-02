using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PointCircleRectangle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double r = 1.5;
        double pointCircle = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));
        bool pointRectangle = (x < -1) || (x > 5) || (y < -1) || (y > 1);
        if (pointCircle <= r)
        {
            Console.Write("inside circle");
        }
        else
        {
            Console.Write("outside circle");
        }
        if (pointRectangle)
        {
            Console.Write(" outside rectangle");
        }
        else
        {
            Console.Write(" inside rectangle");
        }
        Console.WriteLine();
    }
}
