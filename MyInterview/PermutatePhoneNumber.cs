using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class Permutation
    {
        static Dictionary<char, char[]> numbers = 
        new Dictionary<char, char[]>(){
        {'2', new char[]{'a', 'b', 'c'}},
        {'3', new char[]{'d', 'e', 'f'}},
        {'4', new char[]{'g', 'h', 'i'}},
        {'5', new char[]{'j', 'k', 'l'}},
        {'6', new char[]{'m', 'n', 'o'}},
        {'7', new char[]{'p', 'q', 'r', 's'}},
        {'8', new char[]{'t', 'u', 'v'}},
        {'9', new char[]{'w', 'x', 'y', 'z'}}
        };

        static int PermutatePhoneNumber(string phoneNumber)
        {
            List<string> cache = new List<string>();  
    
            int totalPermutate = 0;  
            for(int i = 0; i < phoneNumber.Length; i++)
            {
                totalPermutate = 0;
                if (numbers.ContainsKey(phoneNumber[i]))
                {
                    int cacheSize = cache.Count;
                    foreach(char c in numbers[phoneNumber[i]])
                    {
                        if (cacheSize == 0)
                        {
                            cache.Add(c.ToString());
                            totalPermutate++;
                        }
                        else
                        {
                            for(int j = 0; j < cacheSize; j++)
                            {
                                cache.Add(cache[j] + c.ToString());
                                totalPermutate++;
                            }
                        }
                    }

                    cache.RemoveRange(0, cache.Count - totalPermutate);
                }
                else if (cache.Count == 0)
                {
                    cache.Add(phoneNumber[i].ToString());
                    totalPermutate++;
                }
                else
                {
                    for(int j = 0; j < cache.Count; j++)
                    {
                        cache[j] = cache[j] + phoneNumber[i].ToString();
                        totalPermutate++;
                    }
                }
            }
                
            for(int i = cache.Count - 1; i >= cache.Count - totalPermutate; i--)
            {
                Console.WriteLine(cache[i]);
            }

            Console.WriteLine("Total Permutation is {0}", totalPermutate);

            return totalPermutate;
        }

        public static void UnitTest()
        {
            string phoneNumber = "14257491028";
            int actualPermutations = PermutatePhoneNumber(phoneNumber);

            int expectedPermutations = 1;

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (numbers.ContainsKey(phoneNumber[i]))
                {
                    expectedPermutations *= numbers[phoneNumber[i]].Length;
                }
            }

            if (actualPermutations == expectedPermutations)
            {
                Console.WriteLine("Result validated correct");
            }
        }
    }
}
