using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class FindKthSmallestInSortedArrays
    {
        static int FindKthSmallest(int[] A, int[] B, int l, int r, int nA, int nB, int k) 
        {
            if (l > r)
                return FindKthSmallest(B, A, Math.Max(0, k - nA), Math.Min(nB, k), nB, nA, k);

            int i = (l + r) / 2;

            int j = k - i - 1;

            if (j >= 0 && A[i] < B[j])
                return FindKthSmallest(A, B, i + 1, r, nA, nB, k);
            else if (j < nB - 1 && A[i] > B[j + 1])
                return FindKthSmallest(A, B, l, i - 1, nA, nB, k);
            else
                return A[i];
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
            int[] A = new int[] { 1, 2, 3, 20 };
            int[] B = new int[] { 4, 5, 6 };

            double result = FindMedian(A, B, 0, 3, 4, 3);

            int res = FindKthSmallest(A, B, 0, 3, 4, 3, 4);
        }
    }
}
