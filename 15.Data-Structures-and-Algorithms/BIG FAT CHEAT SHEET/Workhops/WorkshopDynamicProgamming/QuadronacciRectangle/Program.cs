using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadronacciRectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long first = long.Parse(Console.ReadLine());
            long second = long.Parse(Console.ReadLine());
            long third = long.Parse(Console.ReadLine());
            long fourth = long.Parse(Console.ReadLine());

            long rows = long.Parse(Console.ReadLine());
            long cols = long.Parse(Console.ReadLine());

            var row = new long[cols];
            row[0] = first;
            row[1] = second;
            row[2] = third;
            row[3] = fourth;
            var builder = new StringBuilder();
            for (int i  = 0; i < rows; i++)
            {
                int index = i == 0 ? 4 : 0;
                for (int j = index; j < cols; j++)
                {
                    row[j] = first + second + third + fourth;
                    first = second;
                    second = third;
                    third = fourth;
                    fourth = row[j];
                }

                builder.AppendLine(string.Join(" ", row));
            }

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
