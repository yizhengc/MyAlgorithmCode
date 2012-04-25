using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class ReverseOrderPair
    {

        static int GetReverseOrderPair(int[] array, int l, int r, int[] buf)
        {
            if (l > r || l == r)
                return 0;

            int m = (l + r) / 2;

            int ret = GetReverseOrderPair(array, l, m, buf);
            ret += GetReverseOrderPair(array, m + 1, r, buf);

            int i = l;
            int j = m + 1;
            int k = l;
            while (i <= m && j <= r)
            {
                if (array[i] > array[j])
                {
                    ret += m - i + 1;
                    buf[k++] = array[j++];
                }
                else
                {
                    buf[k++] = array[i++];
                }
            }

            while (i <= m)
                buf[k++] = array[i++];

            while (j <= r)
                buf[k++] = array[j++];

            for (k = l; k <= r; k++)
            {
                array[k] = buf[k];
            }

            return ret;
        }

        public static void UnitTest()
        {
            int[] array = new int[] { 4, 3, 5, 2, 8, 6 };
            Console.WriteLine("Total reverse pair is {0}", GetReverseOrderPair(array, 0, 5, new int[6]));
        }
    }
}
