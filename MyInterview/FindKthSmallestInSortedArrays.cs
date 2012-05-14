using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class FindKthSmallestInSortedArrays
    {
        // Keypoint: r is the right most bound which is A.Count - 1 instead of A.Count
        /*static int FindKthSmallest(int[] A, int[] B, int l, int r, int k) 
        {
            if (l > r)
                return FindKthSmallest(B, A, Math.Max(0, k - A.Length), Math.Min(B.Length, k / 2), k);

            int i = (l + r) / 2;

            // Keypoint: k - 1 numbers should be smaller than A[i]. For index j - 1, there are j numbers, so we should minus extra 1.
            int j = k - i - 1 - 1;

            if (j > B.Length - 1 || j >= 0 && A[i] < B[j])
                return FindKthSmallest(A, B, i + 1, r, k);
            else if (j < -1 || j < B.Length - 1 && A[i] > B[j + 1])
                return FindKthSmallest(A, B, l, i - 1, k);
            else
                return A[i];
        }
        */
        static int FindKthSmallestLoop(int[] A, int[] B, int k, int times)
        {
            int l = 0;
            int r = A.Length - 1;

            if (times > 1)
                Console.WriteLine("Something is wrong");

            while (l <= r)
            {
                int i = (l + r) / 2;

                // Keypoint: k - 1 numbers should be smaller than A[i]. 
                // For index i, there are already i numbers smaller than index i;
                // For index j - 1, there are j numbers, so we should minus extra 1.
                int j = k - i - 2;

                if (j > B.Length - 1 || j >= 0 && A[i] < B[j])
                    l = i + 1;
                else if (j < -1 || j < B.Length - 1 && A[i] > B[j + 1])
                    r = i - 1;
                else
                    return A[i];
            }

            return FindKthSmallestLoop(B, A, k, ++times);
        }

        static int FindKthSmallestBruteForce(int[] A, int[] B, int k)
        {
            int i = 0;
            int j = 0;
            int ret = 0;

            while (k > 0)
            {
                if (j == B.Length || i < A.Length && A[i] <= B[j])
                    ret = A[i++];
                else
                    ret = B[j++];

                k--;
            }

            return ret;
        }

        // Find the median of two sorted arrays
        static double FindMedian(int[] A, int[] B, int l, int r, int nA, int nB) 
        {
            if (l > r) 
                return FindMedian(B, A, Math.Max(0, (nA + nB) / 2 - nA), Math.Min(nB, (nA + nB) / 2), nB, nA);

            int i = (l + r) / 2;

            int j = (nA + nB) / 2 - i - 1;

            if (j >= 0 && A[i] < B[j]) 
                return FindMedian(A, B, i + 1, r, nA, nB);
            else if (j < nB-1 && A[i] > B[j + 1]) 
                return FindMedian(A, B, l, i - 1, nA, nB);
            else {
                if ((nA + nB) % 2 == 1) 
                    return A[i];
                else if (i > 0) 
                    return (A[i] + Math.Max(B[j], A[i - 1])) / 2.0;
                else 
                    return (A[i] + B[j]) / 2.0;
            }
        }

        public static void UnitTest()
        {
            /*
            int[] A = new int[] { 1, 2, 3, 20, 32, 45 };
            int[] B = new int[] { 4, 5, 6 };

            double result = FindMedian(A, B, 0, 5, 6, 3);
            */

            int c = 100000;

            while (c > 0)
            {
                Random rand = new Random();

                int len = rand.Next(100);

                if (len < 2)
                    continue;

                int cut = rand.Next(len - 1);
                int k = Math.Max(1, rand.Next(len));

                List<int> A = new List<int>();
                List<int> B = new List<int>();

                for (int i = 0; i < len; i++)
                {
                    if (i <= cut)
                        A.Add(rand.Next(100));
                    else
                        B.Add(rand.Next(100));
                }

                A.Sort();
                B.Sort();

                //int res = FindKthSmallest(A.ToArray(), B.ToArray(), 0, A.Count - 1, k);

                int res2 = FindKthSmallestLoop(A.ToArray(), B.ToArray(), k, 0);

                int expected = FindKthSmallestBruteForce(A.ToArray(), B.ToArray(), k);

                if (res2 != expected)
                    Console.WriteLine("Expected: {0}, Actual1: {1}", expected, res2);

                c--;
            }
        }
    }
}
