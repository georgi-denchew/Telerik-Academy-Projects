namespace _01.TreeOfNNodes
{
    using System;
    using System.Collections.Generic;

    class Examples
    {
        static void Main(string[] args)
        {
            var nodes = Node<int>.CreateTree();

            // Task 01
            var root = Node<int>.FindRoot(nodes);
            Console.WriteLine("The root is: {0}", root.Value);

            // Task 02
            var leafs = Node<int>.FindAllLeafs(nodes);
            
            Console.Write("Leafs:");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }

            Console.WriteLine();
            
            // Task 03
            var middleNodes = Node<int>.FindMiddleNodes(nodes);

            Console.Write("Middle Nodes:");
            foreach (var node in middleNodes)
            {
                Console.Write("{0}, ", node.Value);
            }

            Console.WriteLine();

            // Task 04
            var longestPath = Node<int>.FindLongestPath(root);
            Console.WriteLine("Longest path: {0}", longestPath);
            
            // Task 05
            
            // Console.Write("Enter sum S to see all paths in the tree with that sum: ");
            // int nodesSum = int.Parse(Console.ReadLine());            
            int nodesSum = 9;
            var allPathsSum = Node<int>.AllPathsWithSum(nodes, nodesSum);

            Console.WriteLine("All paths with sum {0} are:", nodesSum);
            foreach (var path in allPathsSum)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    if (i != path.Count - 1)
                    {
                        Console.Write("{0}, ", path[i]);
                    }
                    else
                    {
                        Console.Write("{0}", path[i]);
                    }
                }

                Console.WriteLine();
            }

            // Task 06

            // Console.Write("Enter sum for subtrees to be displayed: ");
            // int subtreesSum = int.Parse(Console.ReadLine());
            int subtreesSum = 12;

            Queue<Node<int>> subtreeRoots = Node<int>.SubtreeRootNodesWithSum(nodes, subtreesSum);

            Console.WriteLine("All subtrees with the sum {0} are:", subtreesSum);

            while (subtreeRoots.Count > 0)
            {
                Node<int> currentRoot = subtreeRoots.Dequeue();
                PrintSubtree(currentRoot);
                Console.WriteLine();
            }
        }

        private static void PrintSubtree(Node<int> currentRoot)
        {
            Console.Write("{0} ", currentRoot.Value);

            foreach (var child in currentRoot.ChildNodes)
            {
                PrintSubtree(child);
            }
        }
    }
}
