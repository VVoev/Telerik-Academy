using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarp
{
    class Hash
    {
        private SingleRollingHash hash1;
        private SingleRollingHash hash2;

        public Hash(string str)
            :this(str, str.Length)
        {
        }

        public Hash(string str, int length)
        {
            this.hash1 = new SingleRollingHash(211, 1000000007, str, length);
            this.hash2 = new SingleRollingHash(359, 1000000009, str, length);
        }

        public void Roll(char right, char left)
        {
            this.hash1.Roll(right, left);
            this.hash2.Roll(right, left);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Hash;
            return this.hash1.Equals(other.hash1) && this.hash2.Equals(other.hash2);
        }
    }
}
