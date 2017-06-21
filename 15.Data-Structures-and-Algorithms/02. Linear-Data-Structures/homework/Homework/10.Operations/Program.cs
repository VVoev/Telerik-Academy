using System;
using System.Collections.Generic;

namespace _10.Operations
{
    class Program
    {
        static void Main()
        {
            var begin = 5;
            var end = 16;

            var set = FindSequence(begin, end);
            Console.WriteLine(string.Join(" ",set));
        }

        private static SortedSet<int> FindSequence(int begin, int end)
        {
            var set = new SortedSet<int>();
            set.Add(end);
            set.Add(begin);

            while(end > begin)
            {
                if (end / 2 > begin && end%2 ==0)
                {
                    end = end /= 2;
                    set.Add(end);
                }

                else if (end /2 > begin && end/2 == 1)
                {
                    end--;
                    set.Add(end);

                    end = end /= 2;
                    set.Add(end);
                }
                
                else if(end - 2 >= begin)
                {
                    end -= 2;
                    set.Add(end);
                }

                else
                {
                    end--;
                    set.Add(end);
                }
            }

            return set;
        }
    }
}
