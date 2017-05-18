using System.Xml;

namespace ProcessingXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
             xmlDoc.Load("../../cars.xml");

        }

    
    }


}
