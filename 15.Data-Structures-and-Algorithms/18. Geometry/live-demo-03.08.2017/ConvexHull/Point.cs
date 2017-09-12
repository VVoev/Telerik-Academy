using System;

namespace ConvexHull
{
    class Point
    {
        private const double Epsilon = 1e-12;

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceToSquared(Point other)
        {
            var dx = this.X - other.X;
            var dy = this.Y - other.Y;
            return dx * dx + dy * dy;
        }

        public double DistanceTo(Point other)
        {
            return Math.Sqrt(this.DistanceToSquared(other));
        }

        private static double GenCoord(Random rnd)
        {
            return rnd.Next() + (double)(rnd.Next()) / (rnd.Next() + 1);
        }

        public static Point GenPoint(Random rnd)
        {
            var x = GenCoord(rnd);
            var y = GenCoord(rnd);
            return new Point(x, y);
        }

        public static int XComparer(Point a, Point b)
        {
            var dx = a.X - b.X;
            if (dx < -Epsilon)
            {
                return -1;
            }
            if(dx > Epsilon)
            {
                return 1;
            }
            return 0;
        }
    }
}
