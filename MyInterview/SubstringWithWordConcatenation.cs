using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class SubstringWithWordConcatenation
    {
        /*
        static int Find(string input, List<string> patterns)
        {
            if (string.IsNullOrEmpty(input) || patterns == null || patterns.Count == 0)
                return -1;

            List<int> locations = FindAllLocations(input, patterns[0]);

            Dictionary<string, int> dict = new Dictionary<string,int>();

            for (int i = 0; i < patterns.Count; i++)
            {
                dict.Add(patterns[i], i);
            }

            foreach (int l in locations)
            {
                int start = l - (patterns.Count - 1) * patterns[0].Length;
                int end = Math.Min(input.Length - 1, l + (patterns.Count - 1) * patterns[0].Length);

                Dictionary<int, int> history = new Dictionary<int, int>();
                int resultStart = l;
                while (start <= end)
                {
                    if (start < 0)
                        continue;

                    string str = input.Substring(start, patterns[0].Length);
                    if (!dict.ContainsKey(str))
                    {
                        history.Clear();
                    }
                    else if (history.ContainsKey(dict[str]))
                    {
                        resultStart = start;
                        sum = sum & dict[str];
                    }
                    else
                    {
                        resultStart = start;
                        sum += dict[str];
                    }

                    if (sum == expectedSum)
                        break;

                    start += patterns[0].Length;
                }

                if (start <= end)
                    return resultStart;
            }

            return -1;
        }

        static List<int> FindAllLocations(string input, string pattern)
        {
            int start = 0;
            int index = 0;
            List<int> locations = new List<int>();
            while (index >= 0)
            {
                index = input.IndexOf(pattern, start);
                if (index >= 0)
                {
                    locations.Add(index);
                    start = index + pattern.Length;
                }
            }

            return locations;
        }

        static bool ContainsContinuousSet(int[] matchResult, int patternSize)
        {
            int[,] cum = new int[patternSize, matchResult.Length];

            for (int i = 0; i < matchResult.Length; i++)
            {
                for (int k = 0; k < patternSize; k++)
                {
                    if (matchResult[i] < 0)
                        cum[k, i] = 0;
                    else if (k == matchResult[i])
                        cum[k, i] = cum[k, i - 1] + 1;
                    else
                        cum[k, i] = cum[k, i - 1];
                }
            }


        }
        */
        public static void UnitTest()
        {

        }
    }
}
