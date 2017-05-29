using System;
using System.Collections.Generic;
using System.Xml;
using XmlProcessingDemos.Models;
using XmlProcessingDemos.Processors.Contracts;

namespace XmlProcessingDemos.Processors
{
    public class StaxXmlBooksService : IBooksService
    {
        private const string BookElementName = "book";
        private const string BookIdAttributeName = "id";
        private const string TitleElementName = "title";
        private const string AuthorElementName = "author";

        public StaxXmlBooksService(string xmlFileLocation)
        {
            this.XmlFileLocation = xmlFileLocation;
        }

        public string XmlFileLocation { get; set; }

        public IEnumerable<Book> GetAll()
        {
            var reader = XmlReader.Create(this.XmlFileLocation);

            var books = new List<Book>();

            using (reader)
            {
                var book = this.ReadNextBook(reader);
                while (book != null)
                {
                    books.Add(book);
                    book = this.ReadNextBook(reader);
                }
            }

            return books;
        }

        private Book ReadNextBook(XmlReader reader)
        {
            const int bookPropertiesToRead = 3;
            var propertiesRead = 0;
            var isInBook = false;

            var id = -1;
            var title = "";
            var author = "";

            while (reader.Read() && propertiesRead < bookPropertiesToRead)
            {
                if (isInBook == false && reader.IsStartElement() && reader.Name == BookElementName)
                {
                    isInBook = true;
                    id = int.Parse(reader.GetAttribute(BookIdAttributeName));
                    ++propertiesRead;
                }

                if (isInBook && reader.IsStartElement() && reader.Name == TitleElementName)
                {
                    ++propertiesRead;
                    reader.Read();
                    title = reader.Value;
                }

                if (isInBook && reader.IsStartElement() && reader.Name == AuthorElementName)
                {
                    ++propertiesRead;
                    reader.Read();
                    author = reader.Value;
                }
            }

            return propertiesRead < bookPropertiesToRead
                ? null
                : new Book(id, title, author);
        }

        public void Save(IEnumerable<Book> books)
        {
            var writer = XmlWriter.Create(this.XmlFileLocation);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("books");

                foreach (var book in books)
                {
                    this.SaveBookTo(book, writer);
                }

                writer.WriteEndDocument();
            }
        }

        private void SaveBookTo(Book book, XmlWriter writer)
        {
            writer.WriteStartElement(BookElementName);
            writer.WriteAttributeString(BookIdAttributeName, book.Id.ToString());

            writer.WriteElementString(TitleElementName, book.Title);
            writer.WriteElementString(AuthorElementName, book.Author);

            writer.WriteEndElement();
        }
    }
}
