using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var second = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var third = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Point p1 = new Point(first[0], first[1]);
            Point p2 = new Point(second[0], second[1]);
            Point p3 = new Point(third[0], third[1]);

            var krug = new krug();
            Circle c = krug.circleFromPoints(p1, p2, p3);
            Console.WriteLine(c);

        }
    }
    public class Point
    {
        public double x, y;

        public Point(double x, double y)
        {
            this.x = x; this.y = y;
        }

        public override string ToString()
        {
            return string.Format("(" + "{0}" + "," + "{1}" + ")",x,y);
        }
    }

    public class Circle
    {
        Point center;
        double radius;
        public Circle(Point center, double radius)
        {
            this.center = center;
        }
        public override string ToString()
        {
            var to2 = string.Format("{0:f4}", center.x);
            var do2 = string.Format("{0:f4}", center.y);
            return to2 +" "+ do2;
        }
    }
    public class krug 
    {
        public Circle circleFromPoints(Point p1, Point p2, Point p3)
        {
            double offset = Math.Pow(p2.x, 2) + Math.Pow(p2.y, 2);
            double bc = (Math.Pow(p1.x, 2) + Math.Pow(p1.y, 2) - offset) / 2.0;
            double cd = (offset - Math.Pow(p3.x, 2) - Math.Pow(p3.y, 2)) / 2.0;
            double det = (p1.x - p2.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p2.y);

            //if (Math.abs(det) < TOL) { throw new IllegalArgumentException("Yeah, lazy."); }

            double idet = 1 / det;

            double centerx = (bc * (p2.y - p3.y) - cd * (p1.y - p2.y)) * idet;
            double centery = (cd * (p1.x - p2.x) - bc * (p2.x - p3.x)) * idet;
            double radius =
              Math.Sqrt(Math.Pow(p2.x - centerx, 2) + Math.Pow(p2.y - centery, 2));

            return new Circle(new Point(centerx, centery), radius);
        }
    }
}
