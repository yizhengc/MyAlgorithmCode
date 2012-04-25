using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class ReconstructBST
    {
        static TreeNode<int> Reconstruct(int[] inOrder, int s1, int e1, int[] preOrder, int s2, int e2)
        {
            if (e1 - s1 != e2 - s2)
                throw new Exception();

            TreeNode<int> root;

            int toFind = preOrder[s2];
            int rootIndex = -1;
            for (int i = s1; i <= e1; i++)
            {
                if (inOrder[i] == preOrder[s2])
                    rootIndex = i;
            }

            if (rootIndex == -1 || rootIndex >= inOrder.Length)
                throw new Exception();

            root = new TreeNode<int>(inOrder[rootIndex]);

            if (rootIndex - 1 < s1)
                root.Left = null;
            else
                root.Left = Reconstruct(inOrder, s1, rootIndex - 1, preOrder, s2 + 1, s2 + 1 + (rootIndex - 1 - s1));

            if (rootIndex + 1 > e1)
                root.Right = null;
            else
                root.Right = Reconstruct(inOrder, rootIndex + 1, e1, preOrder, s2 + 1 + (rootIndex - 1 - s1) + 1, e2);

            return root;
        }

        public static void UnitTest()
        {
            int[] inOrder = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] preOrder = new int[] { 4, 1, 2, 3, 5, 6};

            TreeNode<int> root = Reconstruct(inOrder, 0, 5, preOrder, 0, 5);
        }
    }
}
