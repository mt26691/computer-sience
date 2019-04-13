using System.Collections.Generic;

namespace Sorting.QuickSort
{
    public class QuickSortTest
    {
        public List<int> QuickSort(List<int> inputList, int low, int high)
        {
            if (low < high)
            {
                var partitionNumber = Partition(inputList, low, high);

                QuickSort(inputList, low, partitionNumber - 1);
                QuickSort(inputList, partitionNumber + 1, high);
            }
            return inputList;
        }

        /// <summary>
        /// Quick sort is a divide and conquer algorithm
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int Partition(List<int> inputList, int low, int high)
        {
            // always pick pivot as last element
            var pivot = inputList[high];
            // index of small element, we often begin from 0
            var i = low - 1;

            for (int j = low; j <= high; j++)
            {
                if (inputList[j] < pivot)
                {
                    // this element should go to the left of the list
                    i++;
                    var swapSmallValue = inputList[j];
                    inputList[j] = inputList[i];
                    // small element is placed to the left
                    inputList[i] = inputList[j];
                }
            }
            // swap the bigger element than pivot to right of the list, while pivot to left

            inputList[high] = inputList[i + 1];
            inputList[i + 1] = pivot;
            return i + 1;
        }
    }
}
