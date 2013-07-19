using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FriendsInNeed
{
    class Program
    {

        static Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
        static Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

        static void Main(string[] args)
        {
            string[] NMH = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] hospitals = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int buildingsCount = int.Parse(NMH[0]);
            int connectionsCount = int.Parse(NMH[1]);


            for (int i = 1; i <= buildingsCount; i++)
			{
                allNodes.Add(i, new Node(i));
			}

            for (int i = 0; i < hospitals.Length; i++)
            {
                int hospitalID = int.Parse(hospitals[i]);

                allNodes[hospitalID].IsHospital = true;
            }

            for (int i = 1; i <= connectionsCount; i++)
            {
                string[] connection = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int currentNodeID = int.Parse(connection[0]);
                int destinationNodeID = int.Parse(connection[1]);
                int distance = int.Parse(connection[2]);

                Node currentNode = allNodes[currentNodeID];

                if (!graph.ContainsKey(currentNode))
                {
                    graph.Add(currentNode, new List<Connection>());
                }

                Node destinationNode = allNodes[destinationNodeID];

                if (!graph.ContainsKey(destinationNode))
                {
                    graph.Add(destinationNode, new List<Connection>());
                }

                graph[currentNode].Add(new Connection(distance, destinationNode));
                graph[destinationNode].Add(new Connection(distance, currentNode));
            }

            long shortestDistance = long.MaxValue;

            foreach (var building in graph)
            {
                if (building.Key.IsHospital)
                {
                    long currentDistance = CalculateDijkstraDistance(building.Key);
                    shortestDistance = Math.Min(shortestDistance, currentDistance);
                }
            }

            Console.WriteLine(shortestDistance);
        }

        private static long CalculateDijkstraDistance(Node hospital)
        {

            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in allNodes)
            {
                if (node.Value != hospital)
                {
                    node.Value.DijkstraDistance = long.MaxValue;
                    queue.Enqueue(node.Value);
                }
            }

            hospital.DijkstraDistance = 0;
            queue.Enqueue(hospital);

            while (queue.Count > 0)
            {
                Node currentBuilding = queue.Peek();

                if (currentBuilding.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                List<Connection> buildingConnections = graph[currentBuilding];

                foreach (var connection in buildingConnections)
                {
                    if (connection.ToNode.DijkstraDistance > connection.Distance + currentBuilding.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = connection.Distance + currentBuilding.DijkstraDistance;
                        queue.Enqueue(connection.ToNode);
                    }
                }

                queue.Dequeue();
            }

            long totalDistance = 0;

            foreach (var building in allNodes)
            {
                if (!building.Value.IsHospital)
                {
                    totalDistance += building.Value.DijkstraDistance;
                }
            }

            return totalDistance;
        }
    }

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.ID = id;
        }

        public int ID { get; set; }

        public bool IsHospital { get; set; }

        public long DijkstraDistance { get; set; }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }

        #endregion
    }

    public class Connection
    {
        public Connection(int distance, Node toNode)
        {
            this.Distance = distance;
            this.ToNode = toNode;
        }

        public int Distance { get; set; }

        public Node ToNode { get; set; }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            int minChild;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = rootIndex * 2 + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }
                else if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            T[] copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }
}
