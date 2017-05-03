using System.Collections.Generic;

namespace SchoolSystem.Core.Commands
{
    class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.students.Remove(int.Parse(paras[0]));
            return $"Student with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }
}
