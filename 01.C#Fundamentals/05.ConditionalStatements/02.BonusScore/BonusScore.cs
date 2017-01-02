using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BonusScore
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        if (n >= 1 && n <= 3)
        {
            Console.WriteLine(n * 10);
        }
        else if (n >= 4 && n <= 6)
        {
            Console.WriteLine(n * 100);
        }
        else if (n >= 7 && n <= 9)
        {
            Console.WriteLine(n * 1000);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
}
