using StudentApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Common.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.Students.Remove(int.Parse(paras[0]));
            return $"Student with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }
}
