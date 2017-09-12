using System;

namespace UpperEnvelope
{
    class Line
    {
        private const double Epsilon = 1e-12;

        public double A { get; set; }
        public double B { get; set; }

        public Line(double x, double y)
        {
            this.A = x;
            this.B = y;
        }

        private static double GenCoord(Random rnd)
        {
            return rnd.Next() + (double)(rnd.Next()) / (rnd.Next() + 1);
        }

        public static Line GenLine(Random rnd)
        {
            var x = GenCoord(rnd);
            var y = GenCoord(rnd);
            return new Line(x, y);
        }

        public static int AngleComparer(Line a, Line b)
        {
            var da = a.A - b.A;
            if (da < -Epsilon)
            {
                return -1;
            }
            if(da > Epsilon)
            {
                return 1;
            }
            return 0;
        }

        public double IntersectionWith(Line other)
        {
            return (other.B - this.B) / (this.A - other.A);
        }
    }
}
