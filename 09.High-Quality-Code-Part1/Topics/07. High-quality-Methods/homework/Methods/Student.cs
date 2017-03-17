using System;

namespace Methods
{
   public class Student
    {
        public Student(string firstName, string lastName, DateTime birthday, Town town, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
            this.Town = town;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public DateTime Birthday { get; set; }

        public Town Town { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.Birthday.CompareTo(other.Birthday) < 0;
        }
    }
}
