namespace Computers.Logic.VideoCards
{
    using System;

    public class MonochromeVideoCard : VideoCard
    {
        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Gray;
        }
    }
}
