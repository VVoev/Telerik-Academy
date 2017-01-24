namespace _01.Catalan_Number
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {

            var arr = new int[] { 5, 10, 15,20,25 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(RecussionCatalan(arr[i]));
            }
          
        }

        private static int RecussionCatalan(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * RecussionCatalan (n - 1);
            }
        }
    }
}
