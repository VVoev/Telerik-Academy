using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TGr_Inna
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var name = input[0];
                var rating = input[1];
                people[name] = rating;
            }



            var counter = 0;
            var bestCounter = 0;
            string topGuy = string.Empty;
            foreach (var man in people)
            {
                foreach (var duma in man.Value)
                {
                    if(duma == '1')
                    {
                        counter++;
                    }
                }
                if (counter > bestCounter)
                {
                    bestCounter = counter;
                    topGuy = man.Key;
                }
                counter = 0;
            }
            Console.WriteLine(topGuy);

        }
    }
}
