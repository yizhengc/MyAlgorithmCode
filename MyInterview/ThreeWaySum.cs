using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    public class ThreeWaySum
    {
        static List<Tuple<int, int, int>> ZeroSumSet(List<int> input)
        {
            List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();
            for (int i = 0; i < input.Count - 2; i++)
            {
                int twoSum = 0 - input[i];
                int j = i + 1;
                int k = input.Count - 1;
                while (j < k)
                {
                    if (input[j] + input[k] < twoSum)
                    {
                        j++;
                    }
                    else if (input[j] + input[k] > twoSum)
                    {
                        k--;
                    }
                    else
                    {
                        result.Add(new Tuple<int, int, int>(input[i], input[j], input[k]));
                        j++;
                        k--;
                    }
                }
            }

            return result;
        }

        public static void UnitTest()
        {
            List<int> lst1 = new List<int>() { -6, -5, -2, -1, 1, 2, 3, 4, 5 };
            List<int> lst2 = new List<int>() { 2, 3, 6, 7 };

            List<Tuple<int, int, int>> result = ZeroSumSet(lst1);

            foreach (var e in result)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
