using System;

namespace _1.Factoriel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateFactorier(5));
        }

        public static int CalculateFactorier(int number)
        {
            if(number == 0)
            {
                return 1;
            }

            return number * CalculateFactorier(number - 1);
            
        }
    }
}
