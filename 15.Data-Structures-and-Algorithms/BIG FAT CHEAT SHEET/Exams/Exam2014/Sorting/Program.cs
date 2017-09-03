using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int maxReverseCount = int.Parse(Console.ReadLine());

            var q = new Queue<Node>();
            q.Enqueue(new Node() { Numbers = numbers, Steps = 0 });

            if (IsSorted(numbers))
            {
                Console.WriteLine(0);
                return;
            }

            var used = new HashSet<int>();
            used.Add(GetHashCode(numbers));
            while (q.Count > 0)
            {
                var current = q.Dequeue();

                for (int i = 0; i < numbers.Length; i++)
                {
                    int startIndex = i;
                    int endIndex = i + maxReverseCount;

                    if (endIndex > n)
                    {
                        break;
                    }

                    int[] newList = new int[n];
                    Array.Copy(current.Numbers, newList, n);

                    Reverse(startIndex, endIndex, newList);

                    var hashCode = GetHashCode(newList);
                    if (used.Contains(hashCode))
                    {
                        continue;
                    }

                    if (IsSorted(newList))
                    {
                        Console.WriteLine(current.Steps + 1);
                        return;
                    }

                    // Console.WriteLine(strList);
                    used.Add(hashCode);
                    q.Enqueue(new Node { Steps = current.Steps + 1, Numbers = newList });

                }
            }

            Console.WriteLine(-1);
        }

        public static void Reverse(int startIndex, int endIndex, int[] numbers)
        {
            int end = (startIndex + endIndex) / 2;
            int index = 0;
            for (int i = startIndex; i < end; i++)
            {
                var temp = numbers[i];
                numbers[i] = numbers[endIndex - index - 1];
                numbers[endIndex - 1 - index] = temp;
                index++;
            }
        }
        
        public static int GetHashCode(int[] arr)
        {
            int hash = 0;
            for (int i =0; i < arr.Length; i++)
            {
                hash = hash * 10 + arr[i];
            }

            return hash;
        }

        public static bool IsSorted(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Node
    {
        public Node()
        {
            this.Steps = 0;
        }

        public int[] Numbers { get; set; }

        public int Steps { get; set; }
    }
}
