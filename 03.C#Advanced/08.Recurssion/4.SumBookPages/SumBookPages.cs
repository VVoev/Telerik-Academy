using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.SumBookPages
{
    class SumBookPages
    {
        static void Main(string[] args)
        {
            /*
             * 1-9 every page is one number
             * 10-99  every page is with two numbers
             * 100-999 every page is with three numbers
             * etc
             */


            Console.WriteLine($"Please enter how many pages your book have");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"The book your request has {SumTillNoMorePagesLeftInTheBook(n)} pages");


            var differentBooksExamples = new int[]{ 10, 100, 1000 };
            foreach (var book in differentBooksExamples)
            {
                Console.WriteLine(SumTillNoMorePagesLeftInTheBook(book));
            }
        }

        private static int SumTillNoMorePagesLeftInTheBook(int n)
        {
            if (n == 1)
            {
                return n.ToString().Length;
            }
            else
            {
                return n.ToString().Length + SumTillNoMorePagesLeftInTheBook(n - 1);
            }
        }
    }
}
