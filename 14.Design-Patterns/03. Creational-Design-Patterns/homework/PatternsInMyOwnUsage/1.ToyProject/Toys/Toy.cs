using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ToyProject.Toys
{
    public abstract class Toy
    {
        private readonly IReadOnlyCollection<string> commands;

        protected Toy(IEnumerable<string>commands)
        {
            this.commands = new List<string>(commands);
        }

        public abstract string Name { get; set; }

        private IEnumerable<string> Commands
        {
            get
            {
                return this.commands;
            }
        }

        public override string ToString()
        {
            return $@"I am {this.Name} and i have the following commands {Environment.NewLine}{string.Join(Environment.NewLine, this.commands)}";
        }

    }
}
