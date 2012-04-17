using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MyInterview
{
    class Expression
    {
        static int VerifyExpression(string s)
        {
            Stack<char> stack = new Stack<char>();

            int err = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    if (stack.Size() == 1 || stack.Size() == 0)
                    {
                        err += 1;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(s[i]);
                }
            }

            if (stack.Size() == 1)
                return err;
            else
                return err + stack.Size() / 2;
        }

        public static void UnitTest()
        {
            string test1 = "x";
            Debug.Assert(VerifyExpression(test1) == 0);

            test1 = "xx*";
            Debug.Assert(VerifyExpression(test1) == 0);

            test1 = "xxx**";
            Debug.Assert(VerifyExpression(test1) == 0);

            test1 = "*xx";
            Debug.Assert(VerifyExpression(test1) == 2);

            test1 = "xx*xx**";
            Debug.Assert(VerifyExpression(test1) == 0);

            test1 = "xx*xx*xx";
            Debug.Assert(VerifyExpression(test1) == 2);
        }
    }
}
