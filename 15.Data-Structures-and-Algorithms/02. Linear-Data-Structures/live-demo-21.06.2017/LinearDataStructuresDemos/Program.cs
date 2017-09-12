using System;
using System.Diagnostics;
using Helpers;
using Queue;
using System.Collections.Generic;
using System.Collections;
using ListDataStructure;

namespace DsaDemos
{
    class Range : IEnumerable<int>
    {
        private int startValue;
        private int endValue;
        private int step;

        public Range(int end)
        {
            startValue = 0;
            endValue = end;
            step = 1;
        }

        public Range(int start, int end, int step = 1)
        {
            startValue = start;
            endValue = end;
            this.step = step;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for(int i = startValue; i < endValue; i += step)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void TimeCode(Action func)
        {
            var watch = new Stopwatch();

            watch.Start();
            func();
            watch.Stop();

            Console.WriteLine($"Elapsed: {watch.Elapsed}");
        }

        static void Main()
        {
            var list = new ListDataStructure.List<int>() { 4, 5, 6, 1 };
            list.PushBack(7);
            list.PushBack(3);
            list[3] = 11;

            foreach(var x in list)
            {
                Console.WriteLine(x);
            }
        }

        static Optional<int> Divide(Optional<int> x, Optional<int> y)
        {
            bool hasValue = false;
            int value = 0;

            x.WithValue(xv =>
            {
                y.WithValue(yv =>
                {
                    if (yv == 0)
                    {
                        hasValue = false;
                    }
                    else
                    {
                        hasValue = true;
                        value = xv / yv;
                    }
                });
            });

            if (hasValue)
            {
                return new Optional<int>(value);
            }
            else
            {
                return new Optional<int>();
            }
        }
    }
}
