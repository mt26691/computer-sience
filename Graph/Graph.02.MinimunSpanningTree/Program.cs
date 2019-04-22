using System;

namespace Graph._02.MinimunSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int V = 4;  // Number of vertices in graph 
            int E = 5;  // Number of edges in graph 
            Graph graph = new Graph(V, E);

            graph.Edges[0].Source = 0;
            graph.Edges[0].Destination = 1;
            graph.Edges[0].Weight = 10;

            // add edge 0-2 
            graph.Edges[1].Source = 0;
            graph.Edges[1].Destination = 2;
            graph.Edges[1].Weight = 6;

            // add edge 0-3 
            graph.Edges[2].Source = 0;
            graph.Edges[2].Destination = 3;
            graph.Edges[2].Weight = 5;

            // add edge 1-3 
            graph.Edges[3].Source = 1;
            graph.Edges[3].Destination = 3;
            graph.Edges[3].Weight = 15;

            // add edge 2-3 
            graph.Edges[4].Source = 2;
            graph.Edges[4].Destination = 3;
            graph.Edges[4].Weight = 4;

            graph.MinimumSpanningTree();
            Console.ReadLine();
        }
    }
}
