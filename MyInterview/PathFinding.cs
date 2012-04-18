using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class PathFinding
    {
        class Point
        {
            public int X;
            public int Y;
            public int F;
            public Point P;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
                F = 0;
                P = null;
            }
        }

        static int Compare(Point a, Point b)
        {
            return a.F.CompareTo(b.F);
        }

        static int FindPath(char[,] map, int row, int col, Point start, Point end)
        {
            int[,] gscore = new int[row, col];
            int[,] fscore = new int[row, col];
            Color[,] status = new Color[row, col];

            PriorityQueue<Point> queue = new PriorityQueue<Point>();
            queue.Comparer = Compare;
            
            gscore[start.Y, start.X] = 0;
            start.F = fscore[start.Y, start.X] = Heuristic(start, end);
            queue.Push(start);
            status[start.Y, start.X] = Color.Grey;

            while (!queue.IsEmpty())
            {
                Point cur = queue.Pop();

                if (cur.X == end.X && cur.Y == end.Y)
                    return fscore[cur.Y, cur.X];

                foreach (var n in GetNeighbors(cur, map, row, col))
                {
                    if (status[n.Y, n.X] == Color.Black)
                        continue;

                    int tentative = gscore[cur.Y, cur.X] + 1;
                    bool useTentative = true;

                    if (status[n.Y, n.X] == Color.Grey && gscore[n.Y, n.X] <= tentative)
                        useTentative = false;

                    if (useTentative)
                    {
                        gscore[n.Y, n.X] = tentative;
                        n.F = fscore[n.Y, n.X] = tentative + Heuristic(n, end);
                        queue.Push(n);
                        n.P = cur;
                    }
                }
            }

            return int.MinValue;
        }

        static int Heuristic(Point cur, Point end)
        {
            return Math.Max(Math.Abs(end.Y - cur.Y), Math.Abs(end.X - cur.X));
        }

        static List<Point> GetNeighbors(Point cur, char[,] map, int row, int col)
        {
            List<Point> neighbors = new List<Point>();

            if (cur.Y - 1 >= 0 && cur.X - 1 >= 0 && map[cur.Y - 1, cur.X - 1] != 'w')
                neighbors.Add(new Point(cur.X - 1, cur.Y - 1));
            
            if (cur.Y + 1 < row && cur.X - 1 >= 0 && map[cur.Y + 1, cur.X - 1] != 'w')
                neighbors.Add(new Point(cur.X - 1, cur.Y + 1));

            if (cur.X - 1 >= 0 && map[cur.Y, cur.X - 1] != 'w')
                neighbors.Add(new Point(cur.X - 1, cur.Y));

            if (cur.Y - 1 >= 0 && cur.X + 1 < col && map[cur.Y - 1, cur.X + 1] != 'w')
                neighbors.Add(new Point(cur.X + 1, cur.Y - 1));

            if (cur.Y - 1 >= 0 && map[cur.Y - 1, cur.X] != 'w')
                neighbors.Add(new Point(cur.Y - 1, cur.X));

            if (cur.Y + 1 < row && cur.X + 1 < col && map[cur.Y + 1, cur.X + 1] != 'w')
                neighbors.Add(new Point(cur.Y + 1, cur.X + 1));

            if (cur.Y + 1 < row && map[cur.Y + 1, cur.X] != 'w')
                neighbors.Add(new Point(cur.Y + 1, cur.X));
            
            return neighbors;
        }

        public static void UnitTest()
        {
            char[,] map = new char[7, 7];

            map[2, 0] = 'w';
            map[3, 0] = 'w';
            map[3, 2] = 'w';
            map[3, 3] = 'w';
            map[5, 2] = 'w';

            int dist = FindPath(map, 7, 7, new Point(4, 4), new Point(6, 3));
            Console.Write(dist);
        }
    }
}
