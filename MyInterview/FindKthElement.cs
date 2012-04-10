using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class OrderStatistics
    {
        static int FindKthElement(TreeNode node, int count, int k, ref int val)
        {
            if (node.Left != null)
                count = FindKthElement(node.Left, count, k, ref val);

            if (count == k - 1)
                val = node.Value;

            count++;

            if (count < k && node.Right != null)
                count = FindKthElement(node.Right, count, k, ref val);

            return count;
        }

        public static void UnitTest()
        {
            TreeNode root = TreeUtil.CreateTreeFromSortedArray(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 5);
            int val = -1;
            FindKthElement(root, 0, 3, ref val);

            Console.WriteLine(val);
        }
    }
}
