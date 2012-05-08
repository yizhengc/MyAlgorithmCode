using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class SubstringWithWordConcatenation
    {
        //static int Find(string input, List<string> patterns)
        //{
        //    if (string.IsNullOrEmpty(input) || patterns == null || patterns.Count == 0)
        //        return -1;

        //    List<int> locations = FindAllLocations(input, patterns[0]);

        //    Dictionary<string, int> dict = new Dictionary<string,int>();

        //    for (int i = 0; i < patterns.Count; i++)
        //    {
        //        dict.Add(patterns[i], i);
        //    }

        //    bool ret = false;
        //    foreach (int l in locations)
        //    {
        //        List<int> matched = new List<int>();

        //        int start = l - patterns[0].Length;
        //        while (start >= 0 && start >= l - (patterns.Count - 1) * patterns[0].Length)
        //        {
        //            string str = input.Substring(start, patterns[0].Length);
        //            if (dict.ContainsKey(str))
        //                matched.Add(dict[str]);
        //            else
        //                break;

        //            start -= patterns[0].Length;
        //        }

        //        matched.Sort();
        //        matched.Add(dict[patterns[0]]);

        //        start = l + patterns[0].Length;
        //        while (start < input.Length && start <= l + (patterns.Count - 1) * patterns[0].Length)
        //        {
        //            string str = input.Substring(start, patterns[0].Length);
        //            if (dict.ContainsKey(str))
        //                matched.Add(dict[str]);
        //            else
        //                break;

        //            start += patterns[0].Length;
        //        }

        //        int left, right;
        //        ret = FindContinuousPattern(matched, out left, out right);

        //        if (ret)
        //            return left;
        //    }

        //    return -1;
        //}

        //static List<int> FindAllLocations(string input, string pattern)
        //{
        //    int start = 0;
        //    int index = 0;
        //    List<int> locations = new List<int>();
        //    while (index >= 0)
        //    {
        //        index = input.IndexOf(pattern, start);
        //        if (index >= 0)
        //        {
        //            locations.Add(index);
        //            start = index + pattern.Length;
        //        }
        //    }

        //    return locations;
        //}

        //static bool FindContinuousPattern(int[] matchResult, int patternSize)
        //{
        //    int[,] cum = new int[patternSize, matchResult.Length];

        //    for (int i = 0; i < matchResult.Length; i++)
        //    {
        //        for (int k = 0; k < patternSize; k++)
        //        {
        //            if (matchResult[i] < 0)
        //                cum[k, i] = 0;
        //            else if (k == matchResult[i])
        //                cum[k, i] = cum[k, i - 1] + 1;
        //            else
        //                cum[k, i] = cum[k, i - 1];
        //        }
        //    }


        //}
        
        //public static void UnitTest()
        //{

        //}
    }
}
