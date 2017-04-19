using CompareAdvancecMaths;
using CompareAdvancedMaths;
using System;

namespace Compare_advanced_Maths
{
    public class CompareAdvancedMaths
    {
        static void Main()
        {
            Console.WriteLine($@"Root operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Root, CompareAdvancedMathsTypes.Type.Float);
            Tester.OperationTest(Operations.Root, CompareAdvancedMathsTypes.Type.Double);
            Tester.OperationTest(Operations.Root, CompareAdvancedMathsTypes.Type.Decimal);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($@"Sinus operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Sinus, CompareAdvancedMathsTypes.Type.Float);
            Tester.OperationTest(Operations.Sinus, CompareAdvancedMathsTypes.Type.Double);
            Tester.OperationTest(Operations.Sinus, CompareAdvancedMathsTypes.Type.Decimal);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($@"Log operations");
            Console.WriteLine("--------------------------------");
            Tester.OperationTest(Operations.Log, CompareAdvancedMathsTypes.Type.Float);
            Tester.OperationTest(Operations.Log, CompareAdvancedMathsTypes.Type.Double);
            Tester.OperationTest(Operations.Log, CompareAdvancedMathsTypes.Type.Decimal);
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
