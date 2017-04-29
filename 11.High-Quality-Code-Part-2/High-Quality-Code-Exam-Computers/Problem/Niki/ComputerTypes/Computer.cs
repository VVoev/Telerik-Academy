namespace Computers.UI.Common
{
    using System.Collections.Generic;

    public abstract class Computer
    {
        internal Computer(
        Cpu cpu,
        Ram ram,
        IEnumerable<HardDriver> hardDrives,
        VideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
        }

        protected IEnumerable<HardDriver> HardDrives { get; set; }

        protected VideoCard VideoCard { get; set; }

        protected Ram Ram { get; set; }

        protected Cpu Cpu { get; set; }
    }
}
