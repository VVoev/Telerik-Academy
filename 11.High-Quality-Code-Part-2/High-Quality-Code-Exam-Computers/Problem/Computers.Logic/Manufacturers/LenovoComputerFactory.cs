namespace Computers.Logic.Manufacturers
{
    using ComputerTypes;
    using Cpus;
    using VideoCards;
    public class LenovoComputerFactory : IComputersFactory
    {
        public Laptop CreateLaptop()
        {
            var ram = new Ram(16);
            var videoCard = new ColorfulVideoCard();
            var battery = new LaptopBattery();
            var laptop = new Laptop(new Cpu64(2, ram, videoCard), ram, new[] { new HardDrive(1000, false, 1) }, videoCard, battery);

            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(16);
            var videoCard = new ColorfulVideoCard();
            var pc = new PersonalComputer(new Cpu64(2, ram, videoCard), ram, new[] { new HardDrive(1000, false, 1) }, videoCard);

            return pc;
        }

        public Server CreateServer()
        {
            var ram = new Ram(64);
            var videoCard = new ColorfulVideoCard();
            var server = new Server(new Cpu64(2, ram, videoCard), ram, new[] { new HardDrive(1000, false, 1) }, videoCard);
            return server;
        }
    }
}
