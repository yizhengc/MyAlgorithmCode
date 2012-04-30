using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class BinarySearchTree<T>
    {
        // Tree depth
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

        // Maximum width
        static int Width(TreeNode<int> node)
        {
            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>(8);

            int width = 0;
            int maxWidth = 0;

            TreeNode<int> tail = null;
            queue.Push(node);

            while (!queue.IsEmpty())
            {
                TreeNode<int> e = queue.Pop();
                
                // Keypoint: don't forget to add width
                width++;
                
                if (e.Parent == tail && (e.Parent == null || e.Parent.Right == null || e == e.Parent.Right))
                {
                    if (width > maxWidth)
                    {
                        maxWidth = width;
                    }

                    // Don't forget to reset width.
                    width = 0;
                    tail = e;
                }

                if (e.Left != null)
                    queue.Push(e.Left);

                if (e.Right != null)
                    queue.Push(e.Right);
            }

            return maxWidth;
        }

        // Print tree row by row
        static void PrintTreeByLevel(TreeNode<int> node)
        {
            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>(8);

            TreeNode<int> tail = null;
            queue.Push(node);

            while (!queue.IsEmpty())
            {
                TreeNode<int> e = queue.Pop();

                Console.Write(e.Value);
                

                if (e.Parent == tail && (e.Parent == null || e.Parent.Right == null || e == e.Parent.Right))
                {
                    tail = e;
                    Console.Write("\n");
                }
                else
                    Console.Write(" ");

                if (e.Left != null)
                    queue.Push(e.Left);

                if (e.Right != null)
                    queue.Push(e.Right);
            }
        }

        static TreeNode<T> InorderSuccessor(TreeNode<T> node)
        {
            if (node == null)
                return null;

            // if node is root
            if (node.Right != null)
            {
                node = node.Right;
                while (node.Left != null)
                    node = node.Left;

                return node;
            }

            // node is not root but it's a left child of its parent.
            /* 
             if (node.Parent.Left == node)
                return node.Parent;
             * The logic below wil covers this */
            // node is not root, but it's a right child of its parent.
            while (node.Parent != null && node == node.Parent.Right)
                node = node.Parent;

            // Given node is the right most node
            /* 
            if (node.Parent == null)
                return null;
            else
                return node.Parent;
            Above code can be rewritten as*/
            return node.Parent;
        }

        static TreeNode<T> Predecessor(TreeNode<T> node)
        {
            if (node.Left != null)
            {
                node = node.Left;

                while (node.Right != null)
                    node = node.Right;

                return node;
            }
            else
            {
                while (node.Parent != null && node.Parent.Left == node)
                    node = node.Parent;

                return node.Parent;
            }
        }

        static TreeNode<T> Delete(TreeNode<T> root, TreeNode<T> target)
        {
            if (target.Left == null)
            {
                if (target.Parent == null)
                    return target.Right;
                else if (target == target.Parent.Left)
                    target.Parent.Left = target.Right;
                else
                    target.Parent.Right = target.Right;
            }
            else if (target.Right == null)
            {
                if (target.Parent == null)
                    return target.Left;
                else if (target == target.Parent.Left)
                    target.Parent.Left = target.Left;
                else
                    target.Parent.Right = target.Left;
            }
            else
            {
                TreeNode<T> successor = InorderSuccessor(target);

                if (successor == target.Right)
                {
                    successor.Left = target.Left;
                    if (target.Parent == null)
                        return successor;
                    else if (target == target.Parent.Left)
                        target.Parent.Left = successor;
                    else
                        target.Parent.Right = successor;
                }
                else
                {

                }
            }

            return root;
        }

        public static void UnitTest()
        {
            TreeNode<int> root = TreeUtil.CreateTreeFromSortedArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8}, 0, 7);

            root.Left.Right.Right = root.Right;
            root.Right.Parent = root.Left.Right;
            root.Right = null;

            PrintTreeByLevel(root);
            Console.Write("Depth: {0}, Width: {1}", BinarySearchTree<int>.Depth(root), BinarySearchTree<int>.Width(root));

            root.Value = 9;
            TreeNode<int> successor = BinarySearchTree<int>.InorderSuccessor(root.Left);
        }
    }
}
