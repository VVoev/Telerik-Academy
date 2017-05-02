using SchoolSystemCli;
using System.Collections.Generic;

namespace SchoolSystem.CLI.Core.Commands.Contracts
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            Engine.Teachers.Remove(int.Parse(parameters[0]));
            return $"Teacher with ID {int.Parse(parameters[0])} was sucessfully removed.";
        }
    }
}
