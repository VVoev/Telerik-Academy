namespace Computers.Logic.Cpus
{
    using Computers.Logic.VideoCards;

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
