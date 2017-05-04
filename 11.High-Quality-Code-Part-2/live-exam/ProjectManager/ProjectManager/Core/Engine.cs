using Bytes2you.Validation;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Contacts;
using System;

namespace ProjectManager.Core
{
    public class Engine : IEngine
    {
        private FileLogger logger;
        private CmdCPU processor;

        public Engine(FileLogger logger, CmdCPU processor)
        {
            // validate clauses
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();

            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();

            this.logger = logger;

            this.processor = processor;
        }

        public void Start()
        {
            // read from console
            while (true)
            {
                var input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Program terminated.");
                    return;
                }

                try
                {
                    var executionResult = this.processor.Process(input);
                    Console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }        
        }
    }
}
