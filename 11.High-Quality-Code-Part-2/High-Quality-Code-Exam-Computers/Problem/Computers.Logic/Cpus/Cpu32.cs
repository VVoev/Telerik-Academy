namespace Computers.Logic.Cpus
{
    using Computers.Logic.VideoCards;

    public class Cpu32 : Cpu
    {
        internal Cpu32(byte numberOfCores, Ram ram, VideoCard videoCard) : base(numberOfCores, ram, videoCard)
        {
        }

        public override void SquareNumber()
        {
            this.SquareNumber(500);
        }
    }
}
