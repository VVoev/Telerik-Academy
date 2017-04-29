namespace Computers.UI.Common.Manufacturers
{
    using System;

    public class LenovoComputerFactory : IComputersFactory
    {
        public Laptop CreateLaptop()
        {
            var ram = new Ram(16);
            var videoCard = new VideoCard();
            var battery = new LaptopBattery();
            var laptop = new Laptop(new Cpu(2, 64, ram, videoCard), ram, new[] { new HardDrive(1000, false, 1) }, videoCard, battery);

            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(16);
            var videoCard = new VideoCard();
            var pc = new PersonalComputer(new Cpu(2, 64, ram, videoCard), ram, new[] { new HardDrive(1000, false, 1) }, videoCard);

            return pc;
        }

        public Server CreateServer()
        {
            var ram = new Ram(64);
            var videoCard = new VideoCard();
            var server = new Server(new Cpu(2, 64, ram, videoCard), ram, new[] { new HardDrive(1000, false, 1) }, videoCard);
            return server;
        }
    }
}
