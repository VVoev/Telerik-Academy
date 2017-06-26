using System;

namespace _7.Fibonacci_Fast
{
    class Program
    {
        const int size = 1000;
        static decimal[] fib = new decimal[size];
        static decimal recursiveCallCounter = 0;




        static void Main(string[] args)
        {
            int number = 100;
            decimal fib = Fibonachi(number);
            System.Console.WriteLine($" Fibonachi number {number} : {fib}");
            System.Console.WriteLine($"Recursive Calls : {recursiveCallCounter}");
        }

        private static decimal Fibonachi(int number)
        {
            recursiveCallCounter++;
            if(fib[number] == 0)
            {
                
                if(number ==1 || number == 2)
                {
                    fib[number] = 1;
                }
                else
                {
                    fib[number] = Fibonachi(number - 1) + Fibonachi(number - 2);
                }
            }

            return fib[number];
        }
    }
}
