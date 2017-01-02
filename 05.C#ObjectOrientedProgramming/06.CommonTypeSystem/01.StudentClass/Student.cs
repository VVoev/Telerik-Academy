namespace _01.StudentClass
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        // Fields.
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        //private string permanentAddress;
        //private string mobilePhone;
        //private string email;
        //private string course;
        //private string specialty;
        //private string university;
        //private string faculty;

        // Constructor.
        public Student(string firstName, string middleName, string lastName, string SSN)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.ssn = SSN;
        }

        // Properties.
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (this.firstName == null)
                {
                    throw new ArgumentException("You must enter first name.");
                }
                this.firstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                if (this.middleName == null)
                {
                    throw new ArgumentException("You must enter middle name.");
                }
                this.middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (this.lastName == null)
                {
                    throw new ArgumentException("You must enter last name.");
                }
                this.lastName = value;
            }
        }
        public string SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                if (this.ssn == null)
                {
                    throw new ArgumentException("You must enter social security number.");
                }
                this.ssn = value;
            }
        }
        public string PermanentAddress { get; set; }
        public string MobilePhone { get; set; }
        public string E_Mail { get; set; }
        public string Course { get; set; }
        public string Specialty { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }

        

        // Overrided Methods.
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.FirstName + " " + this.MiddleName + " " + this.LastName);
            sb.AppendLine("Student ID: " + this.SSN);
            if (this.PermanentAddress != null)
            {
                sb.AppendLine("Permanent address: " + this.PermanentAddress);
            }
            if (this.MobilePhone != null)
            {
                sb.AppendLine("Phone number: " + this.MobilePhone);
            }
            if (this.E_Mail != null)
            {
                sb.AppendLine("E-mail: " + this.E_Mail);
            }
            if (this.Course != null)
            {
                sb.AppendLine("Course: " + this.Course);
            }
            if (this.Specialty != null)
            {
                sb.Append("Specialty " + this.Specialty);
            }
            if (this.Faculty != null)
            {
                sb.Append("Faculty :" + this.Faculty);
            }
            if (this.University != null)
            {
                sb.AppendLine("University: " + this.University);
            }
            //sb.AppendLine(this.MobilePhone);
            //sb.AppendLine(this.E_Mail);
            //sb.AppendLine(this.Course);
            //sb.AppendLine(this.Specialty + ", " + this.Faculty + ", " + this.University);
            return sb.ToString();
        }
        public override int GetHashCode()
        {
            int hash = (int)this.firstName.GetHashCode() ^
                       (int)this.middleName.GetHashCode() ^
                       (int)this.lastName.GetHashCode() ^
                       (int)this.ssn.GetHashCode();
            return Math.Abs(hash);
        }
        public override bool Equals(object studentInfo)
        {
            if (this.FirstName.Equals(((Student)studentInfo).FirstName))
            {
                return true;
            }
            if (this.MiddleName.Equals(((Student)studentInfo).MiddleName)) 
            {
                return true;
            }
            if (this.LastName.Equals(((Student)studentInfo).LastName))
            {
                return true;
            }
            if (this.SSN.Equals(((Student)studentInfo).SSN)) 
            {
                return true;
            }
            return false;
        }

        // Predefined operators.
        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (Student.Equals(firstStudent,secondStudent))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            if (Student.Equals(firstStudent, secondStudent))
            {
                return false;
            }
            return true;
        }
        
        // Implementation of methods required from selected interfaces.
        public object Clone()
        {
            Student cloneStudent = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN);
            cloneStudent.PermanentAddress = this.PermanentAddress;
            cloneStudent.MobilePhone = this.MobilePhone;
            cloneStudent.E_Mail = this.E_Mail;
            cloneStudent.Faculty = this.Faculty;
            cloneStudent.Specialty = this.Specialty;
            cloneStudent.University = this.University;
            return cloneStudent;
        }

        public int CompareTo(Student comparingStudent)
        {
            if (this.FirstName.CompareTo(comparingStudent.FirstName) < 0)
            {
                return -1;
            }
            else if (this.FirstName.CompareTo(comparingStudent.FirstName) > 0)
            {
                return 1;
            }
            if (this.MiddleName.CompareTo(comparingStudent.MiddleName) < 0)
            {
                return -1;
            }
            else if (this.MiddleName.CompareTo(comparingStudent.MiddleName) > 0)
            {
                return 1;
            }
            if (this.LastName.CompareTo(comparingStudent.LastName) < 0)
            {
                return -1;
            }
            else if (this.LastName.CompareTo(comparingStudent.LastName) > 0)
            {
                return 1;
            }
            if (this.SSN.CompareTo(comparingStudent.SSN) < 0)
            {
                return -1;
            }
            else if (this.SSN.CompareTo(comparingStudent.SSN) > 0)
            {
                return 1;
            };
            return 0;
        }
    }
}
