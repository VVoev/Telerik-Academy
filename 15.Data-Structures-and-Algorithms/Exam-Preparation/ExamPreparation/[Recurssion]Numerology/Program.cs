using System;
using System.Linq;
using System.Collections.Generic;

namespace Blq
{
    class Program
    {
        static int F(int a, int b)
        {
            return (a + b) * (a ^ b) % 10;
        }

        static int[] result = new int[10];

        static void Recursion(List<int> nums)
        {
            if (nums.Count == 1)
            {
                ++result[nums[0]];
                return;
            }

            for (int i = 1; i < nums.Count; ++i)
            {
                var a = nums[i - 1];
                var b = nums[i];
                nums.RemoveAt(i);
                nums[i - 1] = F(a, b);
                Recursion(nums);
                nums[i - 1] = a;
                nums.Insert(i, b);
            }
        }

        static void Main()
        {
            var nums = Console.ReadLine()
                .Select(x => (int)x - '0')
                .ToList();

            Recursion(nums);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}