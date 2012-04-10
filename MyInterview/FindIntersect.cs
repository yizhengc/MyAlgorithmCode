using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class ArrayUtility
    {
        public static List<int> FindIntersect(List<int> lst1, List<int> lst2)
        {
            List<int> result = new List<int>();
            int i = 0;
            int j = 0;
            while (i < lst1.Count && j < lst2.Count)
            {
                if (lst1[i] < lst2[j])
                {
                    i++;
                }
                else if (lst1[i] > lst2[j])
                {
                    j++;
                }
                else
                {
                    result.Add(lst1[i]);
                    i++;
                    j++;
                }
            }

            return result;
        }

        public static void UnitTest()
        {
            List<int> lst1 = new List<int>() { 1, 2, 3, 4, 5};
            List<int> lst2 = new List<int>() { 2, 3, 6, 7 };

            List<int> result = FindIntersect(lst1, lst2);

            foreach (int e in result)
            {
                Console.Write(e);
                Console.Write(" ");
            }

            Console.Write("\n");
        }
    }
}
