using GraphsAlgorithms;
using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main()
        {
            var line = Console.ReadLine();

            var frequencies = new Dictionary<char, int>();

            foreach (var ch in line)
            {
                if (frequencies.ContainsKey(ch))
                {
                    frequencies[ch]++;
                }
                else
                {
                    frequencies[ch] = 1;
                }
            }

            var queue = new PriorityQueue<Tuple<int, HuffmanTree>>((x, y) => x.Item1 < y.Item1);

            foreach (var x in frequencies)
            {
                queue.Enqueue(new Tuple<int, HuffmanTree>(
                    x.Value,
                    new HuffmanTree(x.Key)));
            }

            while (queue.Count > 1)
            {
                var x = queue.Dequeue();
                var y = queue.Dequeue();

                queue.Enqueue(new Tuple<int, HuffmanTree>(
                    x.Item1 + y.Item1,
                    new HuffmanTree(x.Item2, y.Item2)));
            }

            var root = queue.Dequeue().Item2;
            root.Dfs();
        }
    }
}
