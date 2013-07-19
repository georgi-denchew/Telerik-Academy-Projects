namespace _03.CableTVCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int housesCount = 10;

            List<Connection> allConnections = new List<Connection>();
            allConnections.Add(new Connection(1, 3, 3));
            allConnections.Add(new Connection(1, 2, 9));
            allConnections.Add(new Connection(1, 4, 14));
            allConnections.Add(new Connection(2, 4, 5));
            allConnections.Add(new Connection(3, 4, 12));
            allConnections.Add(new Connection(3, 5, 18));
            allConnections.Add(new Connection(4, 5, 8));
            allConnections.Add(new Connection(5, 6, 7));
            allConnections.Add(new Connection(6, 7, 6));
            allConnections.Add(new Connection(6, 8, 14));
            allConnections.Add(new Connection(7, 8, 17));
            allConnections.Add(new Connection(7, 9, 22));
            allConnections.Add(new Connection(8, 9, 31));
            allConnections.Add(new Connection(8, 1, 4));
            allConnections.Add(new Connection(7, 2, 9));
            allConnections.Add(new Connection(9, 10, 6));
            allConnections.Add(new Connection(8, 10, 19));

            allConnections.Sort();

            // this array is to be filled with the number of the tree
            // that the given house belongs to - in the end all the 
            // houses should belong to the tree with index 1
            int[] houses = new int[housesCount + 1];

            int currentTree = 1;

            List<Connection> cableMap = new List<Connection>();

            FindMinimumSpanningForest(allConnections, houses, cableMap, currentTree);

            int totalCost = 0;

            foreach (var connection in cableMap)
            {
                totalCost += connection.Cost;
            }

            Console.WriteLine("Total cost of wiring all houses: {0}", totalCost);
        }

        private static void FindMinimumSpanningForest(List<Connection> connections, int[] houses, List<Connection> cableMap, int currentTree)
        {
            foreach (var connection in connections)
            {
                if (houses[connection.StartHouse] == 0)
                {
                    if (houses[connection.EndHouse] == 0)
                    {
                        houses[connection.StartHouse] = currentTree;
                        houses[connection.EndHouse] = currentTree;
                        currentTree++;
                    }
                    else
                    {
                        houses[connection.StartHouse] = houses[connection.EndHouse];
                    }

                    cableMap.Add(connection);
                }
                else
                {
                    if (houses[connection.EndHouse] == 0)
                    {
                        houses[connection.EndHouse] = houses[connection.StartHouse];
                        cableMap.Add(connection);
                    }
                    else if (houses[connection.StartHouse] != houses[connection.EndHouse])
                    {
                        int currentNumber = houses[connection.EndHouse];

                        for (int i = 0; i < houses.Length; i++)
                        {
                            if (houses[i] == currentNumber)
                            {
                                houses[i] = houses[connection.StartHouse];
                            }
                        }

                        cableMap.Add(connection);
                    }
                }
            }
        }
    }
}
