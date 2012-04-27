using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyInterview
{
    public class TreeNode<T>
    {
        public T Value;
        public bool Visited;
        public TreeNode<T> Left;
        public TreeNode<T> Right;
        public TreeNode<T> Parent;

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

            if (root.Left != null)
                root.Left.Parent = root;

            root.Right = CreateTreeFromSortedArray(array, mid + 1, high);

            if (root.Right != null)
                root.Right.Parent = root;

            return root;
        }

        static void SerializeTree(TreeNode<char> root, StringBuilder bw)
        {
            bw.Append(root.Value);
            if (root.Left != null)
                SerializeTree(root.Left, bw);
            else
                bw.Append('L');

            if (root.Right != null)
                SerializeTree(root.Right, bw);
            else
                bw.Append('L');
        }

        static TreeNode<char> DeserializeTree(string s, ref int start)
        {
            TreeNode<char> root = null;
            if (start < s.Length && s[start] != 'L')
            {
                root = new TreeNode<char>(s[start]);
                start += 1;
                if (start < s.Length)
                {
                    if (s[start] != 'L')
                        root.Left = DeserializeTree(s, ref start);
                    else
                    {
                        root.Left = null;
                        // Key point here. Don't forget add 1
                        start += 1;
                    }

                    if (start < s.Length)
                    {
                        if (s[start] != 'L')
                            root.Right = DeserializeTree(s, ref start);
                        else
                        {
                            root.Right = null;
                            // Key point here. Don't forget add 1
                            start += 1;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();// data is corrupted
                }

                return root;
            }
            else
            {
                throw new Exception();
            }
        }

        public static void UnitTest()
        {
            TreeNode<char> root = CreateTreeFromSortedArray(new char[] { '0', '1', '3', '5', '6', '7'}, 0, 5);

            StringBuilder sb = new StringBuilder();
            SerializeTree(root, sb);

            int start = 0;
            root = DeserializeTree(sb.ToString(), ref start);
        }
    }
}
