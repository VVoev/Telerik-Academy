using Computers.Logic.VideoCards;

namespace Computers.Logic.Cpus
{
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
