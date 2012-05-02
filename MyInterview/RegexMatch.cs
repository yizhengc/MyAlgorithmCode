using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class RegexMatch
    {
        /// <summary>
        /// Match patterns like F*b*k where * represents 0 or multiple characters.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        static bool Match(string word, string pattern)
        {
            if (word == null || pattern == null)
                return false;

            string[] tokens = pattern.Split('*');

            int matchStart = 0;

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "")
                    continue;
                else
                {
                    if (i == tokens.Length - 1)
                    {
                        int idx = word.LastIndexOf(tokens[i]);
                        if (idx >= 0 && idx >= matchStart && idx + tokens[i].Length == word.Length)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        int idx = word.IndexOf(tokens[i], matchStart);
                        if (idx < 0 || i == 0 && idx != 0)
                            return false;
                        else
                        {
                            matchStart = idx + tokens[i].Length;
                        }
                    }
                }
            }

            return true;
        }

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
            string regex = "a*b*bc*";

            string[] str = new string[] { "", "abkbc", "abcbc", "ac", "bc", "c", "ab", "ba" };

            foreach (var s in str)
            {
                Console.WriteLine("{0}:{1}", s, Match(s, regex));
            }
        }
    }
}
