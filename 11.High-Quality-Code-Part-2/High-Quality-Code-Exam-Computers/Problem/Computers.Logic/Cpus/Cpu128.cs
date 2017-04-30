namespace Computers.Logic.Cpus
{
    using Computers.Logic.VideoCards;

    public class Cpu128 : Cpu
    {
        internal Cpu128(byte numberOfCores, Ram ram, VideoCard videoCard) : base(numberOfCores, ram, videoCard)
        {
        }

        public override void SquareNumber()
        {
            this.SquareNumber(2000);
        }
    }
}
