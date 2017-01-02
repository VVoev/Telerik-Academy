using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        // Add numbers read from console to array.
        AddNumbers(n, array);
        int start = 0;
        int best = int.MinValue;
        int current = 0;
        for (int i = start; i < n; i++)
        {
            current += array[i];
            if (current > best)
            {
                best = current;
            }
            if (i == n - 1)
            {
                start++;
                current = 0;
                i = start;
            }
           
        }
        Console.WriteLine(best);
    }
    private static void AddNumbers(int n, int[] array)
    {
        for (int i = 0; i < n; i++)
        {
            int currentNum = int.Parse(Console.ReadLine());
            array[i] = currentNum;
        }
    }

}
