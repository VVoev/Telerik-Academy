using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.JediMedidation
{
    public class Startup
    {
        public static void Main()
        {
            var masters = new List<string>();
            var knights = new List<string>();
            var padawns = new List<string>();

            int n = int.Parse(Console.ReadLine());
            Console.ReadLine().Split(' ').ToList()
                .ForEach(j =>
                {
                    if (j[0] == 'M')
                    {
                        masters.Add(j);
                    }
                    else if (j[0] == 'K')
                    {
                        knights.Add(j);
                    }
                    else
                    {
                        padawns.Add(j);
                    }
                });

            masters.AddRange(knights);
            masters.AddRange(padawns);

            Console.WriteLine(string.Join(" ", masters));
        }
    }
}
