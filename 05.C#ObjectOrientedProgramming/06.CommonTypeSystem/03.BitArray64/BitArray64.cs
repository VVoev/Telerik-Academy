namespace _03.BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        // Field.
        private ulong number;

        // Constructor.
        public BitArray64(ulong number)
        {
            this.number = number;
        }

        public int this[int positionBit]
        {
            get
            {
                if (positionBit < 0 || positionBit >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                return ((int)(this.number >> positionBit) & 1);
            }
            set
            {
                if (positionBit < 0 || positionBit >= 64)
                {
                    throw new IndexOutOfRangeException("Invalid position.");
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Invalid bit value.");
                }

                if (((int)(this.number >> positionBit) & 1) != value)
                {
                    this.number ^= (1ul << positionBit);
                }
            }
        }
        public IEnumerator<int> GetEnumerator()
        {
            ulong value = this.number;

            int[] bits = new int[64];
            int counter = 63;

            while (value != 0)
            {
                bits[counter] = (int)value % 2;
                value /= 2;
                counter--;
            }

            do
            {
                bits[counter] = 0;
                counter--;
            }
            while (counter != 0);

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }

        public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            if (arr1.Equals(arr2))
            {
                return true;
            }
            return false; 
        }

        public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {
            if (!arr1.Equals(arr2))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int bitPosition = 0; bitPosition < 64; bitPosition++)
            {
                result.Insert(0, ((this.number >> bitPosition) & 1));
            }

            return result.ToString();
        }
    }
}
