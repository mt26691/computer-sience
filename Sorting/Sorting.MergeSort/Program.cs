using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merge sort!");
            var a = new List<int> { 2000, 8, 1, 4, 14, 7, 16, 10, 9, 3 };
            var result = MergeSort(a);

            foreach(var sortedResult in result)
            {
                Console.Write(sortedResult + " ");
            }

            Console.ReadLine();
        }

        public static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            var middle = list.Count / 2;

            var leftList = list.GetRange(0, middle);
            var rightList = list.Skip(middle).ToList();

            var left = MergeSort(leftList);
            var right = MergeSort(rightList);
            return Merge(left, right);
        }


        public static List<int> Merge(List<int> leftList, List<int> rightList)
        {
            List<int> result = new List<int>();
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < leftList.Count && rightIndex < rightList.Count)
            {
                if (leftList[leftIndex] < rightList[rightIndex])
                {
                    result.Add(leftList[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(rightList[rightIndex]);
                    rightIndex++;
                }
            }
            if (leftIndex < leftList.Count)
            {
                result.AddRange(leftList.Skip(leftIndex));
            }
            else if (rightIndex < rightList.Count)
            {
                result.AddRange(rightList.Skip(rightIndex));
            }

            return result;
        }

    }
}
