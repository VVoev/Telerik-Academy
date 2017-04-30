using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Logic.VideoCards
{
    public class MonochromeVideoCard : VideoCard
    {
        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Gray;
        }
    }
}
