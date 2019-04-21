using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Example05.ActivityNotifications
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var numberOfNotif = activityNotifications(new int[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 }, 5);
            Console.WriteLine(numberOfNotif);
            Console.ReadLine();
        }

        static int activityNotifications(int[] expenditure, int d)
        {
            int result = 0;
            var originalList = expenditure.ToList();
            var executeList = new List<int>();
            // do first check0
            if (originalList.Count < d)
            {
                return 0;
            }
            var index = 0;

            while (originalList.Count > d + index)
            {
                if (index == 0)
                {
                    executeList = originalList.GetRange(0, d);
                    executeList = RadixSort(executeList);
                    originalList.GetRange(0, d);
                }
                else
                {
                    var nextElement = originalList[d + index - 1];
                    // quick insert
                    var firstElementItem = originalList[index - 1];
                    var binaryIndex = FindInsertPoint(executeList, firstElementItem);
                    executeList.RemoveAt(binaryIndex);

                    var insertIndex = FindInsertPoint(executeList, nextElement);
                    executeList.Insert(insertIndex, nextElement);
                }

                double median = 0;
                // find median
                if (executeList.Count % 2 == 1)
                {
                    median = executeList[executeList.Count / 2];
                }
                else
                {
                    median = (executeList[executeList.Count / 2] + executeList[(executeList.Count / 2) - 1]) / 2.0;
                }

                // count notificaiton
                if (median * 2 <= originalList[index + d])
                {
                    result++;
                }
                index++;
            }

            return result;
        }

        static List<int> RadixSort(List<int> inputList)
        {
            var maxNumber = inputList.Max();

            var totalDigits = (int)Math.Ceiling(Math.Log10(maxNumber));
            var results = inputList.ToArray();
            for (int i = 0; i < totalDigits; i++)
            {
                results = CountingSort(results, i);
            }

            return results.ToList();
        }

        static int[] CountingSort(int[] inputList, int currentDigit)
        {
            var countList = new int[10];
            var results = new int[inputList.Length];

            // initial value = 0
            for (int i = 0; i < countList.Length; i++)
            {
                countList[i] = 0;
            }

            for (int i = 0; i < inputList.Length; i++)
            {
                var currentNumber = (int)((inputList[i] / Math.Pow(10, currentDigit)) % 10);
                countList[currentNumber]++;
            }

            // position the number
            for (int i = 1; i < countList.Length; i++)
            {
                countList[i] = countList[i] + countList[i - 1];
            }
            // sort the list by asc

            for (int i = inputList.Length - 1; i >= 0; i--)
            {
                var currentNumber = (int)((inputList[i] / Math.Pow(10, currentDigit)) % 10);
                countList[currentNumber]--;
                results[countList[currentNumber]] = inputList[i];
            }
            return results;
        }

        /// <summary>
        /// Binary search to find proper index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static int FindInsertPoint(List<int> array, int value)
        {
            int minIndex = 0;
            int maxIndex = array.Count - 1;
            var mid = (minIndex + maxIndex) / 2;

            while (minIndex < maxIndex)
            {
                mid = (minIndex + maxIndex) / 2;
                if (array[mid] == value)
                {
                    // insert into mid
                    return mid;
                }
                else if (array[mid] > value)
                {
                    maxIndex = mid - 1;
                }
                else
                {
                    minIndex = mid + 1;
                }
            }

            return minIndex;
        }

    }
}
