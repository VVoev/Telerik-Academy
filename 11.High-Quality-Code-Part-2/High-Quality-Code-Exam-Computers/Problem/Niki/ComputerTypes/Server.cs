namespace Computers.UI.Common
{
    using System.Collections.Generic;

    public class Server : Computer
    {
        public Server(
            Cpu cpu,
          Ram ram,
          IEnumerable<HardDriver> hardDrives,
          VideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.VideoCard.IsMonochrome = true;
        }

        internal void Process(int data)
        {
            this.Ram.SaveValue(data);
            //// TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
