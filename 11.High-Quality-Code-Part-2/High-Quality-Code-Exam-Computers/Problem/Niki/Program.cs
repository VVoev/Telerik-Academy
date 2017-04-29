namespace Computers.UI.Common
{
    using System;
    using Manufacturers;

    public static class Program
    {
        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            CreateComputers();
            ProcessCommands();
        }

        private static void CreateComputers()
        {
            var manufacturer = Console.ReadLine();
            IComputersFactory computerFactory;

            if (manufacturer == "HP")
            {
                computerFactory = new HpComputerFactory();
            }
            else if (manufacturer == "Dell")
            {
                computerFactory = new DellComputerFactory();
            }
            else if (manufacturer == "Lenovo")
            {
                computerFactory = new LenovoComputerFactory();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            pc = computerFactory.CreatePersonalComputer();
            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreateServer();
        }

        private static void ProcessCommands()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == null)
                {
                    break;
                }

                if (command.StartsWith("Exit"))
                {
                    break;
                }

                var cp = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = cp[0];
                var commandArguments = int.Parse(cp[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArguments);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArguments);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArguments);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}
