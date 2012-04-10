using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    public class Stack<T>
    {
        List<T> array;

        public Stack()
        {
            array = new List<T>();
        }

        public T Pop()
        {
            if (array.Count == 0)
                return default(T);

            T toPop = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);
            return toPop;
        }

        public void Push(T e)
        {
            array.Add(e);
        }

        public T Top()
        {
            return array[array.Count - 1];
        }

        public bool IsEmpty()
        {
            return array.Count == 0;
        }
    }
}
