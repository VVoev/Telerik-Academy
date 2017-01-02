namespace _04.DefineLibrary
{
    using System;
    using System.Text;

    public class Book
    {
        // Fields in class Book.
        private string nameOfBook;
        private string author;
        private string press;
        private DateTime yearOfPublishing;
        private string isbnNumber;

        // Properties in class Book.
        public string BookName
        {
            get { return this.nameOfBook; }
            set { this.nameOfBook = value; }
        }
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }
        public string Press
        {
            get { return this.press; }
            set { this.press = value; }
        }
        public DateTime YearOfPublishing
        {
            get { return this.yearOfPublishing; }
            set { this.yearOfPublishing = value; }
        }
        public string ISBNNumber
        {
            get { return this.isbnNumber; }
            set { this.isbnNumber = value; }
        }

        // Constructors in class Book.
        public Book(string name,string author, string press, DateTime year, string number)
        {
            this.BookName = name;
            this.Author = author;
            this.Press = press;
            this.YearOfPublishing = year;
            this.ISBNNumber = number;
        }
        // Methods in class Book.
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.BookName != null)
            {
                sb.AppendLine("- Name of book: " + this.BookName);
            }
            if (this.Author != null)
            {
                sb.AppendLine("- Author of book: " + this.Author);
            }
            if (this.Press != null)
            {
                sb.AppendLine("- Press: " + this.Press);
            }
            if (this.YearOfPublishing != null)
            {
                sb.AppendLine("- Year of book publishing: " + this.YearOfPublishing.Year);
            }
            if (this.ISBNNumber != null)
            {
                sb.AppendLine("- Book ID number: " + this.ISBNNumber);
            }
            return sb.ToString();
        }
    }
}
