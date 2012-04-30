using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class MovePeople
    {
        static bool IsDiffByOneBit(int a, int b, out int shift)
        {
            int result = a ^ b;

            shift = 0;
            // Keypoint: check result > 0, otherwise a b are the same.
            while (result > 0 && (result & 1) == 0)
            {
                shift++;
                result = result >> 1;
            }

            return result == 1;
        }

        static List<Tuple<int, int>> Move(int n)
        {
            int count = Convert.ToInt32(Math.Pow(2, n));
            bool[] consumed = new bool[count];

            List<Tuple<int, int>> steps = new List<Tuple<int, int>>();

            int k = 0;
            int cur = 0;
            while (k < count)
            {
                // Keypoint: Start with 1 instead of 0
                for (int i = 1; i < consumed.Length; i++)
                {
                    int shift; 
                    if (consumed[i] == false && IsDiffByOneBit(cur, i, out shift))
                    {
                        steps.Add(new Tuple<int, int>(cur, shift));
                        cur = i;
                        // Keypoint: Remember to set to true.
                        consumed[i] = true;
                        break;
                    }
                }

                k++;
            }

            return steps;
        }

        public static void UnitTest()
        {
            List<Tuple<int, int>> result = Move(3);

            foreach (var r in result)
            {
                Console.WriteLine("From {0} : Move {1}", r.Item1, r.Item2);
            }
        }
    }
}
