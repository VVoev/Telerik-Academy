using System;

namespace _3.RefactorLoop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i = 0;
            int divisior = 10;
            int expectedValue = 40;
            bool isValueFound = false;

            for (i = 0; i < 100;)
            {
                if (i % divisior == 0)
                {
                    Console.WriteLine(i);
                    if (i == expectedValue)
                    {
                        isValueFound = true;
                    }

                    i++;
                }
                else
                {
                    Console.WriteLine(i);
                    i++;
                }
            }
            //// More code here
            if (isValueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
