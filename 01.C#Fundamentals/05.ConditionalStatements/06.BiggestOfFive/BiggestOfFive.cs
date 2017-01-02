using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BiggestOfFive
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        double temp1 = Math.Max(a, b);
        double temp2 = Math.Max(a, c);
        double temp3 = Math.Max(a, d);
        double temp4 = Math.Max(a, e);

        if (temp1 > temp2 && temp1 > temp3 && temp1 > temp4)
        {
            Console.WriteLine(temp1);
        }
        else if (temp2 > temp1 && temp2 > temp3 && temp2 > temp4)
        {
            Console.WriteLine(temp2);
        }
        else if (temp3 > temp1 && temp3 > temp2 && temp3 > temp4)
        {
            Console.WriteLine(temp3);
        }
        else if (temp4 > temp1 && temp4 > temp2 && temp4 > temp3)
        {
            Console.WriteLine(temp4);
        }
        else if (temp2 == temp1 && temp2 == temp3 && temp3 == temp4)
        {
            Console.WriteLine(temp1);
        }
    }
}
