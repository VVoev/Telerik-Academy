namespace _03.StudentInformation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        // Fields of class Student.
        private string firstName;
        private string surName;
        private string lastName;
        private string fullName;
        private Course course;
        private string speciality;
        private string university;
        private string mail;
        private string phoneNumber;

        // Properties of class Student.
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value == null)
                {
                    throw new FormatException("You must enter first name of the current student.");
                }
                this.firstName = value;
            }
        }
        public string SurName
        {
            get { return this.surName; }
            set { this.surName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value == null)
                {
                    throw new FormatException("You must enter last name of the current student.");
                }
                this.lastName = value;
            }
        }
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }
        public Course Course
        {
            get { return this.course; }
            set { this.course = value; }
        }
        public string Speciality
        {
            get { return this.speciality; }
            set { this.speciality = value; }
        }
        public string University
        {
            get { return this.university; }
            set { this.university = value; }
        }
        public string E_mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public Student(string fullName, Course course, string speciality, string university)
        {
            this.FullName = fullName;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
        }
        public Student(string firstName, string surName, string lastName, string mailAddress, string phoneNumber)
        {
            this.FirstName = firstName;
            this.SurName = surName;
            this.LastName = lastName;
            this.E_mail = mailAddress;
            this.PhoneNumber = phoneNumber;
        }
        public Student(string firstName, string lastName, string fullName, Course course, string speciality, string university, string mailAddress = null, string surName = null, string phoneNumber = null)
        {
            this.FirstName = fullName;
            this.SurName = surName;
            this.LastName = lastName;
            this.E_mail = mailAddress;
            this.PhoneNumber = phoneNumber;
            this.FullName = fullName;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
        }

        // Methods for class Student.

        public string PersonalStudentInfo(string name, string mail, string phone)
        {
            var personalData = new StringBuilder();
            personalData.AppendLine(name);
            personalData.AppendLine(mail);
            personalData.AppendLine(phone);
            return personalData.ToString();
        }
        public override string ToString()
        {
            var studentInformation = new StringBuilder();
            if (this.FirstName != null)
            {
                studentInformation.AppendLine("First name: " + this.FirstName);
            }
            if (this.SurName != null)
            {
                studentInformation.AppendLine("Surname: " + this.SurName);
            }
            if (this.LastName != null)
            {
                studentInformation.AppendLine("Last name: " + this.LastName);
            }
            if (this.FullName != null)
            {
                studentInformation.AppendLine("Full name: " + this.FullName);
            }
            if (this.Course != 0)
            {
                studentInformation.AppendLine("Course: " + this.Course);
            }
            if (this.Speciality != null)
            {
                studentInformation.AppendLine("Speciality: " + this.Speciality);
            }
            if (this.University != null)
            {
                studentInformation.AppendLine("University: " + this.University);
            }
            if (this.E_mail != null)
            {
                studentInformation.AppendLine("E-mail address: " + this.E_mail);
            }
            if (this.PhoneNumber != null)
            {
                studentInformation.AppendLine("First name: " + this.PhoneNumber);
            }
            return studentInformation.ToString();
        }
    }
}
