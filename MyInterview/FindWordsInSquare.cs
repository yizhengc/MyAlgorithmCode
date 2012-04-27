using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class FindWordsInSquare
    {
        static List<string> FindWords(char[,] matrix, int n, Dictionary<string, bool> dict)
        {
            List<string> results = new List<string>();
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    bool[,] visited = new bool[n, n];
                    FindWords_DFS("", matrix, visited, r, c, n, dict, results);
                }
            }

            return results;
        }

        static void FindWords_DFS(string prev, char[,] matrix, bool[,] visited, int r, int c, int n, Dictionary<string, bool> dict, List<string> results)
        {
            prev = prev + matrix[r, c];
            if (dict.ContainsKey(prev))
                results.Add(prev);

            visited[r, c] = true;

            foreach (var v in GetNeighbors(visited, r, c, n))
            {
                FindWords_DFS(prev, matrix, visited, v.Item1, v.Item2, n, dict, results);
            }

            // Keypoint: remember to set it back to false. Otherwise the other branches can't use this word.
            visited[r, c] = false;
        }

        static Tuple<int, int>[] GetNeighbors(bool[,] visited, int r, int c, int n)
        {
            List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();
            for (int i = r - 1; i <= r + 1; i++)
            {
                for (int j = c - 1; j <= c + 1; j++)
                {
                    if (i >= 0 && i < n && j >= 0 && j < n && visited[i, j] == false)
                    {
                        neighbors.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return neighbors.ToArray();
        }

        public static void UnitTest()
        {
            char[,] matrix = new char[4,4]
            {
                {'a', 'v', 'e', 'f'},
                {'p', 'p', 'v', 'r'},
                {'a', 'l', 'e', 'e'},
                {'w', 'e', 'n', 'f'},
            };

            Dictionary<string, bool> dict = new Dictionary<string,bool>()
            {
                {"apple", true},
                {"even", true},
                {"free", true},
                {"new", true},
                {"ale", true},
                {"paw", true}
            };

            List<string> result = FindWords(matrix, 4, dict);

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }
    }
}
