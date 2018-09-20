using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new BimStack<int>();
            stack.Push(7);
            stack.Push(8);
            Console.WriteLine(stack.Pop());
            Console.ReadLine();
        }
    }

    public class BimStack<T>
    {
        private List<T> stack = new List<T>();

        public void Push(T t)
        {
            stack.Add(t);
        }

        public T Pop()
        {
            var lastItem = stack[stack.Count - 1];
            stack.Remove(lastItem);
            return lastItem;
        }

        public T Peek()
        {
            var lastItem = stack[stack.Count - 1];
            return lastItem;
        }
    }
}
