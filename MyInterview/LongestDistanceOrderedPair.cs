using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    // Key: Use an auxiliary array to remember the largest element to the right of the current element. 
    // If original is 12, 6, 1, 8, 9, 3, 2, 4, 10, 2, 2
    // aux will be 12, 10, 10, 10, 10, 10, 10, 10, 10, 2, 2, -inf
    // The aux just provides the information saying there is a bigger value after the current location which is say 10. 
    // When found longest order pair starting from the current location i, there won't be pair in between that's longer.
    class LongestDistanceOrderedPair
    {
        static int Distance(int[] array, out int left, out int right)
        {
            int len = array.Length;

            int[] aux = new int[len + 1];

            left = right = 0;

            aux[len] = int.MinValue;
            int j = 0;
            for (j = len - 1; j >= 0; j--)
            {
                if (array[j] > aux[j + 1])
                    aux[j] = array[j];
                else
                    aux[j] = aux[j + 1];
            }

            int max = 0;

            int i = 0;
            j = 0;
            // Use the aux that's 1 element more than the array to deal with boundary case
            // So that we don't need to check the boundary case when j == len after the loop
            while(i < len && j <= len)
            {
                if (array[i] < aux[j])
                    j++;
                else
                {
                    if (j - i - 1 > max)
                    {
                        max = j - i - 1;
                        left = array[i];
                        right = array[j - 1];
                    }

                    i++;
                }
            }

            return max;
        }

        public static void UnitTest()
        {
            int[] array = new int[] { 12, 6, 1, 8, 9, 3, 2, 4, 10, 2, 2 };

            int left, right;
            int distance = Distance(array, out left, out right);

            Console.WriteLine("Distance: {0}, Left: {1}, Right: {2}", distance, left, right);
        }
    }
}
