using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ConsoleClient.Importers
{
    public class ForumDbImporter
    {

        public void BeginImport()
        {
            var instances = Assembly.GetAssembly(typeof(IImporter))
                .GetTypes()
                .Where(x => typeof(IImporter).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(t => (IImporter)Activator.CreateInstance(t))
                .OrderBy(i => i.Order)
                .ToList();


            foreach (var instance in instances)
            {
                Console.WriteLine(instance.Message);
                instance.Import();

            }

        }
    }
}
