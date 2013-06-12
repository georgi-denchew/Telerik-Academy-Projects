namespace _10.ShortestSequenceNToM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SequenceFinder
    {
        private Stack<int> temporarySequence;
        private List<int> shortestSequence;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceFinder"/> class.
        /// </summary>
        /// <param name="startNumber">The first number of requested sequence.</param>
        /// <param name="endNumber">The last number of the requested sequence.</param>
        public SequenceFinder(int startNumber, int endNumber)
        {
            if (startNumber > endNumber)
            {
                throw new ArgumentException("Starting number cannot be larger than ending number");
            }

            this.StartNumber = startNumber;
            this.EndNumber = endNumber;
            this.temporarySequence = new Stack<int>();
            this.shortestSequence = new List<int>();
        }

        public int StartNumber { get; private set; }

        public int EndNumber { get; private set; }

        /// <summary>
        /// Finds the shortest sequence from the starting number
        /// to the ending number which is valid for the operations.
        /// </summary>
        public void FindShortestSequences()
        {
            Node<int> rootNode = new Node<int>(this.StartNumber);
            this.temporarySequence.Push(this.StartNumber);
            
            this.FindShortestSequences(rootNode);
        }

        /// <summary>
        /// Prints the shortest sequence to the console.
        /// </summary>
        public void PrintSequence()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            if (this.shortestSequence.Count == 0 ||
                this.shortestSequence == null)
            {
                throw new InvalidOperationException(
                    "The short-sequences-list is empty or is null");
            }
            else
            {
                output.AppendFormat(
                    "The shortest sequence from {0} to {1} is:",
                    this.StartNumber,
                    this.EndNumber);
            }

            output.AppendLine();

            for (int i = 0; i < this.shortestSequence.Count; i++)
            {
                if (i != this.shortestSequence.Count - 1)
                {
                    output.AppendFormat("{0,2} -> ", this.shortestSequence[i]);
                }
                else
                {
                    output.AppendFormat("{0}", this.shortestSequence[i]);
                }
            }

            Console.WriteLine(output);
        }
        
        private void FindShortestSequences(Node<int> root)
        {
            this.AddNextValues(root);

            foreach (var childNode in root.ChildNodes)
            {
                if (childNode.Value > this.EndNumber)
                {
                    continue;
                }
                else
                {
                    this.temporarySequence.Push(childNode.Value);

                    if (childNode.Value == this.EndNumber)
                    {
                        this.SaveSequence();
                    }
                    else
                    {
                        this.FindShortestSequences(childNode);

                        this.ClearUnnecessaryItems(root);
                    }
                }
            }
        }

        private void ClearUnnecessaryItems(Node<int> root)
        {
            if (this.temporarySequence.Contains(root.Value))
            {
                while (this.temporarySequence.Peek() != root.Value)
                {
                    this.temporarySequence.Pop();
                }
            }
        }

        private void SaveSequence()
        {
            bool isLongerOrZero = this.shortestSequence.Count > this.temporarySequence.Count || 
                this.shortestSequence.Count == 0;

            if (isLongerOrZero)
            {
                this.shortestSequence = this.temporarySequence.Reverse().ToList();
            }            
        }

        private void AddNextValues(Node<int> root)
        {
            root.ChildNodes.Add(new Node<int>(root.Value + 1));
            root.ChildNodes.Add(new Node<int>(root.Value + 2));
            
            if (root.Value > 0)
            {
                root.ChildNodes.Add(new Node<int>(root.Value * 2));
            }
        }
    }
}
