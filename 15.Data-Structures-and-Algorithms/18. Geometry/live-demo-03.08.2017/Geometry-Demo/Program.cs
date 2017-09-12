using System;

namespace Geometry_Demo
{
    class Program
    {
        static void Main()
        {
            var triangle = new Triangle
            {
                A = new Point { X = 2, Y = 0 },
                B = new Point { X = 1, Y = 1 },
                C = new Point { X = 0, Y = 2 },
            };

            Console.WriteLine(triangle.AreaWithHeron());
            Console.WriteLine(triangle.DirectedArea());

            var p1 = new Point { X = 3, Y = 7 };
            var p2 = new Point { X = 9, Y = 6 };
            var dy = p2.Y - p1.Y;
            var dx = p2.X - p1.X;
            var a = dy / dx;
            //var a = Math.Atan(tg);
            var b = p1.Y - a * p1.X;

            Console.WriteLine($"{a} {b}");
            Console.WriteLine($"{p2.X * a + b} {p2.Y}");
        }
    }
}
