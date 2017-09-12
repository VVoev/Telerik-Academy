namespace Sorting
{
    static class InsertionSortClass
    {
        public static int[] InsertionSort(this int[] array)
        {
            var sortedArr = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int j;
                for (j = 0; j < i; ++j)
                {
                    if(sortedArr[j] > array[i])
                    {
                        break;
                    }
                }

                for(int k = i; k > j; --k)
                {
                    sortedArr[k] = sortedArr[k - 1];
                }

                sortedArr[j] = array[i];
                System.Console.WriteLine(
                    string.Join(" ", sortedArr));
            }

            return sortedArr;
        }
    }
}
