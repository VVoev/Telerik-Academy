using SchoolSystem.Framework.Core.Commands.Factories.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Framework.Core.Commands.Factories
{
    public class CreateStudentFactory : ICreateStudentFactory
    {
        public IStudent CreateStudent(string firstname, string lastname, Grade grade)
        {
            return new Student(firstname, lastname, grade);
        }
    }
}
