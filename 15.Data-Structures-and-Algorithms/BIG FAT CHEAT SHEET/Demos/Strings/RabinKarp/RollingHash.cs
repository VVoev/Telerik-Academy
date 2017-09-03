using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarp
{
    public class RollingHash
    {
        private long baseSystem;
        private long mod;
        private long leftMostPower;

        private long hash;

        public RollingHash(int baseSystem, int mod, string text, int endIndex)
        {
            this.hash = 0;
            this.baseSystem = baseSystem;
            this.mod = mod;

            this.leftMostPower = 1;
            for (int i = 0; i < endIndex; i++)
            {
                this.leftMostPower = this.leftMostPower * this.baseSystem;
                this.AddRight(text[i]);
            }

            this.leftMostPower /= this.baseSystem;
        }

        public RollingHash(int basesystem, int mod, string text)
            : this(basesystem, mod, text, text.Length)
        {
        }

        public long Hash => this.hash;

        public void Roll(char left, char right)
        {
            this.RemoveLeft(left);
            this.AddRight(right);
        }

        public void AddRight(char symbol)
        {
            this.hash = ((this.hash * this.baseSystem) + symbol) % this.mod;
        }

        public void RemoveLeft(char symbol)
        {
            this.hash = (this.mod + (this.hash - (this.leftMostPower * symbol % this.mod))) % this.mod;
        }

        public override bool Equals(object obj)
        {
            var other = obj as RollingHash;
            return this.hash == other.hash;
        }

        public override int GetHashCode()
        {
            return this.hash.GetHashCode();
        }
    }
}
