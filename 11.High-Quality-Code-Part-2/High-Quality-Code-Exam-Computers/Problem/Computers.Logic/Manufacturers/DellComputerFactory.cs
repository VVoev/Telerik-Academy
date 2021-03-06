﻿namespace Computers.Logic.Manufacturers
{
    using System.Collections.Generic;
    using ComputerTypes;
    using Cpus;
    using VideoCards;

    public class DellComputerFactory : IComputersFactory
    {
        public Laptop CreateLaptop()
        {
            var ram = new Ram(8);
            var videoCard = new ColorfulVideoCard();
            var laptop = new Laptop(
                new Cpu32(8 / 2, ram, videoCard),
                ram,
                new[] { new HardDrive(1000, false, 0) },
                videoCard,
                new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(8);
            var videoCard = new ColorfulVideoCard();
            var pc = new PersonalComputer(new Cpu64(8 / 2, ram, videoCard), ram, new[] { new HardDrive(1000, false, 0) }, videoCard);
            return pc;
        }

        public Server CreateServer()
        {
            var ram = new Ram(8 * 8);
            var card = new ColorfulVideoCard();
            var server = new Server(
                 new Cpu64(8, ram, card),
                 ram,
                 new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) }) },
                 card);
            return server;
        }
    }
}
