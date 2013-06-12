namespace _01.TreeOfNNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// The class contains a list of ChildNodes of the same class.
        /// </summary>
        /// <param name="value">The value of the given node,
        /// considering the data-type used.</param>
        public Node(T value)
            : this()
        {
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/>class.
        /// The class contains a list of ChildNodes of the same class.
        /// </summary>
        public Node()
        {
            this.ChildNodes = new List<Node<T>>();
        }

        public T Value { get; set; }

        public List<Node<T>> ChildNodes { get; set; }

        public bool HasParent { get; set; }

        /// <summary>
        /// Calculates all the paths in a given tree,
        /// whose elements have a total of a given sum.
        /// </summary>
        /// <param name="tree">The tree whose paths should be calculated</param>
        /// <param name="sum">The sum demanded for the paths</param>
        /// <returns>A queue, containing lists with all paths.</returns>
        public static Queue<List<int>> AllPathsWithSum(Node<int>[] tree, int sum)
        {
            Node<int> root = FindRoot(tree);
            Queue<List<int>> allPaths = new Queue<List<int>>();
            Stack<int> pathToAppend = new Stack<int>();

            int currentSum = 0;

            FindPathsWithSum(root, allPaths, pathToAppend, sum, currentSum);

            return allPaths;
        }

        /// <summary>
        /// Creates a a tree of <see cref="Node"/> elements.
        /// </summary>
        /// <returns>An array of <see cref="Node"/> elements.</returns>
        public static Node<int>[] CreateTree()
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[n];

            var isChild = new bool[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeParse = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeParse[0]);
                int childId = int.Parse(edgeParse[1]);

                nodes[parentId].ChildNodes.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            return nodes;
        }

        /// <summary>
        /// Finds the root for given tree of <see cref="Node"/> elements.
        /// </summary>
        /// <param name="tree">An array which should be 
        /// considered as the initial tree.</param>
        /// <returns>A single <see cref="Node"/> element.</returns>
        public static Node<int> FindRoot(Node<int>[] tree)
        {
            var hasParent = new bool[tree.Length];

            foreach (var node in tree)
            {
                foreach (var child in node.ChildNodes)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return tree[i];
                }
            }

            throw new ArgumentException("nodes", "The tree has no root");
        }

        /// <summary>
        /// Finds all subtrees of given tree, whose elements 
        /// respond to given a given total sum.
        /// </summary>
        /// <param name="tree">>An array which should be 
        /// considered as the initial tree.</param>
        /// <param name="sum">The total value of each
        /// subtree to be returned.</param>
        /// <returns>A queue of <see cref="Node"/> elements,
        /// roots of all the subtrees with the corresponding sum</returns>
        public static Queue<Node<int>> SubtreeRootNodesWithSum(Node<int>[] tree, int sum)
        {
            Queue<Node<int>> subtreeRoots = new Queue<Node<int>>();
            Node<int> root = Node<int>.FindRoot(tree);
            Stack<Node<int>> allNodes = new Stack<Node<int>>();

            allNodes.Push(root);

            while (allNodes.Count > 0)
            {
                Node<int> currentNode = allNodes.Pop();

                int currentSum = Node<int>.CalculateRootAndChildrenSum(currentNode);

                if (currentSum == sum)
                {
                    subtreeRoots.Enqueue(currentNode);
                }

                foreach (var childNode in currentNode.ChildNodes)
                {
                    if (childNode.ChildNodes.Count > 0)
                    {
                        allNodes.Push(childNode);
                    }
                }
            }

            return subtreeRoots;
        }        

        /// <summary>
        /// Finds the longest path in a tree of nodes.
        /// </summary>
        /// <param name="root">An instance of the <see cref="Node"/> class
        /// considered as a root for a tree of that class.</param>
        /// <returns>An integer value counting the number of steps
        /// for the longest path</returns>
        public static int FindLongestPath(Node<int> root)
        {
            if (root.ChildNodes.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.ChildNodes)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        /// <summary>
        /// Finds all nodes in a tree, who have both "parents" and "children".
        /// </summary>
        /// <param name="tree">An array of Nodes, considered as a tree
        /// of the class <see cref="Node"/></param>
        /// <returns>A list of <see cref="Node"/> elements.</returns>
        public static List<Node<int>> FindMiddleNodes(Node<int>[] tree)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in tree)
            {
                if (node.HasParent && node.ChildNodes.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        /// <summary>
        /// Finds all elements in a given tree
        /// who don't have any children.
        /// </summary>
        /// <param name="tree">An array of Nodes, considered as a tree
        /// of the class <see cref="Node"/></param>
        /// <returns></returns>
        public static List<Node<int>> FindAllLeafs(Node<int>[] tree)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in tree)
            {
                if (node.ChildNodes.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static int CalculateRootAndChildrenSum(Node<int> root)
        {
            int sum = 0;

            Stack<Node<int>> allNodes = new Stack<Node<int>>();

            allNodes.Push(root);

            while (allNodes.Count > 0)
            {
                Node<int> currentNode = allNodes.Pop();

                sum += currentNode.Value;

                foreach (var childNode in currentNode.ChildNodes)
                {
                    allNodes.Push(childNode);
                }
            }

            return sum;
        }

        private static void FindPathsWithSum(
            Node<int> currentNode, Queue<List<int>> allPaths, Stack<int> pathToAppend, int sum, int currentSum)
        {
            if (currentSum + currentNode.Value < sum)
            {
                currentSum += currentNode.Value;
                pathToAppend.Push(currentNode.Value);

                foreach (var childNode in currentNode.ChildNodes)
                {
                    FindPathsWithSum(childNode, allPaths, pathToAppend, sum, currentSum);
                }

                pathToAppend.Pop();
            }
            else if (currentSum + currentNode.Value == sum)
            {
                pathToAppend.Push(currentNode.Value);
                allPaths.Enqueue(pathToAppend.Reverse().ToList());
                pathToAppend.Pop();
            }
        }
    }
}
