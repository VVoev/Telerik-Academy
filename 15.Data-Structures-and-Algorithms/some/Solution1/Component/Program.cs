using System;

namespace Component
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var parents = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                var strs = Console.ReadLine().Split(' ');
                int p = int.Parse(strs[0]);
                int k = int.Parse(strs[1]);
                parents[i] = p;

                for (int j = 0; j < k; j++)
                {
                    var keyValue = Console.ReadLine().Split('=');

                }
            }
        }
    }
}
