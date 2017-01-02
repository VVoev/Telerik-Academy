using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaxKSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        ReadNumbersInArray(array);
        Array.Sort(array);
        int max = n - k;
        int sum = 0;
        for (int i = array.Length - 1; i >= max; i--)
        {
            sum += array[i];
        }

        Console.WriteLine(sum);
    }
    private static void ReadNumbersInArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            array[i] = currentNumber;
        }
    }
}
