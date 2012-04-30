using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class PartitionSet
    {
        /*
        List<int> Partition(List<int> input)
        {
            int sum = 0;

            foreach (var v in input)
            {
                sum += v;
            }

            double target = sum / 2;

            bool[,] subsetSum = new bool[sum + 1, input.Count + 1];

            // P(i, j) = 1 if there exist a subset in A1 ... Ai that sum to j
            // P(i, j) = max(P(i - 1, j), P(i - 1, j - Ai));
            for (int i = 1; i <= input.Count; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    subsetSum[j, i] = subsetSum[j, i - 1] || subsetSum[j - input[i - 1], i - 1];
                }
            }

            // Find a j that minimize j - sum/2
            for (int i = 1; i <= input.Count; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
        }
         */
    }
}
