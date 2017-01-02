namespace _01.Point3D
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PathStorage
    {
        public static void SavePath(string outputFile, Path path)
        {
            try
            {
                File.WriteAllText(outputFile, path.ToString());
            }
            catch (AccessViolationException avex)
            {

                throw avex;
            }
            catch (IOException ioex)
            {
                throw ioex;
            }
        }
        public static Path LoadPath(string inputFile)
        {
            Path path = new Path();
            try
            {
                string text = File.ReadAllText(inputFile);
                string[] points = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var point in points)
                {
                    string[] coordinates = point.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    double x = double.Parse(coordinates[0]);
                    double y = double.Parse(coordinates[1]);
                    double z = double.Parse(coordinates[2]);
                    path.AddPoint(new Point3D(x, y, z));
                }
                return path;

            }
            catch (FileNotFoundException fnfe)
            {

                Console.WriteLine("####The file is not found");
                throw fnfe;
            }
            catch (IOException ioex)
            {
                throw ioex;
            }
        }
    }
}
