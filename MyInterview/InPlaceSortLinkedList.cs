using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    /// <summary>
    /// 1->9->3->8->5->7->7->6
    /// In place sort it ascending order
    /// </summary>
    class InPlaceSortLinkedList
    {
        static Node<int> Sort(Node<int> head)
        {
            if (head == null || head.Next == null)
                return head;

            Node<int> head2 = null;
            Node<int> cur = head.Next;
            Node<int> tail = head;

            while (cur != null)
            {
                if (cur.Next == null)
                {
                    cur.Next = head2;
                    head2 = cur;
                    cur = null;
                }
                else
                {
                    tail.Next = cur.Next;
                    tail = tail.Next;
                    Node<int> tmp = cur.Next.Next;
                    cur.Next = head2;
                    head2 = cur;
                    cur = tmp;
                }
            }

            tail.Next = null;

            return MergeSortedLinkedList(head, head2);
        }

        static Node<int> MergeSortedLinkedList(Node<int> head, Node<int> head2)
        {
            Node<int> cur2 = head2;
            Node<int> cur = head;
            Node<int> tail = null;

            while (cur != null && cur2 != null)
            {
                Node<int> selected = null;
                if (cur.Value < cur2.Value)
                {
                    selected = cur;
                    cur = cur.Next;
                }
                else
                {
                    selected = cur2;
                    cur2 = cur2.Next;
                }

                if (tail == null)
                {
                    head = tail = selected;
                }
                else
                {
                    tail.Next = selected;
                    tail = tail.Next;
                }
            }

            if (cur != null)
            {
                tail.Next = cur;
            }
            else
            {
                tail.Next = cur2;
            }

            return head;
        }

        public static void UnitTest()
        {
            Node<int> node = LinkedListUtil.CreateLinkListFromArray(new int[]{1, 9, 3, 8, 5, 7, 7, 6});
            node = Sort(node);

            LinkedListUtil.PrintLinkedList(node);
        }
    }
}
