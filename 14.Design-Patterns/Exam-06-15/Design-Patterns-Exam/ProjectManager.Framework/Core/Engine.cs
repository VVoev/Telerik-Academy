using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IProcessor processor;
        private readonly ICommandsFactory commandFactory;

        public Engine(ILogger logger, ICommandsFactory commandFactory, IProcessor processor)
        {
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();
            this.logger = logger;
            this.commandFactory = commandFactory;
            this.processor = new CommandProcessor(this.commandFactory);
        }

        public void Start()
        {
            var commandLine = Console.ReadLine();

            //// code is modified for better reading
            while (commandLine.ToLower() != "exit")
            {
                if (commandLine.ToLower() == "exit")
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(commandLine);
                    Console.WriteLine(executionResult);
                }

                catch (UserValidationException ex)
                {
                    this.logger.Error(ex.Message);
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Opps, something happened. Check the log file :(");
                    this.logger.Error(ex.Message);
                }

                // exit of while-loop
                commandLine = Console.ReadLine();
            }
        }
    }
}