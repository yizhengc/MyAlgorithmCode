using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class MergeLinkedList
    {
        static Node<int> MergeSort(Node<int> lst1, Node<int> lst2)
        {
            // Create a dummy node header
            Node<int> head = new Node<int>();

            if (lst1 == null)
                head = lst2;
            else if (lst2 == null)
                head = lst1;
            else
            {
                Node<int> cur = head;

                while (lst1 != null && lst2 != null)
                {
                    if (lst1.Value < lst2.Value)
                    {
                        cur.Next = lst1;
                        lst1 = lst1.Next;
                    }
                    else
                    {
                        cur.Next = lst2;
                        lst2 = lst2.Next;
                    }

                    cur = cur.Next;
                }

                if (lst1 != null)
                    cur.Next = lst1;
                else
                    cur.Next = lst2;
            }

            return head.Next;
        }

        public static void UnitTest()
        {
            LinkedListUtil.PrintLinkedList(MergeSort(LinkedListUtil.CreateLinkListFromArray(new int[]{0, 2, 4, 5, 7, 9}), 
                LinkedListUtil.CreateLinkListFromArray(new int[]{1, 3, 6, 8, 11})));
        }
    }
}
