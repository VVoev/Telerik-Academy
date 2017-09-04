using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steve
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            bool isPalindrome = false;
            int i = 0, j = pattern.Length - 1;
            int mismatchCounter = 0;

            while (i <= j)
            {
                //reverse matching
                if (pattern[i] == pattern[j])
                {
                    i++; j--;
                    isPalindrome = true;
                    continue;
                }

                else if (pattern[i] != pattern[j])
                {
                    i++;
                    mismatchCounter++;
                }


            }
            //Console.WriteLine("The pattern string is :" + pattern);
            //Console.WriteLine("Minimum number of characters required to make this string a palidnrome : " + mismatchCounter);
            Console.WriteLine(mismatchCounter);
        }
    }
}
