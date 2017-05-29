using System;
using System.Collections.Generic;
using XmlProcessingDemos.Models;

namespace XmlProcessingDemos.Processors.Contracts
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAll();

        void Save(IEnumerable<Book> books);
    }
}
