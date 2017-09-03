using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GoldFever
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var ounces = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long budget = 0;
            long ouncesBought = 0;
            for (int i = 0; i < ounces.Length; i++)
            {
                long currentOuncePrice = ounces[i];
                bool isThereBigger = false;
                for (int j = i + 1; j < ounces.Length; j++)
                {
                    if (currentOuncePrice < ounces[j])
                    {
                        isThereBigger = true;
                        break;
                    }
                }

                if (isThereBigger)
                {
                    ouncesBought++;
                    budget -= currentOuncePrice;
                }
                else
                {
                    budget += ouncesBought * currentOuncePrice;
                    ouncesBought = 0;
                }
            }

            Console.WriteLine(budget);
        }
    }
}
