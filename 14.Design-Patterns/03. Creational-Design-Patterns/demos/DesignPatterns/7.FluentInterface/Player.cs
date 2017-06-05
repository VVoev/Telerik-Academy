using FluentInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterface
{
    public class Player
    {
        private readonly PlyaerContext context = new PlyaerContext();

        public Player Score(int Score)
        {
            this.context.Score = Score;
            return this;
        }

        public Player FirstName(string firstname)
        {
            this.context.FirstName = firstname;
            return this;
        }

        public Player Nickname(string nickname)
        {
            this.context.NickName = nickname;
            return this;
        }

        public void Info()
        {
            Console.WriteLine($@"{this.context.FirstName} with abreviature {this.context.NickName} has made score {this.context.Score}");
        }

    }
}
