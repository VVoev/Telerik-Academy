namespace _01.Point3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public struct Point3D
    {
        // Set coordinates for 3D Point
        private double x;
        private double y;
        private double z;

        // Start of system
        private static readonly Point3D startOfCordinateSystem = new Point3D(0, 0, 0);

        // Set properties for coordinates x, y, z.
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        // Constructor
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Static constructor. Set starting coordinates, when set a new 3DPoint.
        public static Point3D Point3DStartingCoordinates
        {
            get {return startOfCordinateSystem; }
        }

        public override string ToString()
        {
            return string.Format(this.X + ", " + this.Y + ", " + this.Z);
        }
    }
}
