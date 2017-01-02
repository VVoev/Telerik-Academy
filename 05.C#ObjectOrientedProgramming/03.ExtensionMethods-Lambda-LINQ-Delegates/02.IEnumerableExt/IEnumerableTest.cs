namespace _02.IEnumerableExt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class IEnumerableTest
    {
        static void Main()
        {
            var numbers = new List<int>();
            var randomGnt = new Random();
            for (int i = 0; i < 10; i++)
            {
                var randomNumber = randomGnt.Next(0, 25);
                numbers.Add(randomNumber);
            }
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine(numbers.MIN());
            Console.WriteLine(numbers.MAX());
            Console.WriteLine(numbers.Product());
            Console.WriteLine(numbers.SUM());
            Console.WriteLine((double)numbers.AVERAGE());
        }
    }
}
