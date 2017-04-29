﻿namespace Computers.UI.Common.Manufacturers
{
    using System.Collections.Generic;

    public class HpComputerFactory : IComputersFactory
    {
        public Laptop CreateLaptop()
        {
            var card = new VideoCard() { IsMonochrome = false };
            var ram = new Ram(8 / 2);
            var laptop = new Laptop(
                new Cpu(8 / 4, 64, ram, card),
                ram,
                new[] { new HardDriver(500, false, 0) },
                card,
                new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(8 / 4);
            var videoCard = new VideoCard()
            {
                IsMonochrome = false
            };
            var pc = new PersonalComputer(new Cpu(8 / 4, 32, ram, videoCard), ram, new[] { new HardDriver(500, false, 0) }, videoCard);
            return pc;
        }

        public Server CreateServer()
        {
            var serverRam = new Ram(8 * 4);
            var serverVideo = new VideoCard();
            var server = new Server(new Cpu(8 / 2, 32, serverRam, serverVideo), serverRam, new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(1000, false, 0), new HardDriver(1000, false, 0) }) }, serverVideo);

            return server;
        }
    }
}
