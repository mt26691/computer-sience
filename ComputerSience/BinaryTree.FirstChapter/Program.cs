using System;
using System.Diagnostics;

namespace BinaryTree.FirstChapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            BinaryTree bst = new BinaryTree();
            int SIZE = 100;
            int[] a = new int[SIZE];

            Console.WriteLine("Generating random array with {0} values...", SIZE);

            Random random = new Random();

            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < 100; i++)
            {
                a[i] = random.Next(1000);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Filling the tree with {0} nodes...", SIZE);

            watch = Stopwatch.StartNew();

            for (int i = 0; i < SIZE; i++)
            {
                root = bst.Insert(root, a[i]);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            Console.WriteLine("Traversing all {0} nodes in tree...", SIZE);

            watch = Stopwatch.StartNew();

            bst.Travese(root);

            watch.Stop();

            Console.WriteLine("Done. Took {0} seconds", watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine();
            var data = bst.LookUp(root, 100);

            if (data != null)
            {
                Console.WriteLine("Data is found, value = " + data.Value);
            }
            else
            {
                Console.WriteLine("Data is not found");
            }

            Console.WriteLine("Tree Size " + bst.Size(root));
            Console.WriteLine("Tree Max Depth " + bst.MaxDepth(root));
            Console.WriteLine("Tree Min Value " + bst.MinValue(root).Value);
            Console.WriteLine("Tree Max Value " + bst.MaxValue(root).Value);
            Console.WriteLine("Print Tree ");
            bst.PrintInorderTree(root);
            Console.ReadKey();
        }
    }

    public class Node
    {
        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public int Value { get; set; }


        public Node(int value, Node leftNode, Node rightNode)
        {
            Value = value;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public Node(int value)
        {
            Value = value;
        }
    }

    /*
     *Binary Tree 
     * 
     * */
    public class BinaryTree
    {
        public Node Insert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else if (value < root.Value)
            {
                root.LeftNode = Insert(root.LeftNode, value);
            }
            else
            {
                root.RightNode = Insert(root.RightNode, value);
            }

            return root;
        }

        public void Travese(Node root)
        {
            if (root == null)
            {
                return;
            }

            Travese(root.LeftNode);
            Travese(root.RightNode);
        }

        public Node LookUp(Node node, int targetValue)
        {
            if (node == null)
            {
                return node;
            }
            else if (targetValue == node.Value)
            {
                return node;
            }
            else if (targetValue > node.Value)
            {
                return LookUp(node.RightNode, targetValue);
            }
            else
            {
                return LookUp(node.LeftNode, targetValue);
            }
        }

        public int Size(Node rootNode)
        {
            if (rootNode == null)
            {
                return 0;
            }
            return Size(rootNode.LeftNode) + 1 + Size(rootNode.RightNode);
        }

        public int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            var leftDepth = MaxDepth(root.LeftNode);
            var rightDepth = MaxDepth(root.RightNode);

            if (leftDepth > rightDepth)
            {
                return MaxDepth(root.LeftNode) + 1;
            }
            else
            {
                return MaxDepth(root.RightNode) + 1;
            }

        }

        public Node MinValue(Node root)
        {
            if (root.LeftNode != null && root != null)
            {
                return MinValue(root.LeftNode);
            }
            return root;
        }

        public Node MaxValue(Node root)
        {
            if (root.RightNode != null && root != null)
            {
                return MaxValue(root.RightNode);
            }
            return root;
        }

        public void PrintInorderTree(Node root)
        {
            if (root == null)
            {
                return;
            }
            PrintInorderTree(root.LeftNode);
            Console.Write(" " + root.Value);
            PrintInorderTree(root.RightNode);
        }

        public void PrintPostOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            PrintPostOrder(root.LeftNode);
            PrintPostOrder(root.RightNode);
            Console.Write(" " + root.Value);
        }

        public void PrintPreOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write(" " + root.Value);
            PrintPreOrder(root.LeftNode);
            PrintPreOrder(root.RightNode);
        }

        public bool HasPathSum(Node root, int sum)
        {
            if (root == null)
            {
                return (sum == 0);
            }
            int subSum = sum - root.Value;
            if (subSum == 0 && root.LeftNode == null && root.RightNode == null)
            {
                return true;
            }

            var leftNodeResult = HasPathSum(root.LeftNode, subSum);
            var rightNodeResult = HasPathSum(root.RightNode, subSum);

            return leftNodeResult || rightNodeResult;

        }

        public void Mirror(Node root)
        {
            if (root == null)
            {
                return;
            }

            Node currentNode;

            Mirror(root.LeftNode);
            Mirror(root.RightNode);

            currentNode = root.LeftNode;
            root.LeftNode = root.RightNode;
            root.RightNode = currentNode;
        }
    }
}
