using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.FirstChapter
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Node<T>
    {
        public Node<T> LeftNode { get; set; }

        public Node<T> RightNode { get; set; }

        private T Value { get; set; }

        public T GetValue()
        {
            return Value;
        }

        public Node(T value, Node<T> leftNode, Node<T> rightNode)
        {
            Value = value;
            LeftNode = leftNode;
            RightNode = rightNode;
        }
    }
}
