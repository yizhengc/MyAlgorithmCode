using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class FindLargestAreaRectangleUnderHistogram
    {
        static Tuple<int, int>[] FindNearestSmallerValues(int[] array, bool r2l)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int,int>>();
            Tuple<int, int>[] result = new Tuple<int, int>[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                int index = r2l ? array.Length - 1 - i : i;

                while(!stack.IsEmpty() && stack.Top().Item1 >= array[index])
                    stack.Pop();
                
                if (!stack.IsEmpty())
                    result[index] = stack.Top();
                else
                    result[index] = new Tuple<int, int>(-1, -1);
        
                stack.Push(new Tuple<int, int>(array[index], index));
            }
    
            return result;
        }

        static int FindLargestAreaRectangle(int[] histogram)
        {
            Tuple<int, int>[] nearestSmallerValuesToTheLeft = FindNearestSmallerValues(histogram, false);
            Tuple<int, int>[] nearestSmallerValuesToTheRight = FindNearestSmallerValues(histogram, true);

            int maxArea = 0;

            for (int i = 0; i < histogram.Length; i++)
            {
                int area = 0;
                if (nearestSmallerValuesToTheLeft[i].Item1 == -1)
                {
                    area += histogram[i] * (1 + i);
                }
                else
                {
                    area += histogram[i] * (i - nearestSmallerValuesToTheLeft[i].Item2);
                }

                if (nearestSmallerValuesToTheRight[i].Item1 == -1)
                {
                    area += histogram[i] * (histogram.Length - i);
                }
                else
                {
                    area += histogram[i] * (nearestSmallerValuesToTheRight[i].Item2 - i);
                }

                area -= histogram[i];

                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

            return maxArea;
        }

        public static void UnitTest()
        {
            int[] histogram = new int[] { 1, 5, 3, 4, 9, 7, 8 };

            Console.WriteLine(FindLargestAreaRectangle(histogram));
        }
    }
}
