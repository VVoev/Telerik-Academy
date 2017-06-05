using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyProject.Toys;

namespace _1.ToyProject.Factories
{
    public class ChineseFactory : ToyFactory
    {
        public override SpinToy MakeSuperSpinner()
        {
            var spinner = new SpinToy("FidgetSpinner");
            return spinner;
        }

        public override ComputerToy MakeTeddyBearWithComputer()
        {
            var commands = new List<string> { "282919", "jshjkashka", "sahsjkahsjka" };
            var name = "MalinDrun";
            var bearWithComputer = new ComputerToy(commands, name);
            return bearWithComputer;
        }
    }
}
