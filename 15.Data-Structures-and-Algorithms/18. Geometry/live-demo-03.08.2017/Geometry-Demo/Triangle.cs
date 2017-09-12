using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Demo
{
    class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public double AreaWithHeron()
        {
            var ab = A.DistanceTo(B);
            var ac = A.DistanceTo(C);
            var bc = B.DistanceTo(C);
            var p = (ab + ac + bc) / 2;
            return Math.Sqrt(p * (p - ab) * (p - ac) * (p - bc));
        }

        public double DirectedArea()
        {
            return (A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2;
        }
    }
}
