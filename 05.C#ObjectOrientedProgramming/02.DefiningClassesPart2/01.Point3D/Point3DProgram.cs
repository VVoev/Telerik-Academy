namespace _01.Point3D
{
    using System;

    class Point3DProgram
    {
        static void Main()
        {
            // Add some points.
            Point3D firstPoint = new Point3D(-2,2,2);
            Point3D secondPoint = new Point3D(4,4,4);
            Point3D thirdPoint = new Point3D(6,6,6);
            Point3D fourthPoint = new Point3D(8,8,8);
            Point3D fifthPoint = new Point3D(9,9,9);

            Path path = new Path();

            // Add points in path.
            path.AddPoint(firstPoint);
            path.AddPoint(secondPoint);
            path.AddPoint(thirdPoint);
            path.AddPoint(fourthPoint);
            path.AddPoint(fifthPoint);
            Console.WriteLine("3D Points:");
            Console.WriteLine(string.Join(Environment.NewLine, path.Points));

            string inputFile = @"../../IOFiles/inputFile.txt";
            Path pathFromFile = PathStorage.LoadPath(inputFile);
            Console.WriteLine("3D Points read from file.");
            Console.WriteLine(string.Join(Environment.NewLine, pathFromFile.ToString()));
            // Remove last 3D point.
            path.RemovePoint(firstPoint);

            // Remove point at index.
            path.RemovePointAt(3);

            // Change values for all left 3D points.
            for (int i = 0; i < path.Count; i++)
            {
                path[i] = new Point3D(i + 1, i * 2, i + 3);
            }

            
            string outputFile = @"../../IOFiles/outputFile.txt";
            PathStorage.SavePath(outputFile, path);
            Console.WriteLine("3D Points written to file:");
            Console.WriteLine(path.ToString());

            
        }
    }
}
