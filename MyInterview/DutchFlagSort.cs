using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class DutchFlagSort
    {
        static void Sort(int[] array)
        {
            int start = 0;
            int end = array.Length;

            for (int i = 0; i < end; )
            {
                if (array[i] < 1)
                {
                    if (start != i)
                    {
                        int temp = array[start];
                        array[start] = array[i];
                        array[i] = temp;
                    }

                    i++;
                    start++;
                }
                else if (array[i] > 1)
                {
                    int temp = array[--end];
                    array[end] = array[i];
                    array[i] = temp;
                }
                else
                    i++;
            }
        }

        public static void UnitTest()
        {
            int[] array = new int[] { 0, 1, 0, 1, 2, 2, 1, 0, 1, 2 };

            Sort(array);
        }
    }
}
