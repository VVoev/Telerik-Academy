namespace _03.StudentOperations.Students.ExtensionMethods
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionGroupStudent
    {
        public static IEnumerable<IGrouping<int,Student>> ExtractInGroups(this IEnumerable<Student> listOfStudents)
        {
            var studentsByGroupNumber = listOfStudents.GroupBy(x => x.Group)
                                                      .ToList();
            return studentsByGroupNumber;
        }
    }
}
