using System;
using System.IO;
using System.Linq;

namespace _03.FileSystemTree
{
    public class Startup
    {
        public static void Main()
        {
            var rootFolderName = @"..\..";
            var rootFolder = new Folder(rootFolderName);
            BuildFileSystemTree(rootFolder);

            // TraverseFolders(folder);
            var filesTotalSize = GetFolderFilesSizes(rootFolder);
            Console.WriteLine(filesTotalSize);
        }

        public static long GetFolderFilesSizes(Folder folder)
        {
            if (folder.Files.Length == 0 && folder.Folders.Length == 0)
            {
                return 0;
            }

            var filesSize = folder.Files.Sum(x => x.Size);

            foreach (var dir in folder.Folders)
            {
                filesSize += GetFolderFilesSizes(dir);
            }

            return filesSize;
        }

        public static void BuildFileSystemTree(Folder folder)
        {
            var subFolders = Directory.GetDirectories(folder.Name);
            var files = Directory.GetFiles(folder.Name);

            folder.Files = new File[files.Length];
            int index = 0;
            foreach (var file in files)
            {
                try
                {
                    folder.Files[index] = new File(file, new FileInfo(file).Length);
                    index++;
                }
                catch { }
            }

            folder.Folders = new Folder[subFolders.Length];
            index = 0;
            foreach (var dir in subFolders)
            {
                try
                {
                    folder.Folders[index] = new Folder(dir);
                    BuildFileSystemTree(folder.Folders[index]);
                    index++;
                }
                catch { }
            }
        }

        public static void TraverseFolders(Folder folder)
        {
            Console.WriteLine(folder.Name);

            if (folder.Folders == null)
            {
                return;
            }

            foreach (var file in folder.Files)
            {
                Console.WriteLine(" " + file.Name + " -> " + file.Size);
            }

            foreach (var f in folder.Folders)
            {
                TraverseFolders(f);
            }
        }
    }
}
