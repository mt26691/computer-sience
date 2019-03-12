using System;

namespace _01.BinaryTreeIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tree = new BinaryTree();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(7);
            Console.WriteLine("Number of nodes in the tree = {0}\n", tree.Count());

            Console.WriteLine("Original: " + tree.DrawTree());

            Console.ReadLine();
        }
    }
}
