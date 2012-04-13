using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class Range
    {
        public int Left;
        public int Right;

        public Range(int left, int right)
        {
            Left = left;
            Right = right;
        }
    }

    class RangeBinarySearchTree
    {
        public static TreeNode<Range> InsertRangeNode(TreeNode<Range> root, Range range)
        {
            if (root == null)
                return new TreeNode<Range>(range);

            if (range.Left > root.Value.Right)
            {
                if (root.Right != null)
                    root.Right = InsertRangeNode(root.Right, range);
                else
                    root.Right = new TreeNode<Range>(range);
            }
            else if (range.Right < root.Value.Left)
            {
                if (root.Left != null)
                    root.Left = InsertRangeNode(root.Left, range);
                else
                    root.Left = new TreeNode<Range>(range);
            }
            else
            {
                if (root.Value.Left > range.Left)
                {
                    root.Value.Left = range.Left;
                    if (root.Left != null)
                        root.Left = InsertToLeft(root.Left, root);
                }

                if (root.Value.Right < range.Right )
                {
                    root.Value.Right = range.Right;
                    if (root.Right != null)
                        root.Right = InsertToRight(root.Right, root);
                }
            }

            return root;
        }

        static TreeNode<Range> InsertToLeft(TreeNode<Range> root, TreeNode<Range> master)
        {
            if (master.Value.Left > root.Value.Right)
            {
                if (root.Right != null)
                {
                    root.Right = InsertToLeft(root.Right, master);
                }

                return root;
            }

            master.Value.Left = Math.Min(root.Value.Left, master.Value.Left);

            return root.Left == null ? null : InsertToLeft(root.Left, master);
        }

        static TreeNode<Range> InsertToRight(TreeNode<Range> root, TreeNode<Range> master)
        {
            if (master.Value.Right < root.Value.Left)
            {
                if (root.Left != null)
                {
                    root.Left = InsertToLeft(root.Left, master);
                }

                return root;
            }

            master.Value.Right = Math.Max(root.Value.Right, master.Value.Right);

            return root.Right == null ? null : InsertToRight(root.Right, master);
        }

        public static void UnitTest()
        {
            TreeNode<Range> root = InsertRangeNode(null, new Range(6, 7));
            InsertRangeNode(root, new Range(2, 3));
            InsertRangeNode(root, new Range(0, 1));
            InsertRangeNode(root, new Range(4, 5));
            InsertRangeNode(root, new Range(8, 9));
            InsertRangeNode(root, new Range(10, 11));

            InsertRangeNode(root, new Range(3, 8));
        }
    }
}
