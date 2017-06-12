using CompanySampleDataImporter.Data;
using System;
using System.IO;

namespace CompanySampleDataImporter.Importer
{
    public interface IImporter
    {
        string Message { get;  }

        int Order { get;  }

        Action<CompanyEntities, TextWriter> Get { get; }
    }
}
