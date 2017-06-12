using CompanySampleDataImporter.Data;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CompanySampleDataImporter.Importer.Models
{
    public class SampleDataImporter
    {
        private readonly TextWriter textWriter;

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Import()
        {
                 Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(IImporter).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x=> (IImporter)Activator.CreateInstance(x))
                .OrderBy(x=>x.Order)
                .ToList()
                .ForEach(x=>
                {
                    this.textWriter.Write(x.Message);
                    var db = new CompanyEntities();
                    x.Get(db, this.textWriter);
                    textWriter.WriteLine();
                });
        }
    }
}
