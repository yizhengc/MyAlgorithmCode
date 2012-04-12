using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class StringMatching
    {
        static int[] PreprocessPattern(string pattern)
        {
            int[] pi = new int[pattern.Length];

            pi[0] = 0;
            int q = 0; // nunber of matched
            for (int i = 1; i < pattern.Length; i++)
            {
                // loop back until the last match or matched equals 0
                while (q > 0 && pattern[q] != pattern[i])
                {
                    q = pi[q];
                }

                // Then start to match
                if (pattern[q] == pattern[i])
                {
                    q++;
                }
                    
                pi[i] = q;
            }

            return pi;
        }

        static List<int> FindNeedleInHaystack(string pattern, string haystack)
        {
            int[] pi = PreprocessPattern(pattern);
            List<int> matchedOffsets = new List<int>();

            int q = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                // loop back until the last match or matched equals 0
                while (q > 0 && pattern[q] != haystack[i])
                {
                    q = pi[q];
                }

                if (pattern[q] == haystack[i])
                {
                    q++;
                }

                if (q == pattern.Length)
                {
                    matchedOffsets.Add(i + 1 - pattern.Length);
                    q = pi[q - 1];
                }
            }

            return matchedOffsets;
        }

        public static void UnitTest()
        {
            string pattern = "ababcdbca";

            string haystack = "acanaiababcdbcababcdbca";

            List<int> result = FindNeedleInHaystack(pattern, haystack);

            foreach (int i in result)
            {
                Console.WriteLine("Found match at {0}: {1}", i, haystack.Substring(i, pattern.Length));
            }
        }
    }
}
