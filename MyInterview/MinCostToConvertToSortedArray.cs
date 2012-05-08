using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class MinCostToConvertToSortedArray
    {
        int MinCost(int[] input)
        {
            Dictionary<int, List<int>> cost = new Dictionary<int, List<int>>();

            foreach(var k in input)
            {
                if (!cost.ContainsKey(k))
                    cost.Add(k, new List<int>());
            }

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var v in cost)
                {
                    int newCost = 0;
                    if (input[i] < v.Key)
                    {
                        newCost = cost[v.Key][cost[v.Key].Count - 1] + input[i];
                    }
                    else
                    {

                    }
                }
            }

            return 1;
        }
    }
}
