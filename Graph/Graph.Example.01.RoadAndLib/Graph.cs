using System;
using System.Collections.Generic;

namespace Graph.Example._01.RoadAndLib
{
    public class Graph
    {
        public int NumberOfVertices { get; set; }


        /// <summary>
        /// collection of all edges
        /// </summary>
        public List<Edge> Edges { get; set; }

        public int LibCost { get; set; }
        public void AddEdge(int source, int destination, int weight)
        {
            Edges.Add(new Edge() { Source = source, Destination = destination, Weight = weight });
        }

        public Graph(int verices, int libCost = 0)
        {
            NumberOfVertices = verices;
            Edges = new List<Edge>();

            for (int i = 1; i <= verices; i++)
            {
                AddEdge(i, 0, libCost);
            }
            LibCost = libCost;
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
            long totalCost = 0;
            Edge[] result = new Edge[NumberOfVertices];
            int e = 0;  // An index variable, used for result[] 
            for (int i = 0; i < NumberOfVertices; ++i)
            {
                result[i] = new Edge();
            }
            Edges.Sort();

            Subset[] subsets = new Subset[NumberOfVertices + 1];
            for (int i = 0; i < NumberOfVertices + 1; i++)
            {
                // initialize subset with one parent only
                var subset = new Subset();
                subset.Parent = i;
                subset.Rank = 0;
                subsets[i] = subset;
            }

            int index = 0;

            while (e < NumberOfVertices)
            {
                Edge nextEdge = new Edge();
                nextEdge = Edges[index++];

                int x = FindSubset(subsets, nextEdge.Source);
                int y = FindSubset(subsets, nextEdge.Destination);

                // if this one does not cause cycle
                if (x != y)
                {
                    if (x != 0 && y != 0)
                    {
                        // if they are not point to lib, one lib must be built
                        result[e++] = new Edge() { Source = x, Destination = 0, Weight = LibCost };
                        totalCost += LibCost;
                        // assign x to subset 0 (lib subset)
                        Union(subsets, 0, x);
                        // calculate the cost from x to y
                        if (nextEdge.Weight < LibCost)
                        {
                            result[e++] = nextEdge;
                            totalCost += nextEdge.Weight;
                        }
                    }
                    else if (x == 0)
                    {
                        if (nextEdge.Weight < LibCost)
                        {
                            result[e++] = nextEdge;
                            totalCost += LibCost;
                        }
                        else
                        {
                            result[e++] = new Edge() { Source = y, Destination = 0, Weight = LibCost };
                            totalCost += nextEdge.Weight;
                        }
                        Union(subsets, x, y);
                    }
                    else if (y == 0)
                    {
                        if (nextEdge.Weight < LibCost)
                        {
                            result[e++] = nextEdge;
                            totalCost += nextEdge.Weight;
                        }
                        else
                        {
                            result[e++] = new Edge() { Source = x, Destination = 0, Weight = LibCost };
                            totalCost += LibCost;
                        }
                        Union(subsets, y, x);
                    }
                }
            }

            Console.WriteLine("Following are the edges in " +
                                     "the constructed MST");
            for (int i = 0; i < e; ++i)
            {
                Console.WriteLine(result[i].Source + " -- " +
                       result[i].Destination + " == " + result[i].Weight);
            }
            Console.WriteLine("Total cost = " + totalCost);
        }
    }
}
