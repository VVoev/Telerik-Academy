using ProjectManager.Factories;
using System;
using System.Linq;

namespace ProjectManager.Common
{
    public class CmdCPU
    {
        private CommandsFactory factory;

        public CmdCPU(CommandsFactory factory)
        {
            this.factory = factory;
        }

        public string Process(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var command = this.factory.CreateCommandFromString(input.Split(' ')[0]);
            return command.Execute(input.Split(' ').Skip(1).ToList());           
        }
    }
}
