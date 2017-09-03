using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sticks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var secondLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var thirdLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var x1 = firstLine[0];
            var y1 = firstLine[1];
            var x2 = firstLine[2];
            var y2 = firstLine[3];

            var u1 = secondLine[0];
            var v1 = secondLine[1];
            var u2 = secondLine[2];
            var v2 = secondLine[3];

            var intersection = FindIntersectionCoordinates(firstLine[0], firstLine[1], firstLine[2], firstLine[3], secondLine[0], secondLine[1], secondLine[2], secondLine[3]);
            var intersection2 = FindIntersectionCoordinates(firstLine[0], firstLine[1], firstLine[2], firstLine[3], thirdLine[0], thirdLine[1], thirdLine[2], thirdLine[3]);
            var intersection3 = FindIntersectionCoordinates(secondLine[0], secondLine[1], secondLine[2], secondLine[3], thirdLine[0], thirdLine[1], thirdLine[2], thirdLine[3]);


            var result = DirectedArea(intersection, intersection2, intersection3);
            Console.WriteLine(string.Format("{0:f3}", Math.Abs(result / 2)));
        }

        public static double DirectedArea(Tuple<double, double> A, Tuple<double, double> B, Tuple<double, double> C)
        {
            return (A.Item1 * (B.Item2 - C.Item2) + B.Item1 * (C.Item2 - A.Item2) + C.Item1 * (A.Item2 - B.Item2));
        }

        public static Tuple<double, double> FindIntersectionCoordinates(double x1, double y1, double x2, double y2, double u1, double v1, double u2, double v2)
        {
            var x = -1 * ((x1 - x2) * (u1 * v2 - u2 * v1) - (u2 - u1) * (x2 * y1 - x1 * y2)) / ((v1 - v2) * (x1 - x2) - (u2 - u1) * (y2 - y1));

            var y = -1 * (u1 * v2 * y1 - u1 * v2 * y2 - u2 * v1 * y1 + u2 * v1 * y2 - v1 * x1 * y2 + v1 * x2 * y1 + v2 * x1 * y2 - v2 * x2 * y1) / (-1 * u1 * y1 + u1 * y2 + u2 * y1 - u2 * y2 + v1 * x1 - v1 * x2 - v2 * x1 + v2 * x2);

            return new Tuple<double, double>(x, y);
        }
    }
}
