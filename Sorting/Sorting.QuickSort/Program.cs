using System;
using System.Collections.Generic;
namespace Sorting.QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quick sort!");
            var a = new List<int> { 10, 80, 30, 90, 40, 50, 70 };
            QuickSortTest test = new QuickSortTest();
            var result = test.QuickSort(a, 0, a.Count - 1);

            foreach (var sortedResult in result)
            {
                Console.Write(sortedResult + " ");
            }

            Console.ReadLine();
        }
    }
}
