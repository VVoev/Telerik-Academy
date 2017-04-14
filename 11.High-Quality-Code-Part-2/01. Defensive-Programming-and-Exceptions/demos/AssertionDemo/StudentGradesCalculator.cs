using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class StudentGradesCalculator
{
    private readonly IList<int> studentGrades;

    public StudentGradesCalculator(IList<int> studentGrades)
    {
        this.studentGrades = studentGrades;
    }

    public double GetAverageStudentGrade()
    {
        Debug.Assert(this.studentGrades != null && this.studentGrades.Count > 0,
            "Student grades are not initialized!");

        return this.studentGrades.Average();
    }
}