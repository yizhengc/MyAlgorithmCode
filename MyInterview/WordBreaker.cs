using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class WordBreaker
    {
        public WordBreaker(Dictionary<string, bool> dict)
        {
        }

        static void BreakWords(string prev, string stream, int start, List<string> words, Dictionary<string, bool> dict)
        {
            for (int i = start + 1; i <= stream.Length; i++)
            {
                string str = stream.Substring(start, i - start);
                if (dict.ContainsKey(str))
                {
                    if (i == stream.Length)
                        words.Add(prev + " " + str);
                    else
                        BreakWords(string.IsNullOrEmpty(prev) ? str : prev + " " + str, stream, i, words, dict);
                }
            }
        }

        public static void UnitTest()
        {
            List<string> results = new List<string>();

            Dictionary<string, bool> dict = new Dictionary<string, bool>()
            {
                {"the", true}, {"there", true}, {"are", true}, {"rear", true}, {"eth", true}, {"three", true}, {"ree", true}, {"ethree", true}
            };

            BreakWords("", "therearethree", 0, results, dict);
        }
    }
}
