using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    /// <summary>
    /// Given an unsorted array 1 9 4 5 3 8 7
    /// The legitimate operations are reduce the value by 1 which costs 1
    /// Or remove the number, which cost the value of the number
    /// Try to compute the minimal cost to make the array monotonically increase
    /// </summary>
    class MinCostToConvertToSortedArray
    {
        static int FindMinCost(int[] input)
        {
            if (input.Length == 1)
                return 0;

            int max = input[0];

            for(int i = 1; i < input.Length; i++)
                if (input[i] > max)
                    max = input[i];

            int[,] minCost = new int[max + 1, input.Length + 1];

            int maxSofar = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > maxSofar)
                    maxSofar = input[i];

                for (int j = 0; j <= maxSofar; j++)
                {
                    if (input[i] >= j)
                    {
                        minCost[j, i + 1] = minCost[j, i] + input[i];

                        for (int k = 0; k < j; k++)
                        {
                            if (minCost[j, i + 1] > minCost[k, i] + input[i] - j)
                                minCost[j, i + 1] = minCost[k, i] + input[i] - j;
                        }
                    }
                    else
                    {
                        minCost[j, i + 1] = minCost[j, i] + input[i];
                    }
                }
            }

            int min = int.MaxValue;
            for (int j = 0; j < max; j++)
            {
                if (min > minCost[j, input.Length])
                    min = minCost[j, input.Length];
            }

            return min;
        }

        public static void UnitTest()
        {
            int minCost = FindMinCost(new int[] { 1, 9, 4, 5, 3, 8, 7 });
        }
    }
}
