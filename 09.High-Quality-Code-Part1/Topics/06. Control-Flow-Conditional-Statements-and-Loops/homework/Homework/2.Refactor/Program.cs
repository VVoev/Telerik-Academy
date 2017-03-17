using System;
using Refactor;

namespace _2.Refactor
{
    public class Program
    {
        private static bool shouldNotVisitCell;

        public static void Main(string[] args)
        {
             ////first
            Potato potato = new Potato();
            potato.IsRotten = true;
            potato.IsPeeled = true;

            if (potato != null)
            {
                bool isPeeled = potato.IsPeeled;
                bool isRotten = potato.IsRotten;

                if (isRotten && isPeeled)
                {
                    Cook(potato);
                }
            }

            ////second
            const int MIN_X = 10;
            const int MAX_X = 20;
            const int MIN_Y = 30;
            const int MAX_Y = 40;

            int x = 5;
            int y = 8;

            if (IsInRange(x, y, MIN_X, MAX_X, MIN_Y, MAX_Y) && !shouldNotVisitCell)
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
            throw new NotImplementedException();
        }

        public static bool IsInRange(int x, int y, int minX, int maxX, int minY, int maxY)
        {
            if (x >= minX && (x <= maxX && (maxY >= y && minY <= y)))
            {
                return true;
            }

            return false;
        }

        private static void Cook(Potato potato)
        {
            Console.WriteLine($@"{potato.GetType().Name} is in the oven");
        }
    }
}
