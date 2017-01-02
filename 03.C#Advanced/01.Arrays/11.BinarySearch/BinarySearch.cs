using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinarySearch
{
    static void Main()
    {
        // Define size of array.
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        //Read numbers in array.
        ReadNumbersInArray(array);

        // Sort array if numbers are not sorted.
        Array.Sort(array);
        int searchNumber = int.Parse(Console.ReadLine());

        // Binary search.
        int low = 0;
        int high = array.Length - 1;
        int mid = (high + low) / 2;
        bool wantedNumberIsFound = false;
        while (low <= high)
        {
            if (searchNumber == array[mid])
            {
                wantedNumberIsFound = true;
                Console.WriteLine(mid);
                return;
            }
            else if (searchNumber < array[mid])
            {
                high = mid - 1;
                mid = (high + low) / 2;
            }
            else if (searchNumber > array[mid])
            {
                low = mid + 1;
                mid = (high + low) / 2;
            }
        }
        if (wantedNumberIsFound == false)
        {
            Console.WriteLine(-1);
        }
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
