using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class Queue<T>
    {
        private List<T> array;
        int head;
        int tail;

        public Queue(int size)
        {
            array = new List<T>(size);
            head = 0;
            tail = -1;
        }

        public void Push(T element)
        {
            array.Add(element);

            tail++;
        }

        public T Pop()
        {
            return IsEmpty() ? default(T) : array[head++];
        }

        public T Head()
        {
            return IsEmpty() ? default(T) : array[head];
        }

        public bool IsEmpty()
        {
            return tail < head;
        }
    }
}
