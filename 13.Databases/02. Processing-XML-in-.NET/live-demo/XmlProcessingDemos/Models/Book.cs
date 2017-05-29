namespace XmlProcessingDemos.Models
{
    public class Book
    {
        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            var length = $"--- {this.Title} ({this.Id}) ---".Length;

            return $@" --- {this.Title} ({this.Id}) --- 
 Author: {this.Author}
 {new string('-', length)}
";
        }
    }
}
