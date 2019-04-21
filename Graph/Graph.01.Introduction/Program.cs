using System;

namespace Graph._01.Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            Console.WriteLine("Hello World!");
            g.BFS(2);
            Console.ReadLine();
        }
    }
}
