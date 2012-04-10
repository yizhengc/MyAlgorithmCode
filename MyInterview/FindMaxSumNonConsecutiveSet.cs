using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class FindMaxSumNonConsecutiveSet
    {
        static List<int> MaxSumNonConsecutiveSequence(List<int> array)
        {
            if (array == null || array.Count == 0)
                return null;

            List<Tuple<int, int>> maxSum = new List<Tuple<int, int>>(array.Count);

            int maxOverall = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Count; i++)
            {
                int bigger = 0;
                int biggerIndex = -1;

                if (i >= 2)
                {
                    if (i == 2)
                    {
                        bigger = maxSum[0].Item1;
                        bigger = 0;
                    }
                    else if (maxSum[i - 3].Item1 < maxSum[i - 2].Item1)
                    {
                        bigger = maxSum[i - 2].Item1;
                        biggerIndex = i - 2;
                    }
                    else
                    {
                        bigger = maxSum[i - 3].Item1;
                        biggerIndex = i - 3;
                    }
                }

                maxSum.Add(new Tuple<int, int>(bigger + array[i], biggerIndex));

                if (bigger + array[i] > maxOverall)
                {
                    maxOverall = bigger + array[i];
                    index = i;
                }
            }

            List<int> result = new List<int>();

            for (int i = index; i >= 0; )
            {
                result.Add(array[i]);
                i = maxSum[i].Item2;
            }

            result.Add(maxOverall);

            return result;
        }

        public static void UnitTest()
        {
            List<int> array = new List<int>() { 1, 3, 2, 7, 6, 4, 5 };

            List<int> result = MaxSumNonConsecutiveSequence(array);

            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i]);
                Console.Write(" ");
            }

            Console.Write("\n");
        }
    }
}
