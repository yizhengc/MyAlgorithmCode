using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Next;

        public Node()
        {
        }

        public Node(T v)
        {
            Value = v;
        }
    }

    public class LinkedListUtil
    {
        public static Node<int> CreateLinkListFromArray(int[] values)
        {
            Node<int> head = new Node<int>();
            Node<int> current = head;

            for (int i = 0; i < values.Length; i++)
            {
                current.Next = new Node<int>();
                current.Next.Value = values[i];
                current = current.Next;
            }

            current.Next = null;
            return head.Next;
        }

        public static Node<int> RevertLinkList(Node<int> head)
        {
            if (head == null)
                return null;

            Node<int> prev = null;
            Node<int> current = head;
            Node<int> next = head.Next;

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

        public static Node<int> Delete(Node<int> head, int value)
        {
            if (head == null)
                return null;

            if (head.Value == value)
                return head.Next;

            Node<int> cur = head;

            while (cur != null && cur.Next != null && cur.Next.Value != value)
            {
                cur = cur.Next;
            }

            if (cur != null && cur.Next != null && cur.Next.Value == value)
                cur.Next = cur.Next.Next;

            return head;
        }

        public Node<int> PushFront(Node<int> head, Node<int> node)
        {
            node.Next = head;
            head = node;

            return head;
        }

        public void PushEnd(Node<int> tail, Node<int> node)
        {
            tail.Next = node;
            tail = tail.Next;
            tail.Next = null;
        }

        public static void PrintLinkedList<T>(Node<T> head)
        {
            while (head != null)
            {
                Console.Write(head.Value.ToString());
                Console.Write(" ");
                head = head.Next;
            }

            Console.Write("\n");
        }

        public static void UnitTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            Node<int> head = LinkedListUtil.CreateLinkListFromArray(array);

            head = LinkedListUtil.RevertLinkList(head);

            PrintLinkedList(head);

            Node<int> newHead = Delete(head, 3);

            PrintLinkedList(newHead);
        }
    }
}
