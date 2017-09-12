using AvlTreeRecursive;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTreesDemo
{
    public class Program
    {
        static void Main()
        {
            var tree = new AvlTree<int>();
            var numbers = Enumerable.Range(0, 3000000).ToArray();

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);

            Shuffle(numbers);
            foreach(var x in numbers)
            {
                tree.Add(x);
            }

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);

            Shuffle(numbers);
            for(int i = 0; i < numbers.Length / 2; ++i)
            {
                tree.Remove(i);
            }

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);

            Shuffle(numbers);
            for(int i = 0; i < numbers.Length / 3; ++i)
            {
                tree.Add(i);
            }

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);

            Shuffle(numbers);
            for(int i = 0; i < numbers.Length; ++i)
            {
                tree.Add(i);
            }

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);

            for(int i = 0; i < numbers.Length; ++i)
            {
                tree.Remove(i);
            }

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);

            tree.Add(-5);
            tree.Add(0);
            tree.Add(-3);

            Console.WriteLine(string.Join(" ", tree));
        }

        public static void Shuffle<T>(T[] array)
        {
            var rnd = new Random();
            for (int i = array.Length - 1; i > 0; --i)
            {
                var indexToSwap = rnd.Next() % (i + 1);
                if(indexToSwap < i)
                {
                    var tmp = array[indexToSwap];
                    array[indexToSwap] = array[i];
                    array[i] = tmp;
                }
            }
        }
    }
}
