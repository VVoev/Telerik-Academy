using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class FibonacciNumbers
{
    static void Main()
    {
        //Console.Write("Enter N numbers to add sequence: ");
        int fibonacciSequence = int.Parse(Console.ReadLine());
        BigInteger firstFib = 0;
        BigInteger fibSecond = 1;
        BigInteger fibThird = 0;
        BigInteger sum = firstFib + fibSecond + fibThird;

        if (fibonacciSequence == 1)
        {
            Console.WriteLine("{0}", firstFib);
        }
        else
        {
            Console.Write("{0}, {1}", firstFib, fibSecond);

            for (int i = 0; i < fibonacciSequence - 2; i++)
            {
                fibThird = firstFib + fibSecond;
                Console.Write(", {0}", fibThird);
                firstFib = fibSecond;
                fibSecond = fibThird;
                sum = firstFib + fibSecond + fibThird;
            }
            Console.WriteLine();
            //Console.WriteLine(" = {0}", sum);
            //Console.WriteLine("The {0} number is: {1} ", fibonacciSequence, fibThird);
        }
    }
}
