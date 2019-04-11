using System;

namespace _01.BinaryTreeIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tree = new BinaryTree();
            tree.Insert(50);
            tree.Insert(20);
            tree.Insert(30);
            Console.WriteLine("Number of nodes in the tree = {0}\n", tree.Count());

            Console.WriteLine("Original: " + tree.DrawTree());

            Console.ReadLine();
        }
    }
}
