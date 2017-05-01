using StudentApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Common.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.Students[int.Parse(parameters[0])].ListMarks();
        }
    }
}
