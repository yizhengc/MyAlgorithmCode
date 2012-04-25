using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class ArraySubsets
    {
        static List<List<int>> FindSubarray(Tuple<int, int>[] array, int start, int k)
        {
            if (k == 0 || start >= array.Length || array.Length - start < k)
                return null;

            List<List<int>> ret = new List<List<int>>();
            /*
            for (int j = 0; j <= array[start].Item2; j++)
            {
                List<List<int>> result = FindSubarray(array, start + 1, k - j);

                if (j == 0 && result == null)
                    continue;
                else if (result == null)
                {
                    result = new List<List<int>>(){new List<int>(}
                }


                ret.AddRange(result);
            }
            */
            return ret;
        }
        
        static List<List<int>> FindSubset(int[] array, int k)
        {
            if (array == null || array.Length == 0 || k == 0 || k > array.Length)
                return null;

            if (k == array.Length)
                return new List<List<int>>(){new List<int>(array)};
            
            List<List<int>> set = new List<List<int>>();
            set.Add(new List<int>() { array[0] });
            set.Add(new List<int>());

            int setStart = 0;

            for (int i = 1; i < array.Length; i++)
            {
                int oldCount = set.Count;
                for (int j = setStart; j < oldCount; )
                {
                    int maxLen = set[j].Count + array.Length - i;

                    if (maxLen < k)
                        setStart += 1;
                    else if (maxLen == k)
                    {
                        set[j].AddRange(new List<int>(array).GetRange(i, array.Length - i));
                        j++;
                    }
                    else if (set[j].Count < k)
                    {
                        List<int> lst = new List<int>(set[j]);
                        lst.Add(array[i]);
                        set.Add(lst);
                        j++;
                    }
                    else
                        j++;
                }
            }

            set.RemoveRange(0, setStart);
            return set;
        }

        static Tuple<int, int>[] MakeArrayCount(int[] array)
        {
            if (array == null || array.Length == 0)
                return null;

            int last = array[0];
            int lastCnt = 1;

            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == last)
                {
                    lastCnt++;
                }
                else
                {
                    result.Add(new Tuple<int, int>(last, lastCnt));
                    last = array[i];
                    lastCnt = 1;
                }
            }

            result.Add(new Tuple<int, int>(last, lastCnt));

            return result.ToArray();
        }

        static int[] MakeUniqueArray(int[] array)
        {
            // Preprocessing to make array into distinct set.
            if (array == null || array.Length == 0)
                return null;

            List<int> ary = new List<int>(array);
            ary.Sort();

            for (int i = 1; i < ary.Count; )
            {
                if (ary[i] == ary[i - 1])
                {
                    ary.RemoveAt(i);
                }
                else
                    i++;
            }

            return ary.ToArray();
        }

        public static void UnitTes()
        {
            int[] array = new int[] { 0, 1, 1, 3, 5, 5, 8, 9 };

            List<List<int>> lst = FindSubarray(MakeArrayCount(array), 0, 4);

            List<List<int>> lst2 = FindSubset(MakeUniqueArray(array), 4);

            foreach (var list in lst)
            {
                foreach (var c in list)
                {
                    Console.Write(c);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }


        }
    }
}
