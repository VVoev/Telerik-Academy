using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ConsoleClient.Importers
{
    public class CategoryImporter : IImporter
    {
        public string Message
        {
            get
            {
                return "Start importing categories";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Import()
        {
            Console.WriteLine("Importing");
        }
    }
}
