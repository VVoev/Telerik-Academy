using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortThreeNumbers
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int[] array = { a, b, c };
        Array.Sort(array);
        Array.Reverse(array);
        Console.Write(string.Join(" ", array));
        Console.WriteLine();
    }
}
