using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ConsoleClient.Importers
{
    public class PostImporter : IImporter
    {
        public string Message
        {
            get
            {
                return "Start importing posts";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }

        public void Import()
        {
            Console.WriteLine("Importing");
        }
    }
}
