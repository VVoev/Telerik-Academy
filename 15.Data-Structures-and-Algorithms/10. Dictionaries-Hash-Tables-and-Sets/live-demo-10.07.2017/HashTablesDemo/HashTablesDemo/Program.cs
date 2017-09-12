using DictionaryImplementation;
using System;
using System.Diagnostics;

namespace HashTablesDemo
{
    class Chuska
    {
        public Chuska()
        {
        }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    public class Program
    {
        static void Main()
        {
            var set = new HashSetImplementation.HashSetWithLists<Chuska>();

            var rnd = new Random();
            var sw = new Stopwatch();
            sw.Start();

            for(int i = 0; i < 10000; ++i)
            {
                set.Add(new Chuska());
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine(set.GetMaxCount() + " " + set.GetAverageCount());
        }
    }
}
