using System;

namespace Sorting.Example02.BubleSort
{
    class Program
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-bubble-sort/problem?h_l=interview&playlist_slugs%5B%5D%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D%5B%5D=sorting
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = new int[] { 1, 2, 5, 4 };
            countSwaps(a);
            Console.Read();
        }


        static void countSwaps(int[] a)
        {
            int swapCount = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        var temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swapCount++;
                    }
                }
            }
            Console.WriteLine("Array is sorted in " + swapCount + " swaps.");
            Console.WriteLine("First Element: " + a[0]);
            Console.WriteLine("Last Element: " + a[a.Length - 1]);
        }
    }
}
