using System;

namespace _DP_ExchangeRates
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxCurrency1 = double.Parse(Console.ReadLine());
            double maxCurrency2 = 0;
            int N = int.Parse(Console.ReadLine());


            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var rate12 = double.Parse(input[0]);
                var rate21 = double.Parse(input[1]);

                var currency1 = Math.Max(maxCurrency1, rate21 * maxCurrency2);
                var currency2 = Math.Max(maxCurrency2, maxCurrency1 * rate12);

                maxCurrency1 = currency1;
                maxCurrency2 = currency2;
            }

            //var res = Recurssion(rate12, rate21, 0, C, true);
            Console.WriteLine("{0:f2}",maxCurrency1);
        }

        //static double Recurssion(double []rate12, double []rate21,int day,double currency,bool isFirst)
        //{
        //    if(day== rate21.Length)
        //    {
        //        return isFirst ? currency : 0;
        //    }

        //    return Math.Max
        //    (Recurssion(rate12, rate21, day + 1, currency, isFirst),
        //    Recurssion(rate12, rate21, day + 1, currency * (isFirst ? rate12[day] : rate21[day]), !isFirst));
        //}
    }
}
