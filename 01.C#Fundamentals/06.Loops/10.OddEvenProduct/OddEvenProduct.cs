using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddEvenProduct
{
    static void Main()
    {
        // Input variables
        int numbersToEnter = int.Parse(Console.ReadLine());
        int[] arrayNums = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        long oddSumResult = 1;
        long evenSumResult = 1;

        // Main Logic
        for (int sequence = 0; sequence < arrayNums.Length; sequence++)
        {
            if (sequence % 2 == 0)
            {
                oddSumResult *= arrayNums[sequence];
            }
            else if (sequence % 2 != 0)
            {
                evenSumResult *= arrayNums[sequence];
            }
        }
        // Output
        if (numbersToEnter == 1)
        {
            Console.WriteLine("no {0} 0", oddSumResult);

        }else if (oddSumResult != evenSumResult)
        {
            Console.WriteLine("no {0} {1}", oddSumResult, evenSumResult);
        }
        else
        {
            Console.WriteLine("yes {0}", (oddSumResult + evenSumResult) / 2);
        }
    }
}
