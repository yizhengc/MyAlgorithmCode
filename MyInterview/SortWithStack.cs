using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class SortWithStack
    {
        // Keypoint r is always ascending.
        // r will need to pop up everything until the one smaller than the one to add.
        static Stack<int> SortStack(Stack<int> stack)
        {
            Stack<int> r = new Stack<int>();

            while (!stack.IsEmpty())
            {
                int t = stack.Pop();

                while (!r.IsEmpty() && r.Top() > t)
                    stack.Push(r.Pop());

                r.Push(t);
            }

            return r;
        }
    }
}
