using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class TopologicalSort
    {
        static Node<Vertex> Sort(Vertex[] vertexes)
        {
            Node<Vertex> head = null;

            foreach (Vertex v in vertexes)
            {
                if (v.Status == Color.White)
                {
                    DFS(v, ref head);
                }
            }

            return head;
        }

        static void DFS(Vertex v, ref Node<Vertex> head)
        {
            foreach (Vertex n in v.Neighbors)
            {
                if (n.Status == Color.White)
                {
                    n.Status = Color.Grey;
                    DFS(n, ref head);
                }
            }

            v.Status = Color.Black;
            Node<Vertex> node = new Node<Vertex>(v);
            node.Next = head;
            head = node;
        }

        public static void UnitTest()
        {
            Dictionary<char, Vertex> vertexes = Graph.CreateGraph(
                    new Dictionary<char, char[]>(){
                    {'a', new char[]{'b', 'c'}},
                    {'b', new char[]{'d'}},
                    {'c', new char[]{}},
                    {'d', new char[]{'g'}},
                    {'e', new char[]{'d', 'f'}},
                    {'f', new char[]{'g'}},
                    {'g', new char[]{}},
                    {'h', new char[]{'c'}},
                    {'i', new char[]{}}
                });

            Node<Vertex> head = Sort(vertexes.Values.ToArray());

            LinkedListUtil.PrintLinkedList(head);
        }
    }
}
