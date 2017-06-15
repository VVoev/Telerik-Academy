using System.Linq;

using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

using ProjectManager.Framework.Core.Commands.Contracts;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class CommandProcessor : IProcessor
    {

        private ICommandsFactory commandsFactory;

        public CommandProcessor(ICommandsFactory commandsFactory)
        {
            this.commandsFactory = commandsFactory;
        }

        public ICommandsFactory CommandFactory
        {
            get
            {
                return this.commandsFactory;
            }

            set
            {
                Guard.WhenArgument(value, "CommandProcessor CommandsFactory").IsNull().Throw();
                this.commandsFactory = value;
            }
        }

        public string ProcessCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new UserValidationException("No command has been provided!");
            }

            var commandName = commandLine.Split(' ')[0];
            var commandParameters = commandLine
                .Split(' ')
                .Skip(1)
                .ToList();

            var command = this.CommandFactory.GetCommandFromString(commandName);

            return command.Execute(commandParameters);
        }
    }
}
