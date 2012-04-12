using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class BST2DLLConversion
    {
        static TreeNode<int> ConvertBST2DLL(TreeNode<int> root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode<int> tail;

            return ConvertBST2DLL(root, out tail);
        }

        static TreeNode<int> ConvertBST2DLL(TreeNode<int> root, out TreeNode<int> tail)
        {
            // No null root will be passed in. So no need to check

            // Handle head.
            TreeNode<int> head;

            if (root.Left == null)
            {
                head = root;
            }
            else
            {
                head = ConvertBST2DLL(root.Left, out tail);
                tail.Right = root;
                root.Left = tail;
            }
            
            // Handle tail.
            if (root.Right == null)
            {
                tail = root;
            }
            else
            {
                root.Right = ConvertBST2DLL(root.Right, out tail);
                root.Right.Left = root;
            }

            // clean up tail end
            tail.Right = null;

            return head;
        }

        static TreeNode<int> ConvertDLL2BST(TreeNode<int> root)
        {
            TreeNode<int> cur = root;
            int size = 0;
            while (cur != null)
            {
                size++;
                cur = cur.Right;
            }

            if (size == 0)
                return null;
            
            TreeNode<int> tail;

            return ConvertDLL2BST(root, size, out tail);
        }

        static TreeNode<int> ConvertDLL2BST(TreeNode<int> head, int size, out TreeNode<int> tail)
        {
            TreeNode<int> root = null;
            // Handle smallest unit
            if (size == 1)
            {
                tail = head.Right;
                head.Left = null;
                head.Right = null;
                root = head;
            }
            else
            {
                // left will never be 0 because input size at this stage won't be 0 or 1
                int left = size / 2;
                int right = size - left - 1;

                TreeNode<int> Left = ConvertDLL2BST(head, left, out tail);

                // tail won't be null as we always reserve 1 for the root
                root = tail;
                root.Left = Left;

                if (right != 0)
                {
                    root.Right = ConvertDLL2BST(tail.Right, right, out tail);
                }
                else
                {
                    root.Right = null;
                }
            }

            return root;
        }

        public static void UnitTest()
        {
            TreeNode<int> root = TreeUtil.CreateTreeFromSortedArray(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 5);

            TreeNode<int> tail;
            TreeNode<int> head = ConvertBST2DLL(root, out tail);
            TreeNode<int> cur = head;
            while (cur != null)
            {
                Console.Write(cur.Value);
                Console.Write(" ");
                cur = cur.Right;
            }

            Console.WriteLine();

            root = ConvertDLL2BST(head);

            head = ConvertBST2DLL(root, out tail);

            while (head != null)
            {
                Console.Write(head.Value);
                Console.Write(" ");
                head = head.Right;
            }

            Console.WriteLine();
        }
    }
}
