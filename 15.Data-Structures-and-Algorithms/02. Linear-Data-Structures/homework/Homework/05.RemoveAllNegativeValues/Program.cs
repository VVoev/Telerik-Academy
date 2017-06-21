using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RemoveAllNegativeValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, -2, -3, 3 };

            var result = RemoveNegativeValues(list);

            Console.WriteLine(string.Join(", ", result));
        }

        private static List<int> RemoveNegativeValues(List<int> list)
        {
            var result = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0)
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }
    }
}
