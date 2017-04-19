using CompareAdvancedMaths;
using CompareAdvancedMathsTypes;
using System;
using System.Diagnostics;

namespace CompareAdvancecMaths
{
    public static class Tester
    {
        private const int intNumber = 1;
        private const long longNumber = 1;
        private const float floatNumber = 1;
        private const double doubleNumber = 1;


        private const decimal decimalNumber = 1;
        private const int limit = 5000000;
        private const byte runs = 3;


        public static void OperationTest(Operations operations, CompareAdvancedMathsTypes.Type type)
        {
            for (int k = 1; k <= runs; k++)
            {
                var watch = new Stopwatch();
                watch.Start();

                dynamic result = 0;

                switch (type)
                {
                    case CompareAdvancedMathsTypes.Type.Float:
                        result = floatNumber;
                        break;
                    case CompareAdvancedMathsTypes.Type.Double:
                        result = doubleNumber;
                        break;
                    case CompareAdvancedMathsTypes.Type.Decimal:
                        result = decimalNumber;
                        break;
                }

                watch.Start();

                for (int i = 1; i < limit; i++)
                {
                    switch (operations)
                    {
                        case Operations.Root:
                            result = Math.Sqrt((double)(result));
                            break;
                        case Operations.Sinus:
                            result = Math.Sin((double)(result));
                            break;
                        case Operations.Log:
                            result = Math.Log((double)(result));
                            break;
                    }
                }

                //watch.Stop();
                //var time = watch.Elapsed;
                System.Console.WriteLine($@"Run Number {k} with loop of {limit} Time taken for operation [{operations}] is {watch.Elapsed} for the {type} type");
            }
        }
    }
}
