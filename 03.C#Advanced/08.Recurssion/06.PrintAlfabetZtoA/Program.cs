using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrintAlfabetZtoA
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = '@';
            PrintAlfabet(a);
        }

        private static char PrintAlfabet(char a)
        {
            if (a == 'Z')
            {
                return a;
            }
            else
            {
                Console.WriteLine($"ASii number{(int)a+1} Letter: "+PrintAlfabet((char)(a+1)));
                return a;
            }
            
        }
    }
}
