using Computers.Logic.VideoCards;

namespace Computers.Logic.Cpus
{
    public class Cpu64 : Cpu
    {
        internal Cpu64(byte numberOfCores, Ram ram, VideoCard videoCard) : base(numberOfCores, ram, videoCard)
        {
        }

        public override void SquareNumber()
        {
            this.SquareNumber(1000);
        }
    }
}
