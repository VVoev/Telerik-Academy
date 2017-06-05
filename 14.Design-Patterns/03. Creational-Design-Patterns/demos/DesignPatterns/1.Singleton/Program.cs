using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = Logger.Instance;
            log.Save("Welcome To Singleton");
            log.Save("Your first Pattern");

            var log2 = Logger.Instance;
            log2.Save("Watz up");

            log.Print();
            MakeFreeLines(2);
            Logger.Instance.Print();
        }

        private static void MakeFreeLines(int v)
        {
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
