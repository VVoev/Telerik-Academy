namespace _03.StudentOperations.Students
{
    using System;

    public class Group
    {
        // Fields in class Group.
        int groupNumber;
        string departmentName;

        // Properties in class Group.
        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("Group number can not be negative number.");
                }
                this.groupNumber = value;
            }
        }
        public string DepartmentName
        {
            get { return this.departmentName; }
            set
            {
                if (value.Equals(null))
                {
                    throw new FormatException("Group number can not be negative number.");
                }
                this.departmentName = value;
            }
        }

        // Constructor in class Group.
        public Group(string groupName, int group)
        {
            this.DepartmentName = groupName;
            this.GroupNumber = group;
        }
    }
}
