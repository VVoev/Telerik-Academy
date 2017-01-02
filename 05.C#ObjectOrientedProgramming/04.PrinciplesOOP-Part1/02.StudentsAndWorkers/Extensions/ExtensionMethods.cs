namespace _02.StudentsAndWorkers.Extensions
{
    using People;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        public static ICollection<Student> OrderByGrade(this ICollection<Student> listOfStudents)
        {
            var orderedStudents = listOfStudents.OrderBy(x => x.Grade)
                                                .ToList();
            return orderedStudents;
        }
        public static ICollection<Worker> OrderByMoneyPerHour(this ICollection<Worker> listOfWorkers)
        {
            var orderedWorkers = listOfWorkers.OrderByDescending(x => x.MoneyPerHour())
                                              .ToList();
            return orderedWorkers;
        }
    }
}
