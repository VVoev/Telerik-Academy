using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveOddOccurences
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var result = RemoveOddOccurences(numbers);

            Console.WriteLine(string.Join(", ", result));
        }

        private static IList<int> RemoveOddOccurences(IList<int> numbers)
        {
            var result = numbers.Where(n => numbers.Count(x => x == n) % 2 == 0).ToList();
            return result;
        }
    }
}
