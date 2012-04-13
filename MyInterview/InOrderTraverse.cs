using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class InOrderTraverse
    {
        static void InOrderTraverseLoop(TreeNode<int> root)
        {
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();

            TreeNode<int> cur = root;

            while (cur != null)
            {
                if (cur.Visited == false && cur.Left != null)
                {
                    stack.Push(cur);
                    cur = cur.Left;
                    continue;
                }

                Console.Write(cur.Value);
                Console.Write(" ");

                if (cur.Right != null)
                {
                    cur = cur.Right;
                    continue;
                }

                if (!stack.IsEmpty())
                {
                    cur = stack.Pop();
                    cur.Visited = true;
                }
                else
                    cur = null;
            }
        }

        public static void UnitTest()
        {
            TreeNode<int> root = TreeUtil.CreateTreeFromSortedArray(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 5);

            InOrderTraverseLoop(root);
        }
    }
}
