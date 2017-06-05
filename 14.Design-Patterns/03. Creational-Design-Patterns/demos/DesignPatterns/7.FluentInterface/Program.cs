using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.FirstName("Vlado").Nickname("Psy").Score(100).Info();
        }
    }
}
