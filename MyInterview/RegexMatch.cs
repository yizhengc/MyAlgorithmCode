using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class RegexMatch
    {
        static bool Match(string word, int start, string regex, int rstart)
        {
            if (start == word.Length && rstart == regex.Length)
                return true;

            if (start != word.Length && rstart == regex.Length)
                return false;

            if (rstart == regex.Length - 1 || !IsSpecialChar(regex[rstart+1]))
            {
                if (start == word.Length)
                    return false;

                if (IsSpecialChar(regex[rstart]))
                    throw new Exception();
                else if (word[start] != regex[rstart])
                    return false;
                else
                    return Match(word, start + 1, regex, rstart + 1);
            }
            else
            {
                char specialChar = regex[rstart + 1];
                char c = regex[rstart];

                if (specialChar == '?')
                {
                    if (start < word.Length && word[start] == c)
                        return Match(word, start + 1, regex, rstart + 2);
                    else
                        return Match(word, start, regex, rstart + 2);
                }
                else if (specialChar == '*')
                {
                    if (start < word.Length && word[start] == c)
                    {
                        return Match(word, start, regex, rstart + 2) || Match(word, start + 1, regex, rstart) || Match(word, start + 1, regex, rstart + 2);
                    }
                    else
                        return Match(word, start, regex, rstart + 2);
                }
                else
                    throw new Exception();
            }
        }

        static bool IsSpecialChar(char c)
        {
            return c == '*' || c == '?';
        }

        public static void UnitTest()
        {
            string regex = "a*b?c?";

            string[] str = new string[] { "", "abbc", "ac", "bc", "c", "ab", "ba" };

            foreach (var s in str)
            {
                Console.WriteLine("{0}:{1}", s, Match(s, 0, regex, 0));
            }
        }
    }
}
