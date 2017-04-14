using System.Diagnostics;

namespace AssertionDemo
{
 public class AssertionDemo
    {
        public static void Main(string[] args)
        {
            Debug.Assert(PerformAction(),  "Could not perform action");
            var studentsCalculator = new StudentGradesCalculator(new int[] { 1, 2, 3, 4, 5 });

            var c = studentsCalculator.GetAverageStudentGrade();
            //
        }

        private static bool PerformAction()
        {
            System.Console.WriteLine("Action Performed");
            return true;
        }
    }
}
