using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    enum Color
    {
        White,
        Grey,
        Black
    }

    class Vertex
    {
        public Vertex Parent;
        public Color Status;
        public char Key;
        public int Distance;
        public Vertex[] Neighbors;
    
        public Vertex(char key)
        {
            Key = key;
            Parent = null;
            Status = Color.White;
            Distance = 0;
        }

        public override string ToString()
        {
            return Key.ToString();
        }
    }

    class Edge
    {
        public Vertex Start;
        public Vertex End;
        public int Weight;

        public Edge()
        {
            Start = End = null;
            Weight = 1;
        }
    }

    class Graph
    {
        public static Dictionary<char, Vertex> CreateGraph(Dictionary<char, char[]> map)
        {
            Dictionary<char, Vertex> vertexes = new Dictionary<char, Vertex>();
            foreach (char key in map.Keys)
            {
                vertexes.Add(key, new Vertex(key));
            }

            foreach (KeyValuePair<char, char[]> kvp in map)
            {
                Vertex[] neighbors = new Vertex[kvp.Value.Length];

                int idx = 0;
                foreach (char key in kvp.Value)
                {
                    neighbors[idx++] = vertexes[key];
                }

                vertexes[kvp.Key].Neighbors = neighbors;
            }

            return vertexes;
        }

        public static int ShortestPath(Vertex start, Vertex end)
        {
            Queue<Vertex> queue = new Queue<Vertex>(10);

            if (start == null || end == null)
                return 0;

            start.Status = Color.Grey;
            queue.Push(start);

            Vertex cur = null;
            while (!queue.IsEmpty())
            {
                cur = queue.Pop();
                if (cur == end)
                {
                    break;
                }

                foreach (Vertex v in cur.Neighbors)
                {
                    if (v.Status == Color.White)
                    {
                        v.Status = Color.Grey;
                        v.Parent = cur;
                        v.Distance = cur.Distance + 1;
                        queue.Push(v);
                    }
                }

                cur.Status = Color.Black;
            }

            if (cur.Parent == null)
                return 0;
            else
                return cur.Parent.Distance + 1;
        }

        public static void UnitTest()
        {
            Dictionary<char, Vertex> vertexes = Graph.CreateGraph(
                new Dictionary<char, char[]>(){
                    {'a', new char[]{'b', 'c'}},
                    {'b', new char[]{'a', 'd'}},
                    {'c', new char[]{'a', 'd'}},
                    {'d', new char[]{'b', 'c', 'e', 'f'}},
                    {'e', new char[]{'d', 'f'}},
                    {'f', new char[]{'d', 'e'}}
                });

            int distance = Graph.ShortestPath(vertexes['a'], vertexes['f']);

            Console.WriteLine(distance);
        }
    }
}
