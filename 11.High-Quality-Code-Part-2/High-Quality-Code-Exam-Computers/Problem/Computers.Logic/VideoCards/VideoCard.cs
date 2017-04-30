namespace Computers.Logic.VideoCards
{
    using System;

    public abstract class VideoCard
    {
        public void Draw(string a)
        {
            var color = this.GetColor();
            Console.ForegroundColor = color;
            Console.WriteLine(a);
            Console.ResetColor();
        }

        public abstract ConsoleColor GetColor();
    }
}
