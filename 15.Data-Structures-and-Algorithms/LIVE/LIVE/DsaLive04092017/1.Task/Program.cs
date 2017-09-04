using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication111
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var bashMAx = long.MinValue;
            var listnumbers = new List<long>();
            var sb = new StringBuilder();
            Console.ReadLine();

            var arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();


            for (long i = 0; i < arr.Length; i++)
            {
                listnumbers.Add(arr[i]);
                if(i == arr.Length - 1)
                {
                    sb.Append(0);
                }
                else
                {
                    for (long j = i + 1; j < arr.Length; j++)
                    {

                        var position = listnumbers.Last();
                        var nextPosition = arr[j];

                        if (position < nextPosition)
                        {
                            listnumbers.Add(nextPosition);
                        }
                    }
                    sb.Append(listnumbers.Count-1);
                    var curentMax = listnumbers.Count - 1;

                    if (curentMax >= bashMAx)
                    {
                        bashMAx = curentMax;
                    }


                    //Console.WriteLine(string.Join(" ",listnumbers));
                    listnumbers.Clear();
                }
            }


            Console.WriteLine(bashMAx);
            for (int i = 0; i < sb.Length; i++)
            {
                if (i == sb.Length - 1)
                    Console.Write(sb[i]);
                else
                    Console.Write(sb[i] + " ");
            }
            Console.WriteLine();
         
        }
   }
}



