using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Models
{
    public class School : ISchool
    {
        private readonly IDictionary<int, IStudent> students;
        private readonly IDictionary<int, ITeacher> teachers;

        public School()
        {
            this.students = new Dictionary<int, IStudent>();
            this.teachers = new Dictionary<int, ITeacher>();
        }

        public void AddStudent(int id, IStudent student)
        {
            this.students.Add(id, student);
        }

        public void AddTeacher(int id, ITeacher teacher)
        {
            this.teachers.Add(id, teacher);
        }

        public void RemoveStudent(int id)
        {
            this.students.Remove(id);
        }

        public void RemoveTeacher(int id)
        {
            this.teachers.Remove(id);
        }

        public IStudent GetStudent(int id)
        {
            return this.students[id];
        }

        public ITeacher GetTeacher(int id)
        {
            return this.teachers[id];
        }   
    }
}
