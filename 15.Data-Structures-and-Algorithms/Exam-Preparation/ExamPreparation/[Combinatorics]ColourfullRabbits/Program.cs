using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Combinatorics_ColourfullRabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long sum = 0;
            var rabiitanswers = new HashSet<int>();
            var rabbits = new int[n];

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var answer = int.Parse(Console.ReadLine());
                rabbits[i] = answer;
                rabiitanswers.Add(answer);
            }

            Array.Sort(rabbits);

            foreach (var answer in rabiitanswers)
            {
                dictionary.Add(answer, 0);
            }

            foreach (var rabbit in rabbits)
            {
                dictionary[rabbit]++;
            }

            TotalRabbits(dictionary);

        }

        private static void TotalRabbits(Dictionary<int, int> dictionary)
        {
            long sum = 0;

            foreach (var dict in dictionary)
            {
                var total = (dict.Value / dict.Key);
                if(total == 0)
                {
                    total = 1;
                }
                var total2 = (dict.Key + 1);
                var grandTotal = total * total2;
                sum += grandTotal;
            }
            Console.WriteLine(sum);
          
        }
    }
}
