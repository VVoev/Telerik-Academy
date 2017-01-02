namespace _04.DefineLibrary
{
    using System.Collections.Generic;

    public class Library
    {
        // Fields in class Library.
        private string libraryName;
        private IList<Book> listOfBooks;

        // Properites.
        public string LibraryName
        {
            get { return this.libraryName; }
            set { this.libraryName = value; }
        }
        public IList<Book> BookStore
        {
            get {return this.listOfBooks; }
            set { this.listOfBooks = value; }
        }

        public Library(string name, IList<Book> books)
        {
            this.LibraryName = name;
            this.BookStore = books;
        }

        // Methods.
        public void AddBook(Book currentBook)
        {
            listOfBooks.Add(currentBook);
        }
        public void DeleteBook(Book currentBook)
        {
            listOfBooks.Remove(currentBook);
        }
        public void PrintBookInformation(Book currentBook)
        {
            currentBook.ToString();
        }
        public IList<Book> SearchBookByAuthor(string author)
        {
            var sortedBooksByAuthor = new List<Book>();
            foreach (Book book in listOfBooks)
            {
                if (book.Author == author)
                {
                    sortedBooksByAuthor.Add(book);
                }
            }
            return sortedBooksByAuthor;
        }
    }
}
