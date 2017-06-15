using ProjectManager.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICommand command;
        private int parameterCount;

        public CacheableCommand(ICommand command)
        {
            if (this.command == null)
            {
                throw new ArgumentNullException();
            }

            this.command = command;
        }

        public int ParameterCount
        {
            get
            {
                return this.parameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
