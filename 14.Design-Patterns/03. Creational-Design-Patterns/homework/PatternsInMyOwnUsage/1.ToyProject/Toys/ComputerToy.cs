using System;
using System.Collections.Generic;
using _1.ToyProject.Toys;

namespace ToyProject.Toys
{
    public class ComputerToy : Toy
    {
        private readonly string name;

        public ComputerToy(IEnumerable<string> commands, string name) : base(commands)
        {
            this.name = name;
        }

        public override string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
