using DictionariesHashTablesSets.DictionaryImplementation;
using System;

namespace _04.HashTable
{
    public class Startup
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("Ivan", 22);
            dictionary.Add("Penka", 33);
            dictionary.Add("Ivaela", 33);

            foreach (var kv in dictionary)
            {
                Console.WriteLine($"{kv.Key} : {kv.Value}");
            }
        }
    }
}
