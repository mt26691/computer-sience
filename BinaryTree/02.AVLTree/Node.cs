using System;
using System.Collections.Generic;
using System.Text;

namespace _02.AVLTree
{
    public class Node
    {
        public Node Parent { get; set; }

        public Node Right { get; set; }

        public string Key { get; set; }
        public int Value { get; set; }

        public Node Left { get; set; }

        public int Balance;
    }
}
