using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class Matrix
    {
        static void Rotate(int[,] matrix, int n)
        {
            int m = n / 2 - 1;

            for (int r = 0; r <= m; r++)
            {
                for (int c = r; c < n - r - 1; c++)
                {
                    int temp = matrix[r, c];
                    matrix[r, c] = matrix[n - 1 - c, r];
                    matrix[n - 1 - c, r] = matrix[n - 1 - r, n - 1 - c];
                    matrix[n - 1 - r, n - 1 - c] = matrix[c, n - 1 - r];
                    matrix[c, n - 1 - r] = temp;
                }
            }
        }

        public static void UnitTest()
        {
            int[,] matrix = new int[5, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };

            Rotate(matrix, 5);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
