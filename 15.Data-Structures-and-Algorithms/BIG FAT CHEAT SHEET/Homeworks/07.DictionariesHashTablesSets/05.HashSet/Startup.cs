using DictionariesHashTablesSets.HashSetImplementation;
using System;

namespace _05.HashSet
{
    public class Startup
    {
        public static void Main()
        {
            var set = new HashSet<int>();

            var random = new Random();
            for (int i = 0; i < 200; i++)
            {
                set.Add(random.Next() % 100);
            }

            set.Add(42);

            Console.WriteLine(set.Contains(42));
            Console.WriteLine(set.Contains(-1));
        }
    }
}
