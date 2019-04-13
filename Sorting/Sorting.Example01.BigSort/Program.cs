using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Example01.BigSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = new string[] { "6", "31415926535897932384626433832795", "1", "3", "10", "3", "5" };

            var result = bigSorting(a);

            foreach (var sortedResult in result)
            {
                Console.Write(sortedResult + " ");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/big-sorting/problem
        /// </summary>
        /// <param name="unsorted"></param>
        /// <returns></returns>
        static string[] bigSorting(string[] unsorted)
        {
            var list = unsorted.Select(t => double.Parse(t)).ToArray();
            var originalList = list.ToList();
            var maxValue = list.Max();

            var totalDigits = (int)Math.Ceiling(Math.Log10(maxValue));

            for (int i = 0; i < totalDigits; i++)
            {
                list = CoutingSort(list, i);
            }
            var results = new string[unsorted.Length];
            int count = 0;

            foreach(var item in list)
            {
                var index = originalList.IndexOf(item);
                results[count] = unsorted[index];
                count++;
            }

            return results;
        }

        static double[] CoutingSort(double[] inputList, int currentDigit)
        {
            var countList = new int[10];
            var sortedList = new double[inputList.Length];
            for (int i = 0; i < countList.Length; i++)
            {
                countList[i] = 0;
            }

            for (int i = 0; i < inputList.Length; i++)
            {
                var currentValue = (int)(inputList[i] / Math.Pow(10, currentDigit) % 10);
                countList[currentValue]++;
            }

            // position
            for (int i = 1; i < countList.Length; i++)
            {
                countList[i] = countList[i] + countList[i - 1];
            }

            for (int i = inputList.Length - 1; i >= 0; i--)
            {
                var currentValue = (int)(inputList[i] / Math.Pow(10, currentDigit) % 10);
                countList[currentValue]--;
                sortedList[countList[currentValue]] = inputList[i];
            }

            return sortedList;
        }

    }
}
