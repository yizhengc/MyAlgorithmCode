using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class MaxSumSubarray
    {
        static int MaxSubarraySum(int[] array)
        {
            int maxSofar = -1;
            int maxEndHere = -1;

            for (int i = 0; i < array.Length; i++)
            {
                maxEndHere = Math.Max(maxEndHere + array[i], 0);

                maxSofar = Math.Max(maxEndHere, maxSofar);
            }

            return maxSofar;
        }


        static int MaxSubarraySum(int[] array, out int left, out int right)
        {
            int maxSofar = -1;
            int maxEndHere = -1;
            left = 0;
            right = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (maxEndHere + array[i] > 0)
                {
                    maxEndHere += array[i];
                }
                else
                {
                    maxEndHere = 0;
                    left = i + 1;
                }

                if (maxSofar < maxEndHere)
                {
                    maxSofar = maxEndHere;
                    right = i;
                }
            }

            return maxSofar;
        }

        public static void UnitTest()
        {
            int[] array = new int[] { 0, 1, -2, 3, 5, -6, 7, -1 };

            int left, right;
            int maxValue = MaxSubarraySum(array, out left, out right);

            Console.WriteLine("Subarray Sum: {0}, starts from {1}, ends at {2}", maxValue, left, right);
        }
    }
}
