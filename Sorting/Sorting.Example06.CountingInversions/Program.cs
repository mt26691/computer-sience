using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Example06.CountingInversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static long countInversions(int[] arr)
        {
            return 0;
        }
        
        static List<int> MergeSort(List<int> inputList)
        {
            if (inputList.Count <= 1)
            {
                return inputList;
            }

            var mid = inputList.Count / 2;

            var leftList = inputList.GetRange(0, mid);
            var rightList = inputList.Skip(mid).ToList();

            var left = MergeSort(leftList);
            var right = MergeSort(rightList);

            return Merge(left, right);
        }

        static List<int> Merge(List<int> leftList, List<int> rightList)
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
