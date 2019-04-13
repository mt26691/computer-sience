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
            var result = QuickSort(a, 0, a.Count - 1);

            foreach (var sortedResult in result)
            {
                Console.Write(sortedResult + " ");
            }

            Console.ReadLine();
        }

        public static List<int> QuickSort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                var pivot = Partition(list, low, high);
                QuickSort(list, low, pivot - 1);
                QuickSort(list, pivot + 1, high);
            }

            return list;
        }


        public static int Partition(List<int> list, int low, int high)
        {
            // pick last element
            var pivot = list[high];
            var i = (low - 1); // index of small element
            for (int j = low; j <= high - 1; j++)
            {
                if (list[j] <= pivot)
                {
                    // put to left
                    i++;
                    // swap list[i] and list[j]
                    var smallValue = list[j];

                    list[j] = list[i];
                    list[i] = smallValue;
                }
            }
            // move a[i+1] to a high
            var highValue = list[i + 1];
            list[i + 1] = list[high];
            list[high] = highValue;

            return i + 1;
        }
    }
}
