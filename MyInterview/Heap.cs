using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class Heap<T>
    {
        List<T> array;

        delegate int Compare(T a, T b);

        Compare comparer;

        void MaxHeapify(int root)
        {
            if (root < 0 || root >= array.Count)
                return;

            int larger = -1;
            
            if (comparer(array[Left(root)], array[root]) > 0)
                larger = Left(root);

            if (comparer(array[Right(root)], array[larger]) > 0)
                larger = Right(root);

            if (larger != -1)
            {
                T temp = array[root];
                array[root] = array[larger];
                array[larger] = temp;
                MaxHeapify(larger);
            }
        }

        int Parent(int n)
        {
            return (n - 1) / 2;
        }

        int Left(int n)
        {
            return 2 * n + 1;
        }

        int Right(int n)
        {
            return 2 * n + 2;
        }

        public void Insert(T value)
        {
            array.Add(value);
            int idx = array.Count - 1;

            int parent = Parent(idx);
            while (parent >= 0 && comparer(array[parent], array[idx]) < 0)
            {
                T temp = array[parent];
                array[parent] = array[idx];
                idx = parent;
            }
        }
    }
}
