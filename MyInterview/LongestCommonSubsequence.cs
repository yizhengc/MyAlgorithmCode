using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    enum Direction
    {
        Left,
        Up,
        UpLeft
    }

    struct Cell
    {
        public int Matched;
        public Direction Dir;
    }

    class LongestCommonSubsequence
    {
        static Tuple<int, int> FindMinWindowWithPatternSet(string input, string pattern)
        {
            Dictionary<char, int> cumPatternSet = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!cumPatternSet.ContainsKey(pattern[i]))
                    cumPatternSet.Add(pattern[i], 0);
            }

            int s = 0;
            int e = 0;
            Tuple<int, int> result = null;
            int minWindow = input.Length;
            while (s < input.Length && e < input.Length)
            {
                if (IsPatternComplete(cumPatternSet))
                {
                    if (e - s + 1 < minWindow)
                    {
                        minWindow = e - s + 1;
                        result = new Tuple<int, int>(s, minWindow);
                    }
                }


                if (cumPatternSet.ContainsKey(input[e]))
                {

                }
            }

            return result;
        }

        static bool IsPatternComplete(Dictionary<char, int> cumPatternSet)
        {
            foreach (var kvp in cumPatternSet)
            {
                if (kvp.Value < 1)
                    return false;
            }

            return true;
        }

        static Tuple<int, int> FindMinWindowWithPattern(string input, string pattern)
        {
            int rows = pattern.Length + 1;
            int cols = input.Length + 1;
            Cell[,] map = new Cell[rows, cols];

            int r, c;
            for (r = 1; r < rows; r++)
            {
                for (c = 1; c < cols; c++)
                {
                    if (input[c - 1] == pattern[r - 1])
                    {
                        map[r, c].Dir = Direction.UpLeft;
                        map[r, c].Matched = map[r - 1, c - 1].Matched + 1;
                    }
                    else if (map[r - 1, c].Matched > map[r, c - 1].Matched)
                    {
                        map[r, c].Matched = map[r - 1, c].Matched;
                        map[r, c].Dir = Direction.Up;
                    }
                    else
                    {
                        map[r, c].Matched = map[r, c - 1].Matched;
                        map[r, c].Dir = Direction.Left;
                    }
                }
            }

            List<int> Matched = new List<int>();

            Tuple<int, int> result = null;

            int minWindow = input.Length;
            for (int i = 0; i < cols; i++)
            {
                if (map[rows - 1, i].Matched == pattern.Length)
                {
                    c = i;
                    r = rows - 1;
                    while (r > 0)
                    {
                        if (map[r, c].Dir == Direction.UpLeft)
                        {
                            r--;
                            c--;
                        }
                        else if (map[r, c].Dir == Direction.Left)
                        {
                            c--;
                        }
                        else
                            r--;
                    }

                    if (i - c < minWindow)
                    {
                        result = new Tuple<int, int>(c, i - c);
                        minWindow = i - c;
                    }
                }
            }

            return result;
        }

        static string FindLCS(string input1, string input2)
        {
            int rows = input1.Length + 1;
            int cols = input2.Length + 1;
            Cell[,] map = new Cell[rows, cols];

            int r, c;
            for (r = 1; r < rows; r++)
            {
                for (c = 1; c < cols; c++)
                {
                    if (input2[c - 1] == input1[r - 1])
                    {
                        map[r, c].Dir = Direction.UpLeft;
                        map[r, c].Matched = map[r - 1, c - 1].Matched + 1;
                    }
                    else if (map[r - 1, c].Matched > map[r, c - 1].Matched)
                    {
                        map[r, c].Matched = map[r - 1, c].Matched;
                        map[r, c].Dir = Direction.Up;
                    }
                    else
                    {
                        map[r, c].Matched = map[r, c - 1].Matched;
                        map[r, c].Dir = Direction.Left;
                    }
                }
            }

            char[] result = new char[map[rows - 1, cols - 1].Matched];

            r = rows - 1;
            c = cols - 1;
            int k = result.Length - 1;
            while (r >= 0 && c >= 0)
            {
                if (map[r, c].Dir == Direction.UpLeft)
                {
                    result[k--] = input1[r - 1];
                    r--;
                    c--;
                }
                else if (map[r, c].Dir == Direction.Left)
                {
                    c--;
                }
                else
                    r--;
            }

            return new string(result);
        }

        public static void UnitTest()
        {
            Console.WriteLine(FindLCS("acjadcai", "cadkjihl"));
            string input = "acjkadicaik";
            Tuple<int, int> result = FindMinWindowWithPattern(input, "aci");
            Console.WriteLine("Left: {0}, Right: {1}, Content: {2}", result.Item1, result.Item2, input.Substring(result.Item1, result.Item2));
        }
    }
}
