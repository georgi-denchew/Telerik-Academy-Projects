using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericList
{
    public class GenericList<Players>
        where Players : IComparable<Players>, new()
    {
        private Players[] players;
        private int count = 0;
        private int capacity;

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.players = new Players[this.capacity];   
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public Players Min() //TASK 07
        {
            Players minPlayer = new Players();

            for (int i = 0; i < this.players.Length; i++)
            {
                if (i == 0)
                {
                    minPlayer = this.players[i];
                }

                else if (minPlayer.CompareTo(this.players[i]) >= 0)
                {
                    minPlayer = this.players[i];
                }
            }
            return minPlayer;
        }

        public Players Max() //TASK 07
        {
            Players maxPlayer = new Players();

            for (int i = 0; i < this.players.Length; i++)
            {
                if (i == 0)
                {
                    maxPlayer = this.players[i];
                }

                else if (maxPlayer.CompareTo(this.players[i]) <= 0)
                {
                    maxPlayer = this.players[i];
                }
            }
            return maxPlayer;
        }

        public void Add(Players player) //TASK 05
        {
            CheckIfFull(); //TASK 06
            this.players[count] = player;
            count++;

        }

        private void CheckIfFull() //TASK 06
        {
            if (count >= players.Length) 
            {
                Players[] tempPlayers = new Players[players.Length * 2];

                for (int i = 0; i < players.Length; i++)
                {
                    tempPlayers[i] = players[i];
                }
                this.players = tempPlayers;
            }
        }

        public void Remove(int index) //TASK 05
        {
            
            int newCapacity = players.Length;
            int tempCount = 0;

            Players[] tempPlayers = new Players[players.Length - 1];

            for (int i = 0; i < players.Length; i++)
            {
                if (i != index)
                {
                    tempPlayers[tempCount] = players[i];
                    tempCount++;
                }
            }

            players = tempPlayers;
            this.count = this.count - 1;
        }

        public void Clear() //TASK 05
        {
            this.players = default(Players[]);
            this.Count = 0;
        }

        public void Insert(int index, Players playersToInsert)
        {
            CheckIfFull(); //TASK 06
            
            Players[] tempPlayers = new Players[this.players.Length];
            bool isPlaced = false;
            for (int i = 0; i < this.players.Length; i++)
            {
                if (i != index && !isPlaced)
                {
                    tempPlayers[i] = this.players[i];
                }

                else if (i == index)
                {
                    tempPlayers[i] = playersToInsert;
                    isPlaced = true;
                }

                else if (isPlaced)
                {
                    tempPlayers[i] = this.players[i - 1];
                }
            }
            this.players = tempPlayers;
            count++;
        }

        public int FindIndexOf(Players player) //TASK 05
        {
            for (int i = 0; i < this.players.Length; i++)
            {
                if (this.players[i].Equals(player))
                {
                    return i;
                }
            }
            Console.Write("Element with given value not found");
            return -1;
        }

        public Players this[int index] //TASK 05
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid array index"));
                }
                
                Players result = players[index];
                return result;
            }

            set
            {
                players[index] = value;
            }
        }

        public override string ToString() //TASK 05
        {
            bool lastValue = false;
            StringBuilder output = new StringBuilder();
            if (this.players != null)
            {
                for (int i = 0; i < this.players.Length; i++)
                {
                    if (this.players[i].Equals(default(Players)))
                    {
                        lastValue = true;                                             //Checking to see if all the remaining array elements
                        for (int j = i; j < this.players.Length; j++)                //have the default value and if so, the program doesn't
                        {                                                            //display them.
                            if (!this.players[j].Equals(default(Players)))
                            {
                                lastValue = false;
                            }
                        }
                    }
                    if (lastValue == false)
                    {
                        output.Append(this.players[i].ToString());
                        output.Append(" ");
                    }
                }
                return output.ToString().Trim();
            }
            return "";
        }
    }
}