using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class LongestIncreasingSubsequence
    {
        static int[] LIS(int[] input)
        {
            List<int> maxLength = new List<int>();
            int[] parents = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (maxLength.Count == 0)
                {
                    maxLength.Add(i);
                    parents[i] = -1;
                }
                else
                {
                    int idx = SearchLargestSmaller(maxLength, input, input[i]);

                    // Keypoint: if the idx < 0, it means the current number is smallest. 
                    // Must update the maxLength[0]
                    if (idx < 0)
                    {
                        maxLength[0] = i;
                        parents[i] = -1;
                    }
                    else if (idx == maxLength.Count - 1)
                    {
                        maxLength.Add(i);
                        parents[i] = maxLength[idx];
                    }
                    else if (idx >= 0)
                    {
                        maxLength[idx + 1] = i;
                        parents[i] = maxLength[idx];
                    }
                }
            }

            int[] result = new int[maxLength.Count];
            result[maxLength.Count - 1] = input[maxLength[maxLength.Count - 1]];

            int j = maxLength[maxLength.Count - 1];
            int k = maxLength.Count - 1;
            while (parents[j] >= 0)
            {
                result[--k] = input[parents[j]];
                j = parents[j];
            }

            return result;
        }

        static int SearchLargestSmaller(List<int> input, int[] array, int target)
        {
            int l = 0;
            int h = input.Count;

            while (l <= h)
            {
                int m = (l + h) / 2;

                if (array[input[m]] >= target)
                    h = m - 1;
                else
                {
                    if (m == input.Count - 1 || array[input[m + 1]] >= target)
                        return m;
                    else
                        l = m + 1;
                }
            }

            return -1;
        }

        public static void UnitTest()
        {
            int[] result = LIS(new int[] { 3, 4, 1, 5, 3, 7, 6, 8, 0 });
        }
    }
}
