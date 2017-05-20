using CompanySampleDataImporter.Data;
using CompanySampleDataImporter.Importer.Models;
using System;

namespace CompanySampleDataImporter.Importer
{
    public class Startup
    {
        public static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
