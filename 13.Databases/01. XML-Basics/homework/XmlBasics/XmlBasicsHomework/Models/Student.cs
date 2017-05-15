using System;
using System.Collections.Generic;
using XmlBasicsHomework.Enums;

namespace XmlBasicsHomework.Models
{
    public class Student
    {
        public Student()
        {

        }
        public Student(string name, Gender gender, DateTime birthday,
            string phone, string email,Course course,
            Specialty specialty, string facultyNumber,
           IEnumerable<Exam> exams)
        {
            this.Name = name;
            this.Gender = gender;
            this.Birthday = birthday;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.FacultyNumber = facultyNumber;
            this.Exams = exams;
        }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Course Course { get; set; }

        public Specialty Specialty { get; set; }

        public string FacultyNumber { get; set; }

        public IEnumerable<Exam> Exams { get; set; }
    }
}
