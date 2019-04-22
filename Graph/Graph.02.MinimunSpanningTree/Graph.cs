using System;
using System.Collections.Generic;

namespace Graph._02.MinimunSpanningTree
{
    public class Graph
    {
        public int NumberOfVertices { get; set; }

        public int NumberOfEdge { get; set; }

        /// <summary>
        /// collection of all edges
        /// </summary>
        public List<Edge> Edges { get; set; }

        public Graph(int v, int e)
        {
            NumberOfEdge = e;
            NumberOfVertices = v;
            Edges = new List<Edge>();
            for (int i = 0; i < e; i++)
            {
                Edges.Add(new Edge());
            }
        }

        public int FindSubset(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
            {
                subsets[i].Parent = FindSubset(subsets, subsets[i].Parent);
            }
            return subsets[i].Parent;
        }

        public void Union(Subset[] subsets, int x, int y)
        {
            int xRoot = FindSubset(subsets, x);
            int yRoot = FindSubset(subsets, y);

            if (subsets[xRoot].Rank < subsets[yRoot].Rank)
            {
                subsets[xRoot].Parent = yRoot;
            }
            else if (subsets[xRoot].Rank > subsets[yRoot].Rank)
            {
                subsets[yRoot].Parent = xRoot;
            }
            else
            {
                subsets[yRoot].Parent = xRoot;
                subsets[yRoot].Rank++;
            }
        }

        public void MinimumSpanningTree()
        {
            Edge[] result = new Edge[NumberOfVertices];
            int e = 0;  // An index variable, used for result[] 
            for (int i = 0; i < NumberOfVertices; ++i)
            {
                result[i] = new Edge();
            }
            Edges.Sort();

            Subset[] subsets = new Subset[NumberOfVertices];
            for (int i = 0; i < NumberOfVertices; i++)
            {
                // initialize subset with one parent only
                var subset = new Subset();
                subset.Parent = i;
                subset.Rank = 0;
                subsets[i] = subset;
            }

            int index = 0;

            while (e < NumberOfVertices - 1)
            {
                Edge nextEdge = new Edge();
                nextEdge = Edges[index++];

                int x = FindSubset(subsets, nextEdge.Source);
                int y = FindSubset(subsets, nextEdge.Destination);

                // if this one does not cause cycle
                if (x != y)
                {
                    result[e++] = nextEdge;
                    Union(subsets, x, y);
                }
            }

            Console.WriteLine("Following are the edges in " +
                                     "the constructed MST");
            for (int i = 0; i < e; ++i)
            {
                Console.WriteLine(result[i].Source + " -- " +
                       result[i].Destination + " == " + result[i].Weight);
            }
        }
    }
}
