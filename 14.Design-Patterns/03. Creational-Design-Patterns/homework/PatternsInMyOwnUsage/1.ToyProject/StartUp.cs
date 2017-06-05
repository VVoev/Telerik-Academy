using _1.ToyProject.Factories;
using System;
using System.Collections.Generic;
using ToyProject.Toys;

namespace ToyProject
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var commands = new List<string>();
            commands.Add("Sit");
            commands.Add("Jump");
            commands.Add("Talk");
            var bearComputer = new ComputerToy(commands, "Teddy Bear with Computer");
            //Console.WriteLine(bearComputer);

            var chinese = new ChineseFactory();
            var cBear = chinese.MakeTeddyBearWithComputer();
            Console.WriteLine(cBear);

            var spinner = chinese.MakeSuperSpinner();
            Console.WriteLine(spinner);
        }
    }
}
