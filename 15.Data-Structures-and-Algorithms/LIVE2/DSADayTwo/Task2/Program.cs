using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();



            var list = new OrderedBag<int>();
            var sb = new StringBuilder();

            while(input != "EXIT")
            {
                if (input.Contains("ADD"))
                {
                    var toAdd = input.Split(' ');
                    var number = int.Parse(toAdd[1]);
                    list.Add(number);
                }

                else
                {
                    double median;
                    if (list.Count % 2 == 0)
                        median = ((double)list[list.Count / 2] + (double)list[list.Count / 2 - 1]) / 2;
                    else
                        median = (double)list[list.Count / 2];
                    sb.AppendLine(median.ToString());
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(sb.ToString().Trim());

        }
    }
}
