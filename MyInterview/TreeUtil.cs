using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    public class TreeNode
    {
        public int Value;
        public bool Visited;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int val)
        {
            Value = val;
            Visited = false;
            Left = Right = null;
        }
    }

    public class TreeUtil
    {
        public static TreeNode CreateTreeFromSortedArray(int[] array, int low, int high)
        {
            if (low > high)
                return null;

            int mid = (low + high) / 2;

            TreeNode root = new TreeNode(array[mid]);

            root.Left = CreateTreeFromSortedArray(array, low, mid - 1);
            root.Right = CreateTreeFromSortedArray(array, mid + 1, high);

            return root;
        }

        
    }
}
