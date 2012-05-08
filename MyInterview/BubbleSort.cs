using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class BubbleSort
    {
        static void Sort(int[] input)
        {
            int tail = input.Length;
            while (tail > 0)
            {
                for (int i = 0; i < tail - 1; i++)
                {
                    if (input[i] > input[i + 1])
                        Swap(ref input[i], ref input[i + 1]);
                }

                tail--;
            }
        }

        static void LimitedSort(int[] input, int k)
        {
            int start = 0;
            while (start < input.Length)
            {
                int idx = FindSmallest(input, start, k);

                while (idx > start && input[idx - 1] > input[idx])
                {
                    Swap(ref input[idx - 1], ref input[idx]);
                    idx--;
                    k--;

                    if (k == 0)
                        return;
                }

                start++;
            }
        }

        static int FindSmallest(int[] input, int start, int maxStep)
        {
            int min = input[start];
            int minIdx = start;
            for (int i = start; i < Math.Min(input.Length, start + maxStep + 1); i++)
            {
                if (input[i] < min)
                {
                    min = input[i];
                    minIdx = i;
                }
            }

            return minIdx;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void UnitTest()
        {
            int[] input = new int[] { 3, 2, 1, 4, 6, 5 };

            Sort(input);

            input = new int[] { 3, 2, 1, 4, 6, 5 };
            LimitedSort(input, 1);
        }
    }
}
