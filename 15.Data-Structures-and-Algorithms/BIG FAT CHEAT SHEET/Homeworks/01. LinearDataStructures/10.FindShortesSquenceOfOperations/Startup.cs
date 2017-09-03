using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.FindShortesSquenceOfOperations
{
    public class Startup
    {
        public static void Main()
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            var operations = new Queue<int>();

            while(startNumber != endNumber)
            {
                operations.Enqueue(endNumber);

                if (endNumber / 2 >= startNumber)
                {
                    if (endNumber % 2 == 0)
                    {
                        endNumber /= 2;
                    }
                    else
                    {
                        endNumber--;
                    }
                }
                else
                {
                    if (endNumber - 2 >= startNumber)
                    {
                        endNumber -= 2;
                    }
                    else
                    {
                        endNumber--;
                    }
                }
            }

            operations.Enqueue(startNumber);
            Console.WriteLine(string.Join(", ", operations.Reverse()));
        }
    }
}
