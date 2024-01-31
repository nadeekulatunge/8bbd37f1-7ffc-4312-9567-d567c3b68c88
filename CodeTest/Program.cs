using System;
using System.Collections.Generic;

namespace LongestIncreasingSubsequence
{
    public class Program
    {
        public static void Main()
        {
            string[] inputArray = Console.ReadLine().Split(new char[0]);

            if (!IsValidArray(inputArray))
                return;

            int[] intArray = ConvertStringArrayToIntArray(inputArray);

            int[] longestSubsequenceArray = FindLongestIncreasingSubsequence(intArray);

            Console.WriteLine("Longest Increasing Subsequence- " + string.Join(", ", longestSubsequenceArray));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] arr)
        {
            List<int> currentIncreasingSubsequence = new List<int>();
            List<int> longestIncreasingSubsequence = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0 || arr[i] > arr[i - 1])
                    currentIncreasingSubsequence.Add(arr[i]);

                else
                {
                    if (currentIncreasingSubsequence.Count > longestIncreasingSubsequence.Count)
                        longestIncreasingSubsequence = new List<int>(currentIncreasingSubsequence);

                    currentIncreasingSubsequence.Clear();
                    currentIncreasingSubsequence.Add(arr[i]);
                }
            }

            if (currentIncreasingSubsequence.Count > longestIncreasingSubsequence.Count)
                longestIncreasingSubsequence = new List<int>(currentIncreasingSubsequence);

            return longestIncreasingSubsequence.ToArray();
        }

        static bool IsValidArray(string[] inputArray)
        {
            foreach (string element in inputArray)
            {
                if (!int.TryParse(element, out _))
                    return false;
            }

            return true;
        }

        public static int[] ConvertStringArrayToIntArray(string[] inputArray)
        {
            int[] resultArray = new int[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
                int.TryParse(inputArray[i], out resultArray[i]);

            return resultArray;
        }
    }
}


   

