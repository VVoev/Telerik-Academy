using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TraverseDirectory
{
    public class Startup
    {
        public static void Main()
        {
            string rootDirectory = @"C:\";
            GetAllExeFilesInDirectory(rootDirectory);
        }

        public static void GetAllExeFilesInDirectory(string rootDirectory)
        {
            var dirExeFiles = Directory.GetFiles(rootDirectory).Where(x => x.EndsWith(".exe"));
        
            foreach (var file in dirExeFiles)
            {
                Console.WriteLine(file);
            }

            var nestedDirs = Directory.GetDirectories(rootDirectory);
            foreach (var dir in nestedDirs)
            {
                try
                {
                    GetAllExeFilesInDirectory(dir);
                }
                catch { }
            }
        }
    }
}
