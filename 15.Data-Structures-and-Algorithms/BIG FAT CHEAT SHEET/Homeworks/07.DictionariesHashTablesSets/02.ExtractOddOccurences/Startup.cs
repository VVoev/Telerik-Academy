using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExtractOddOccurences
{
    public class Startup
    {
        public static void Main()
        {
            var array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var dictionary = new Dictionary<string, int>();
            array.ToList().ForEach(el =>
            {
                if (dictionary.ContainsKey(el))
                {
                    dictionary[el]++;
                }
                else
                {
                    dictionary[el] = 1;
                }
            });

            foreach (var kv in dictionary)
            {
                if ((kv.Value & 1) == 1)
                {
                    Console.WriteLine($"{kv.Key}: {kv.Value}");
                }
            }
        }
    }
}
