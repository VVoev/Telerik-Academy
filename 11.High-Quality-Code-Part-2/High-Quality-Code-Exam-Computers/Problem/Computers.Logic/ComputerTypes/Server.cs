namespace Computers.Logic.ComputerTypes
{
    using System.Collections.Generic;
    using VideoCards;

    public class Server : Computer
    {
        public Server(
            Cpu cpu,
          Ram ram,
          IEnumerable<HardDrive> hardDrives,
          ColorfulVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);
            //// TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
