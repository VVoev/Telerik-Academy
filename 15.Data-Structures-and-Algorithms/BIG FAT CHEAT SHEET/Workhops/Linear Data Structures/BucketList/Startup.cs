using LinearDataStructuresWorkshop.BucketListStrcuture;
using LinearDataStructuresWorkshop.NormalList;
using System;
using System.Diagnostics;

namespace LinearDataStructuresWorkshop
{
    public class Startup
    {
        public static void Main()
        {
            var normalList = new NormalList<int>();
            var bucketList = new BucketList<int>();

            for (int i = 0; i < 1000000; i++)
            {
                normalList.Add(i);
                bucketList.Add(i);
            }

            MeasureTime(() =>
            {
                for (int i = 0; i < 400000; i++)
                {
                    normalList.Remove(0);
                }

            }, "normal list removing");

            MeasureTime(() =>
            {
                for (int i = 0; i < 400000; i++)
                {
                    bucketList.Remove(0);
                }

            }, "bucket list removing");
        }

        public static void MeasureTime(Action action, string message)
        {
            var sw = new Stopwatch();

            sw.Start();
            action();
            sw.Stop();

            Console.WriteLine($"{message}: {sw.Elapsed}");
        }
    }
}
