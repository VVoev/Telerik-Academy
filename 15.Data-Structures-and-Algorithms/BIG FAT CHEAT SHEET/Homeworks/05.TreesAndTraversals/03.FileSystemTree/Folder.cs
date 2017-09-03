namespace _03.FileSystemTree
{
    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public File[] Files { get; set; }

        public Folder[] Folders { get; set; }
    }
}
