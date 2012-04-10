using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class WordBreaker
    {
        Dictionary<string, bool> _dict;

        public WordBreaker(Dictionary<string, bool> dict)
        {
            _dict = dict;
        }

        public void BreakWords(string stream, List<int>[] possibleWB)
        {
            
            for (int i = stream.Length - 1; i >= 0; i++)
            {
                possibleWB[i] = new List<int>();
                string cur = stream.Substring(i);
                if (_dict.ContainsKey(cur))
                {
                    foreach(
                }
            }
        }
    }
}
