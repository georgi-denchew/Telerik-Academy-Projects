using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryPasswords
{
    public class PasswordsFinder
    {
        private string pattern;

        public PasswordsFinder(string pattern)
        {
            this.pattern = pattern;
            this.PossiblePasswordsCount = 1;
        }

        public long PossiblePasswordsCount { get; private set; }

        public void CountPossiblePasswords()
        {
            int currentIndex = 0;
            this.CountPossiblePasswords(currentIndex);

            Console.WriteLine(PossiblePasswordsCount);
        }

        private void CountPossiblePasswords(int currentIndex)
        {
            if (currentIndex >= this.pattern.Length)
            {
                return;
            }

            if (this.pattern[currentIndex] == '*')
            {
                this.PossiblePasswordsCount *= 2;
            }

            this.CountPossiblePasswords(currentIndex + 1);
        }
    }
}
