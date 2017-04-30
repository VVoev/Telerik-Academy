namespace Computers.Logic.VideoCards
{
    using System;

    public class ColorfulVideoCard : VideoCard
    {
        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }
    }
}
