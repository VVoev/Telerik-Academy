using System;

namespace CompareSimpleMaths
{
    public class CompareSimpleMaths
    {
        public static void Main()
        {
            Console.WriteLine($@"Add operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Add, Type.Decimal);
            Tester.OperationTest(Operations.Add, Type.Int);
            Tester.OperationTest(Operations.Add, Type.Double);
            Tester.OperationTest(Operations.Add, Type.Float);
            Tester.OperationTest(Operations.Add, Type.Long);
            MakeFreeLines(2);

            Console.WriteLine($@"Substract operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Substract, Type.Decimal);
            Tester.OperationTest(Operations.Substract, Type.Int);
            Tester.OperationTest(Operations.Substract, Type.Double);
            Tester.OperationTest(Operations.Substract, Type.Float);
            Tester.OperationTest(Operations.Substract, Type.Long);
            MakeFreeLines(2);

            Console.WriteLine($@"Divide operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Divide, Type.Decimal);
            Tester.OperationTest(Operations.Divide, Type.Int);
            Tester.OperationTest(Operations.Divide, Type.Double);
            Tester.OperationTest(Operations.Divide, Type.Float);
            Tester.OperationTest(Operations.Divide, Type.Long);
            MakeFreeLines(2);

            Console.WriteLine($@"Multiply operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Multiply, Type.Decimal);
            Tester.OperationTest(Operations.Multiply, Type.Int);
            Tester.OperationTest(Operations.Multiply, Type.Double);
            Tester.OperationTest(Operations.Multiply, Type.Float);
            Tester.OperationTest(Operations.Multiply, Type.Long);
            MakeFreeLines(2);

            Console.WriteLine($@"Increment operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Increment, Type.Decimal);
            Tester.OperationTest(Operations.Increment, Type.Int);
            Tester.OperationTest(Operations.Increment, Type.Double);
            Tester.OperationTest(Operations.Increment, Type.Float);
            Tester.OperationTest(Operations.Increment, Type.Long);
            MakeFreeLines(2);

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
