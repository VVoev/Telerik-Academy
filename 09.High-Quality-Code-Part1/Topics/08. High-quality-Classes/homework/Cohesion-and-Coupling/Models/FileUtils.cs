using System;

namespace CohesionAndCoupling.Models
{
    public class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new Exception("File has no extensions");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new Exception("File dont have any dots in it");
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
