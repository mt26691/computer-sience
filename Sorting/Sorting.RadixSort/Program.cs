using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = new List<int> { 123, 8550, 3550, 1234567, 45450, 512220, 7000 };

            var result = RadixSort(a);

            foreach (var sortedResult in result)
            {
                Console.Write(sortedResult + " ");
            }

            //Console.WriteLine((int)(1234567 / (Math.Pow(10, 6)) % 10));

            Console.ReadLine();
        }

        public static List<int> RadixSort(List<int> inputList)
        {
            var maxValue = inputList.Max();
            Console.WriteLine("max value = " + maxValue);

            // find total digit of the max value
            var totalDigits = (int)Math.Ceiling(Math.Log10(maxValue));
            Console.WriteLine("This list contains maximum " + totalDigits + " digits");

            for (int i = 0; i < totalDigits; i++)
            {
                inputList = CountingSort(inputList, i);
            }
            return inputList;
        }

        public static List<int> CountingSort(List<int> list, int currentDigit)
        {
            var output = new int[list.Count];
            var count = new int[10];

            Console.WriteLine("Sorting with current digit = " + currentDigit);
            //initializing all elements of count to 0 
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 0;
            }

            // store occurance of the number
            for (int i = 0; i < list.Count; i++)
            {
                var currentNumber = list[i];
                var currentBase = (int)(list[i] / (Math.Pow(10, currentDigit)) % 10);
                count[currentBase]++;
            }
            Console.WriteLine("occurrenace ");

            for (int i = 0; i < count.Length; i++)
            {
                Console.WriteLine("number " + i + " occurs " + count[i]);
            }

            // Change count[i] so that count[i] now contains actual  
            //  position of this digit in output[]  
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                var digitOfAI = (int)(list[i] / (Math.Pow(10, currentDigit)) % 10);
                count[digitOfAI]--;
                output[count[digitOfAI]] = list[i];
            }
            return output.ToList();
            
        }
    }
}
