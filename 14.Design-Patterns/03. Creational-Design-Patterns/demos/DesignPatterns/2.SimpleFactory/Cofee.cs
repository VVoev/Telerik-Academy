using System;
using System.Text;

namespace SimpleFactory
{
    public class Cofee
    {
        private int milk;
        private int cofee;
        private CofeeType type;

        public Cofee(CofeeType type, int milk, int cofee)
        {
            this.milk = milk;
            this.cofee = cofee;
            this.type = type;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(string.Format($@"CofeeType : {this.type}{Environment.NewLine} Milk: {this.milk}{Environment.NewLine} with cofee:{this.cofee}"));
            return sb.ToString();
        }
    }
}