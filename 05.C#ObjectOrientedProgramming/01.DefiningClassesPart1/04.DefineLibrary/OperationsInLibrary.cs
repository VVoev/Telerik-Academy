namespace _04.DefineLibrary
{
    using System;
    using System.Collections.Generic;

    public class OperationsInLibrary
    {
        public static void LibraryTest()
        {
            var libraryName = "Sofia National Library"; // Console.ReadLine();
            var bestsellers = new List<Book>();
            var nationalLibrary = new Library(libraryName, bestsellers);
            DateTime dateOfPublishing = new DateTime(2014, 12, 28);

            // Create some books.
            var firstBook = new Book("Da Vinci Code", "Dan Brown", "Ciela", dateOfPublishing, "91023921");
            var kingBook = new Book("Redemption Shawshank", "Stephen King", "Ciela", new DateTime(1982, 12, 28), "91023921");
            var kingAnotherBook = new Book("The Shining", "Stephen King", "Ciela", new DateTime(1977, 01, 28), "91023921");
            var secondBook = new Book("IDIOT", "Dostoevski", "Ciela", new DateTime(1869, 10, 08), "11023921");
            var thirdBook = new Book("The Client", "John Grisham", "Ciela", new DateTime(1993, 10, 12), "91053921");

            // Add books in current test library.
            nationalLibrary.AddBook(firstBook);
            nationalLibrary.AddBook(kingAnotherBook);
            nationalLibrary.AddBook(secondBook);
            nationalLibrary.AddBook(thirdBook);
            nationalLibrary.AddBook(kingBook);

            // Print all books in current library.
            Console.WriteLine("Books in " +  nationalLibrary.LibraryName);
            Console.WriteLine(string.Join(Environment.NewLine, nationalLibrary.BookStore));

            // Sort book by author name and clear them from current library.
            var sortedBooks = nationalLibrary.SearchBookByAuthor("Stephen King");
            foreach (Book book in sortedBooks)
            {
                nationalLibrary.DeleteBook(book);
            }

            // Print all stayed books in library.
            Console.WriteLine("Current books left in " + nationalLibrary.LibraryName);
            Console.WriteLine(string.Join(Environment.NewLine, nationalLibrary.BookStore));
        }
    }
}
