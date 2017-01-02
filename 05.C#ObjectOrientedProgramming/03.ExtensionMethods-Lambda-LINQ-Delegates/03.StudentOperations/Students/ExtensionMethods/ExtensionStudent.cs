namespace _03.StudentOperations.Students.ExtensionMethods
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionStudent
    {
        // Extension Methods for class Student.
        public static IEnumerable<Student> OrderByGroup(this IEnumerable<Student> unorderedStudents, int groupNumber)
        {
            var orderedStudents = unorderedStudents.Where(x => x.Group == groupNumber)
                                                   .ToList();
            return orderedStudents;
        }

        public static IEnumerable<Student> ThenByFirstName(this IEnumerable<Student> unorderedStudents)
        {
            var orderedStudents = unorderedStudents.OrderBy(x => x.FirstName)
                                                   .ToList();
            return orderedStudents;
        }

        public static IEnumerable<Student> ExtractByEmail(this IEnumerable<Student> listOfStudents, string email)
        {
            var extractedStudents = listOfStudents.Where(x => x.E_Mail.EndsWith(email))
                                                  .ToList();
            return extractedStudents;
        }

        public static IEnumerable<Student> ExtractByPhone(this IEnumerable<Student> listOfStudents, string phone)
        {
            var extractedStudents = listOfStudents.Where(x => x.E_Mail.StartsWith(phone))
                                                   .ToList();
            return extractedStudents;
        }

        public static IEnumerable<Student> ExtractByMarkLength(this IEnumerable<Student> listOfStudents, int numberOfMarks)
        {
            var extractedStudents = listOfStudents.Where(x => x.MarksLength.CompareTo(numberOfMarks) == 0)
                                                  .ToList();
            return extractedStudents;
        }

        public static IEnumerable<Student> ExtractByYearOfMarks(this IEnumerable<Student> listOfStudents, string year)
        {
            var extractedStudents = listOfStudents.Where(x => x.FacultyNumber.Substring(4,2).CompareTo(year) == 0)
                                                  .ToList();
            return extractedStudents;
        }
    }
}
