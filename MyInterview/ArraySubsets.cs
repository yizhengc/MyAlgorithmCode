using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class ArraySubsets
    {
        static List<List<int>> FindSubset(int[] array, int k)
        {
            // Preprocessing to make array into distinct set.
            if (array == null || k == 0 || array.Length == 0)
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

            array = ary.ToArray();

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

        public static void UnitTes()
        {
            int[] array = new int[] { 0, 1, 1, 3, 5, 5, 8, 9 };

            List<List<int>> lst = FindSubset(array, 4);

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
