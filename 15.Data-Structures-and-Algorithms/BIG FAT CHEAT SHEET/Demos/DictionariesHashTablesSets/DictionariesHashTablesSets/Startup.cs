using System;

namespace DictionariesHashTablesSets
{
    using DictionariesHashTablesSets.DictionaryImplementation;
    using DictionariesHashTablesSets.HashSetImplementation;
    using System.Diagnostics;

    public class Startup
    {
        public static void Main()
        {
            var dict = new Dictionary<string, int>();
            dict["Ivan"] = 3;
            dict["Ivan"] = 38;
            Console.WriteLine(dict["Ivan"]);
        }

        public static void HashSetTest()
        {
            var set = new HashSet<int>();
            var systemSet = new System.Collections.Generic.HashSet<int>();

            MeasureTime(() =>
            {
                for (int i = 0; i < 30000; i++)
                {
                    systemSet.Add(i);
                }
            });

            MeasureTime(() =>
            {
                for (int i = 0; i < 30000; i++)
                {
                    set.Add(i);
                }
            });
        }

        public static void MeasureTime(Action action)
        {
            var sw = new Stopwatch();

            sw.Start();
            action();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
        }
    }
}
