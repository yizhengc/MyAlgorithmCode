using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class MergeArrays
    {
        // Merge array A into B when A has size N B has size 2N. Both sorted
        static void MergeTwoArrays(int[] array1, int elementCnt, int[] array2)
        {
            if (array1.Length < elementCnt + array2.Length)
            {
                Console.WriteLine("Buffer size is smaller than total element count");
                return;
            }

            int idx1 = elementCnt - 1;
            int idx2 = array2.Length - 1;
            int index = array1.Length - 1;

            while (idx2 >= 0)
            {
                if (idx1 >= 0 && array1[idx1] > array2[idx2])
                {
                    array1[index--] = array1[idx1--];
                }
                else
                {
                    array1[index--] = array2[idx2--];
                }
            }
        }

        public static void UnitTest()
        {
            int[] array1 = new int[] { 1, 3, 5, 6, 8, 0, 0, 0 };
            int[] array2 = new int[] { -2, 0, 9 };

            MergeTwoArrays(array1, 5, array2);

            foreach (int i in array1)
            {
                Console.Write(i);
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}
