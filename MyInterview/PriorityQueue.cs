using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class PriorityQueue<T>
    {
        List<T> array = new List<T>();
        public delegate int Compare(T a, T b);

        public Compare Comparer;

        public void Push(T t)
        {
            array.Add(t);
        }

        public T Pop()
        {
            T minT = array[0];

            foreach(var t in array)
            {
                if (Comparer(t, minT) < 0)
                    minT = t;
            }

            // don't forget to delete
            array.Remove(minT);

            return minT;
        }

        public bool IsEmpty()
        {
            return array.Count == 0;
        }
    }
}
