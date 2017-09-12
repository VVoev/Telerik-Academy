using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            var codes = GrayCodes(n);
            foreach(var code in codes)
            {
                Console.WriteLine(code);
            }
        }

        static List<string> GrayCodes(int n)
        {
            if(n == 0)
            {
                return new List<string>();
            }
            if (n == 1)
            {
                return new List<string> { "0", "1" };
            }

            var firstHalf = GrayCodes(n - 1);
            var secondHalf = firstHalf.ToList();
            secondHalf.Reverse();

            firstHalf = firstHalf
                .Select(code => "0" + code)
                .ToList();

            secondHalf = secondHalf
                .Select(code => "1" + code)
                .ToList();

            firstHalf.AddRange(secondHalf);
            return firstHalf;
        }
    }
}
