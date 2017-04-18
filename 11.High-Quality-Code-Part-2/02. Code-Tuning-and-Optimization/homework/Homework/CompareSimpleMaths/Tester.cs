using System.Diagnostics;

namespace CompareSimpleMaths
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


        public static void OperationTest(Operations operations, Type type)
        {
            for (int k = 1; k <= runs; k++)
            {
                var watch = new Stopwatch();
                watch.Start();

                dynamic result = 0;

                switch (type)
                {
                    case Type.Int:
                        result = intNumber;
                        break;
                    case Type.Long:
                        result = longNumber;
                        break;
                    case Type.Float:
                        result = floatNumber;
                        break;
                    case Type.Double:
                        result = doubleNumber;
                        break;
                    case Type.Decimal:
                        result = decimalNumber;
                        break;
                }

                watch.Start();

                for (int i = 0; i < limit; i++)
                {
                    switch (operations)
                    {
                        case Operations.Add:
                            result += intNumber;
                            break;
                        case Operations.Substract:
                            result -= intNumber;
                            break;
                        case Operations.Increment:
                            result++;
                            break;
                        case Operations.Multiply:
                            result *= intNumber;
                            break;
                        case Operations.Divide:
                            result /= intNumber;
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
