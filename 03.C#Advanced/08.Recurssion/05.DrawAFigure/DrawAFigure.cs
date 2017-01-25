using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DrawAFigure
{
    class DrawAFigure
    {
        public static int n;
        static void Main(string[] args)
        {
            //Lets make a diamond
            n = int.Parse(Console.ReadLine());
            MakeFirstPart(n);
            MakeLastPart(0);
        }

        private static int MakeLastPart(int x)
        {
            if (n != x)
            {
                Console.WriteLine(new string('*', MakeLastPart(x + 1)));
            }
            else
            {
                return x;
            }
            return x;
            
        }

        private static void MakeMiddlePart(int n)
        {
            Console.WriteLine(new string('*',n));
        }

        private static int MakeFirstPart(int n)
        {
          
            if  (n == 0)
            {
                Console.WriteLine(new string('*', n));
                return n;
            }
            else
            {
                Console.WriteLine(new string('*',MakeFirstPart(n-1)));
            }
            return n;
        }
    }
}
