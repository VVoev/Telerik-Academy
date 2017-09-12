using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Demo
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double DistanceTo(Point other)
        {
            var dx = this.X - other.X;
            var dy = this.Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
