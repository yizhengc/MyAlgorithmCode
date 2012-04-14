using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    public class Node
    {
        public int Value;
        public Node Next;
    }

    public class LinkedListUtil
    {
        public static Node CreateLinkListFromArray(int[] values)
        {
            Node head = new Node();
            Node current = head;

            for (int i = 0; i < values.Length; i++)
            {
                current.Next = new Node();
                current.Next.Value = values[i];
                current = current.Next;
            }

            current.Next = null;
            return head.Next;
        }

        public static Node RevertLinkList(Node head)
        {
            if (head == null)
                return null;

            Node prev = null;
            Node current = head;
            Node next = head.Next;

            while (next != null)
            {
                current.Next = prev;
                prev = current;
                current = next;
                next = next.Next;
            }

            current.Next = prev;

            return current;
        }

        public static Node Delete(Node head, int value)
        {
            if (head == null)
                return null;

            if (head.Value == value)
                return head.Next;

            Node cur = head;

            while (cur != null && cur.Next != null && cur.Next.Value != value)
            {
                cur = cur.Next;
            }

            if (cur != null && cur.Next != null && cur.Next.Value == value)
                cur.Next = cur.Next.Next;

            return head;
        }

        public Node PushFront(Node head, Node node)
        {
            node.Next = head;
            head = node;

            return head;
        }

        public void PushEnd(Node tail, Node node)
        {
            tail.Next = node;
            tail = tail.Next;
            tail.Next = null;
        }

        public static void PrintLinkedList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.Value);
                Console.Write(" ");
                head = head.Next;
            }

            Console.Write("\n");
        }

        public static void UnitTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            Node head = LinkedListUtil.CreateLinkListFromArray(array);

            head = LinkedListUtil.RevertLinkList(head);

            PrintLinkedList(head);

            Node newHead = Delete(head, 3);

            PrintLinkedList(newHead);
        }
    }
}
