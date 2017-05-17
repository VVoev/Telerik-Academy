
using System;
using System.Xml;

namespace ProcessingXML
{
    class Program
    {
        static void Main(string[] args)
        {
            using (XmlReader reader = XmlReader.Create("../../cars.xml"))
            {
                while (reader.Read())
                {
                    Console.WriteLine("zdr");
                }
            }

        }

    
    }


}
