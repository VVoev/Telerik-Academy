using System;
using System.Linq;
using XmlProcessingDemos.Models;
using XmlProcessingDemos.Processors;
using XmlProcessingDemos.Processors.Contracts;

namespace XmlProcessingDemos
{
    class XmlProcessingDemo
    {
        static void Main()
        {
            IBooksService booksService;

            booksService = new LinqToXmlBooksService("../../data/data.xml");

            var books = booksService.GetAll()
                .ToList();

            var maxId = books.Max(b => b.Id) + 1;

            int n = 1 << 25;

            for (int i = 0; i < n; i++)
            {
                books.Add(new Book(maxId, "The Fellowship of the Ring", "J.R.R. Tolkien"));
                ++maxId;
            }

            DateTime start;
            DateTime end;

            start = DateTime.Now;

            booksService.Save(books);

            end = DateTime.Now;

            Console.WriteLine("LINQ-to-XML finished in {0}", end - start);

            booksService = new StaxXmlBooksService("../../data/data.xml");

            start = DateTime.Now;

            booksService.Save(books);

            end = DateTime.Now;

            Console.WriteLine("Stax finished in {0}", end - start);
        }
    }
}
