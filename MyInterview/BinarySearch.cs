using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class BinarySearch
    {
        public static int SearchInRotatedArray(int[] array, int target, int l, int h)
        {
            while (l <= h)
            {
                int m = (l + h) / 2;

                if (target == array[m])
                    return m;
                else if (array[l] <= array[m])
                {
                    if (target > array[m])
                        l = m + 1;
                    else if (target >= array[l])
                        h = m - 1;
                    // Keypoint: if target is smaller than left bound, it must be on the right half. 
                    else
                        l = m + 1;
                }
                else if (target < array[m])
                    h = m - 1;
                else if (target <= array[h])
                    l = m + 1;
                // Keypoint: if target is larger than right bound, it must be on the left half. 
                else
                    h = m - 1;
            }

            return -1;
        }



    }
}
