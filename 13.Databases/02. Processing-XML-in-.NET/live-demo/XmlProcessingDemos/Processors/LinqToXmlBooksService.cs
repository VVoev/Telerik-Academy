using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XmlProcessingDemos.Models;
using XmlProcessingDemos.Processors.Contracts;

namespace XmlProcessingDemos.Processors
{
    public class LinqToXmlBooksService : IBooksService
    {
        private const string BookElementName = "book";
        private const string BookIdAttributeName = "id";
        private const string TitleElementName = "title";
        private const string AuthorElementName = "author";

        public LinqToXmlBooksService(string xmlFileLocation)
        {
            this.XmlFileLocation = xmlFileLocation;
        }

        public string XmlFileLocation { get; set; }

        public IEnumerable<Book> GetAll()
        {
            var doc = XDocument.Load(this.XmlFileLocation);

            return doc.Root
                .Elements(BookElementName)
                .Select(el =>
                {
                    var id = int.Parse(el.Attribute(BookIdAttributeName).Value);
                    var title = el.Element(TitleElementName).Value;
                    var author = el.Element(AuthorElementName).Value;

                    return new Book(id, title, author);
                });
        }

        public void Save(IEnumerable<Book> books)
        {
            var doc = new XDocument();

            doc.Add(
                new XElement("books",
                    books.Select(
                        book =>
                            new XElement(BookElementName,
                                new XAttribute(BookIdAttributeName, book.Id),
                                new XElement(TitleElementName, book.Title),
                                new XElement(AuthorElementName, book.Author)
                        )
                    )
                )
            );

            doc.Save(this.XmlFileLocation);
        }
    }
}
