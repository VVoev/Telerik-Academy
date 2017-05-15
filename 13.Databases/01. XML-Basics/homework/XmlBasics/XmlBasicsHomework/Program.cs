using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlBasicsHomework.Enums;
using XmlBasicsHomework.Models;

namespace XmlBasicsHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            FillData(students);

            var xmlDoc = CreateXml(students);

            Console.WriteLine(xmlDoc);
        }

        private static XDocument CreateXml(List<Student> students,string path= null)
        {
            XNamespace ns = "urn:students";
            if(path == null)
            {
                path = "../../../";
            }

            XDeclaration declaration = new XDeclaration("1.0", "utf-8", null);
            XDocument xml = new XDocument();

            xml.Declaration = declaration;

            var root = new XElement("students");
            xml.Add(root);
            root.SetAttributeValue(XNamespace.Xmlns + "student", ns);

            foreach (var student in students)
            {
                var studentElement = new XElement("student");

                studentElement.Add(new XAttribute("faculty-number", student.FacultyNumber));
                studentElement.Add(new XElement("name", student.Name));
                studentElement.Add(new XElement("gender", student.Gender));
                studentElement.Add(new XElement("birthday", student.Birthday.ToShortDateString()));
                studentElement.Add(new XElement("phone", student.Phone));
                studentElement.Add(new XElement("email", student.Email));
                studentElement.Add(new XElement("course", student.Course));
                studentElement.Add(new XElement("specialty", student.Specialty));

                var exams = new XElement("taken-exams");
                foreach (var exam in student.Exams)
                {
                    var examElem = new XElement("exam");
                    examElem.Add(new XElement("name", exam.Name));
                    examElem.Add(new XElement("tutor", exam.Tutor));
                    examElem.Add(new XElement("score", exam.Score));
                }

                studentElement.Add(exams);
                root.Add(studentElement);
            }
            xml.Save(path + "students.xml");
            return xml;
        }

        private static void FillData(List<Student> students)
        {
            var firstStudent = new Student()
            {
                Name = "Petar",
                Gender = Gender.Male,
                Birthday = new DateTime(1985, 7, 17),
                Phone = "09888232313",
                Email = "Kiro@abv.bg",
                Course = Course.First,
                Specialty = Specialty.BackEnd,
                FacultyNumber = "12345",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                    Name= "CSharp",
                    Tutor = "Noone",
                    Score = 3
                    }
                }
            };

            var secondStudent = new Student()
            {
                Name = "Pepa",
                Gender = Gender.Female,
                Birthday = new DateTime(1932, 5, 12),
                Phone = "0834827382",
                Email = "Popa@abv.bg",
                Course = Course.Second,
                Specialty = Specialty.FrontEnd,
                FacultyNumber = "66666",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                    Name= "Js",
                    Tutor = "Cuki",
                    Score = 6
                    }
                }
            };

            var thirdStudent = new Student()
            {
                Name = "VirtualJiraff",
                Gender = Gender.Alien,
                Birthday = new DateTime(1992, 5, 16),
                Phone = "0834827382",
                Email = "bigP@abv.bg",
                Course = Course.Fourth,
                Specialty = Specialty.FullStack,
                FacultyNumber = "66666",
                Exams = new List<Exam>()
                {
                    new Exam()
                    {
                    Name= "Microsoft",
                    Tutor = "Junior",
                    Score = 6
                    }
                }
            };

            students.AddRange(new List<Student> { firstStudent, secondStudent, thirdStudent });

        }
    }
}
