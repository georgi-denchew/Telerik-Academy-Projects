using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_2_Messages_in_a_Bottle
{
    class State
    {
        public string Result { get; set; }
        public string Left { get; set; }
    }

    class CipherElement
    {
        public char Letter { get; set; }
        public string Digits { get; set; }

    }

    class Program
    {

        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string cipherToDecode = Console.ReadLine();

            List<CipherElement> cipcher = BuildChiper(cipherToDecode);
            List<string> results = new List<string>();
            List<State> states = new List<State>();
            int index = 0;
            states.Add(new State() { Result = "", Left = code });
            while (index < states.Count)
            {
                State currentState = states[index];
                index++;
                foreach (var cipherElement in cipcher)
                {
                    if (currentState.Left.StartsWith(cipherElement.Digits))
                    {
                        State newState = new State();
                        newState.Result = currentState.Result + cipherElement.Letter;
                        newState.Left = currentState.Left.Remove(0, cipherElement.Digits.Length);
                        if (newState.Left == "")
                        {
                            results.Add(newState.Result);
                        }
                        else
                        {
                            states.Add(newState);
                        }
                    }
                }

            }
            Console.WriteLine(results.Count);
            results.Sort();
            foreach (var answer in results)
            {
                Console.WriteLine(answer);
            }
        }

        private static List<CipherElement> BuildChiper(string cipherToDecode)
        {
            List<CipherElement> elements = new List<CipherElement>();
            char? letter = null; //invalid value
            StringBuilder digits = new StringBuilder();
            //cipherToDecode += "Z";
            foreach (var ch in cipherToDecode)
            {
                if (char.IsLetter(ch))
                {
                    if (letter != null)
                    {
                        CipherElement newElement = new CipherElement();
                        newElement.Letter = letter.Value;
                        newElement.Digits = digits.ToString();
                        elements.Add(newElement);
                        digits.Clear();
                    }

                    letter = ch;
                }
                else
                {
                    //digit ---> append to code
                    digits.Append(ch);
                }
            }
            CipherElement lasElement = new CipherElement();
            lasElement.Letter = letter.Value;
            lasElement.Digits = digits.ToString();
            elements.Add(lasElement);

            return elements;
        }
    }

}