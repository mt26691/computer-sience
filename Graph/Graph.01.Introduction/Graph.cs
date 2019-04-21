using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph._01.Introduction
{
    public class Graph
    {

        private int NumberOfVertices { get; set; }

        private LinkedList<int>[] AdjacentList;

        public Graph(int v)
        {
            NumberOfVertices = v;
            AdjacentList = new LinkedList<int>[v];
            for (int i = 0; i < v; i++)
            {
                AdjacentList[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            AdjacentList[v].AddLast(w);
            AdjacentList[w].AddLast(v);
        }

        public void BFS(int s)
        {
            bool[] visisted = new bool[NumberOfVertices];

            Queue<int> queue = new Queue<int>();
            visisted[s] = true;
            queue.Enqueue(s);

            while(queue.Count != 0)
            {
                s = queue.Dequeue();
                Console.WriteLine(s);
                var iterator = AdjacentList[s].GetEnumerator();
                var list = AdjacentList[s].ToList();
                while (iterator.MoveNext())
                {
                    var n = iterator.Current;
                    if(!visisted[n])
                    {
                        visisted[n] = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }

    }
}
