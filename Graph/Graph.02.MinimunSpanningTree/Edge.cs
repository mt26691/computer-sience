﻿using System;

namespace Graph._02.MinimunSpanningTree
{
    public class Edge : IComparable
    {
        public int Source { get; set; }

        public int Destination { get; set; }

        public int Weight { get; set; }

        public int CompareTo(object obj)
        {
            return Weight - ((Edge)obj).Weight;
        }
    }
}
