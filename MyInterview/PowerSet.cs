using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class PowerSet
    {
        static List<List<int>> GetPowerSet(int[] array)
        {
	        int power = Convert.ToInt32(Math.Pow(2, array.Length));
	        List<List<int>> result = new List<List<int>>();
	        for (int i = 0; i < power; i++)
            {
		        result.Add(CreateSet(i, array));
            }

	        return result;
        }

        static List<int> CreateSet(int i, int[] array)
        {
	        List<int> set = new List<int>();
	        int mask = 1;
	        int shift = 0;
	        while(shift < array.Length)
	        {
	            if((i & mask) > 0)
		        set.Add(array[array.Length - 1 - shift]);
                
                i  = i >> 1;
                shift++;
            }

            return set;
        }

        public static void UnitTest()
        {
            foreach (var v in GetPowerSet(new int[] { 1, 2, 3, 4, 5 }))
            {
                foreach (var e in v)
                {
                    Console.Write(e);
                    Console.Write(" ");
                }

                Console.Write("\n");
            }
        }
    }
}
