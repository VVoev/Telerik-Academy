using System;

namespace Recursion
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            NestedLoop(n, 0, string.Empty);
            
            Main();
        }

        public static void NestedLoop(int n, int loopsCount, string currentNumber)
        {
            if (loopsCount == n)
            {
                Console.WriteLine(currentNumber);
                return;
           }

            for (int i = 1; i <= n; i++)
            {
                NestedLoop(n, loopsCount + 1, currentNumber + i);
            }
        }
    }
}
