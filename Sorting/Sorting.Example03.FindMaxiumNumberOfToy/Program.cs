using System;
using System.Linq;

namespace Sorting.Example03.FindMaxiumNumberOfToy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = new int[] { 1, 12, 5, 111, 200, 1000, 10 };
            int numToy = maximumToys(a, 50);
            Console.WriteLine(numToy);
            Console.Read();
        }


        /// <summary>
        /// https://www.hackerrank.com/challenges/mark-and-toys/problem?h_l=interview&playlist_slugs%5B%5D%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D%5B%5D=sorting
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static int maximumToys(int[] prices, int k)
        {
            // sort the price list
            int maxToy = 0;
            prices = RadixSort(prices);

            Console.WriteLine("price index");
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] <= k)
                {
                    maxToy++;
                    k -= prices[i];
                }
            }

            return maxToy;
        }

        static int[] RadixSort(int[] list)
        {
            var maxNumber = list.Max();

            var totalDigit = (int)Math.Ceiling(Math.Log10(maxNumber));

            for (int i = 0; i < totalDigit; i++)
            {
                list = CountingSort(list, i);
            }
            return list;
        }

        static int[] CountingSort(int[] list, int currentDigit)
        {
            var sortedList = new int[list.Length];
            var countList = new int[10];

            for (int i = 0; i < countList.Length; i++)
            {
                countList[i] = 0;
            }

            for (int i = 0; i < list.Length; i++)
            {
                var currentNumber = list[i];
                var currentDivision = (int)((currentNumber / Math.Pow(10, currentDigit)) % 10);
                countList[currentDivision]++;
            }

            //position
            for (int i = 1; i < countList.Length; i++)
            {
                countList[i] = countList[i] + countList[i - 1];
            }

            for (int i = list.Length - 1; i >= 0; i--)
            {
                var currentNumber = list[i];
                var currentDivision = (int)((currentNumber / Math.Pow(10, currentDigit)) % 10);
                countList[currentDivision]--;
                sortedList[countList[currentDivision]] = list[i];
            }
            return sortedList;
        }
    }
}
