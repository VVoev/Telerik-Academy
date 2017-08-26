using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rings
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var rings = new List<Ring>();

            var possibleConfigs = new Dictionary<int,int>();

            for (int i = 0; i < n; i++)
            {
                int commingFrom = int.Parse(Console.ReadLine());
                int index = i;
                var ring = new Ring(commingFrom, index);
                rings.Add(ring);
            }

            foreach (var ring in rings)
            {
                if(!possibleConfigs.ContainsKey(ring.ComingFrom))
                {
                    possibleConfigs[ring.ComingFrom] = 1;
                }
                else
                {
                    possibleConfigs[ring.ComingFrom]++;
                }
            }

            CalculateFactorial(possibleConfigs);
        }

        private static void CalculateFactorial(Dictionary<int, int> possibleConfigs)
        {
            long sum = 1;
            foreach (var config in possibleConfigs)
            {
                if (config.Value > 1)
                {
                    for (int i = 1; i <= config.Value; i++)
                    {
                        sum = sum * i;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }

    class Ring
    {
        public int ComingFrom { get; set; }
        public int Index { get; set; }

        public Ring(int comingFrom, int index)
        {
            this.ComingFrom = comingFrom;
            this.Index = index;
        }
    }
}
