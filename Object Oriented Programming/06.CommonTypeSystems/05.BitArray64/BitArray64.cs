using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private readonly ulong number;

        public BitArray64(ulong number)
        {
            this.number = number;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = this.BitsConverter();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        private int[] BitsConverter()
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
            while (counter >= 0);

            return bits;
        }

        public bool Equals(BitArray64 other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.number == other.number;
        }

        public override bool Equals(object obj)
        {
            BitArray64 other = obj as BitArray64;

            if (other == null)
            {
                return false;
            }

            return this.Equals(other);
        }

        public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            return BitArray64.Equals(arr1, arr2);
        }

        public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {
            return !BitArray64.Equals(arr1, arr2);
        }

        private bool IsValidIndex(int index)
        {
            if (index >= 0 && index <= 63)
            {
                return true;
            }
            return false;
        }

        public int this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                int[] bits = this.BitsConverter();
                return bits[index];
            }
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }
    }
}
