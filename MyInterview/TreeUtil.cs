using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    public class TreeNode<T>
    {
        public T Value;
        public bool Visited;
        public TreeNode<T> Left;
        public TreeNode<T> Right;

        public TreeNode(T val)
        {
            Value = val;
            Visited = false;
            Left = Right = null;
        }
    }

    public class TreeUtil
    {
        public static TreeNode<T> CreateTreeFromSortedArray<T>(T[] array, int low, int high)
        {
            if (low > high)
                return null;

            int mid = (low + high) / 2;

            TreeNode<T> root = new TreeNode<T>(array[mid]);

            root.Left = CreateTreeFromSortedArray(array, low, mid - 1);
            root.Right = CreateTreeFromSortedArray(array, mid + 1, high);

            return root;
        }

        
    }
}
