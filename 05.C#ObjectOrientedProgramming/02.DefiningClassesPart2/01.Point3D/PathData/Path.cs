namespace _01.Point3D

{
    using System.Collections.Generic;

    public class Path
    {
        // Field
        private List<Point3D> path = new List<Point3D>();
        
        // Property
        public List<Point3D> Points { get {return this.path; } set { this.path = value; } }

        public Point3D this[int index]
        {
            get { return this.Points[index]; }
            set { this.Points[index] = value; }
        }
        public int Count { get {return path.Count; } }
        
        // Constructor.
        public Path()
        {
            this.Points = new List<Point3D>();
        }

        // Methods.
        public void AddPoint(Point3D point)
        {
            path.Add(point);
        }

        public void RemovePoint(Point3D point)
        {
            path.Remove(point);
        }
        public void RemovePointAt(int index)
        {
            path.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join("\r\n", this.Points);
        }
    }
}
