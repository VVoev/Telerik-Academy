namespace _01.SchoolClasses.Schools
{
    using SchoolClasses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class School
    {
        // Field.
        private IEnumerable<SchoolClass> schoolClasses;

        // Property.
        public IEnumerable<SchoolClass> SchoolClasses { get { return this.schoolClasses; } set { this.schoolClasses = value; } }

        // Constructors.
        public School()
        {

        }

        public School(IEnumerable<SchoolClass> classesInSchool)
        {
            this.SchoolClasses = classesInSchool;
        }

        // Methods.
        public override string ToString()
        {
            return string.Format("Classes: \r\n" + string.Join(Environment.NewLine, this.SchoolClasses));
        }
    }
}
