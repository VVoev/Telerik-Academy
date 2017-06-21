using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MajorantOfAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var occurences = new SortedDictionary<int, int>();

            var majorantCondition = list.Count/2 + 1;

            foreach (var item in list)
            {
                if (occurences.ContainsKey(item))
                {
                    occurences[item]++;
                }
                else
                {
                    occurences.Add(item, 1);
                }
            }

            int? majorant = null;
            foreach (var occurence in occurences)
            {
                if (occurence.Value == majorantCondition)
                {
                    majorant = occurence.Key;
                    
                }
            }

            if (majorant.HasValue)
            {
                Console.WriteLine("Majorant: {0}", majorant);
            }
            else
            {
                Console.WriteLine("No majorant!");
            }
        }
    }
}
