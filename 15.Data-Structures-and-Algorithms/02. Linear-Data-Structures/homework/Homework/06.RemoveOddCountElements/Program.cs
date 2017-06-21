using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RemoveOddCountElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var evenOcurrances = RemoveOddOcurrances(list);

            Console.WriteLine(string.Join(", ", evenOcurrances));
        }

        private static List<int> RemoveOddOcurrances(List<int> list)
        {
            var even = new HashSet<int>();
            var odd = new HashSet<int>();

            foreach (var item in list)
            {
                if (odd.Add(item))
                {
                    even.Remove(item);
                }
                else
                {
                    odd.Remove(item);
                    even.Add(item);
                }
            }

            var result = list.Where(item => even.Contains(item)).ToList();
            return result;
        }
    }
}
