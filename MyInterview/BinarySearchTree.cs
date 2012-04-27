using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class BinarySearchTree<T>
    {
        static int Depth(TreeNode<T> node)
        {
            if (node.Left == null && node.Right == null)
                return 1;

            int depth = 0;
            if (node.Left == null)
                depth = Depth(node.Right);
            else if (node.Right == null)
                depth = Depth(node.Left);
            else
            {
                depth = Math.Max(Depth(node.Left), Depth(node.Right));
            }

            return depth + 1;
        }

        static int Width(TreeNode<T> node)
        {
            if (node.Left == null && node.Right == null)
                return 1;

            int depth = 0;
            if (node.Left == null)
                depth = Width(node.Right);
            else if (node.Right == null)
                depth = Width(node.Left);
            else
            {
                depth = Depth(node.Left) + Depth(node.Right);
            }

            return depth + 1;
        }

        static TreeNode<T> InorderSuccessor(TreeNode<T> node)
        {
            if (node == null)
                return null;

            // if node is root
            if (node.Parent == null)
            {
                node = node.Right;
                while (node.Left != null)
                    node = node.Left;

                return node;
            }

            // node is not root but it's a left child of its parent.
            if (node.Parent.Left == node)
                return node.Parent;

            // node is not root, but it's a right child of its parent.
            while (node.Parent != null && node == node.Parent.Right)
                node = node.Parent;

            // Given node is the right most node
            if (node.Parent == null)
                return null;
            else
                return node.Parent;
        }

        public static void UnitTest()
        {
            TreeNode<int> root = TreeUtil.CreateTreeFromSortedArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8}, 0, 7);

            Console.Write("Depth: {0}, Width: {0}", BinarySearchTree<int>.Depth(root), BinarySearchTree<int>.Width(root));
            TreeNode<int> successor = BinarySearchTree<int>.InorderSuccessor(root.Right.Right);
        }
    }
}
