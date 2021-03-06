﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterview
{
    class Intervals
    {
        class Boundary : IComparable
        {
            public DateTime Time;
            public int IntervalId;
            public int OpenCount;
            public int CloseCount;
            public int UserCount;

            public Boundary(DateTime t, int op, int cl)
            {
                Time = t;
                OpenCount = op;
                CloseCount = cl;
            }

            public Boundary(int intervalId, DateTime t, int op, int cl)
            {
                IntervalId = intervalId;
                Time = t;
                OpenCount = op;
                CloseCount = cl;
            }
        
            #region IComparable Members

            public int  CompareTo(object obj)
            {
                return Time.CompareTo(((Boundary)obj).Time);
            }

            #endregion
        }

        List<Boundary> boundaries;

        public static Tuple<DateTime, DateTime> FindIntervalWithMostOverlap(Tuple<DateTime, DateTime>[] intervals)
        {
            List<Boundary> lst = new List<Boundary>();

            for(int i = 0; i < intervals.Length; i++)
            {
                lst.Add(new Boundary(i, intervals[i].Item1, 1, 0));
                lst.Add(new Boundary(i, intervals[i].Item2, 0, 1));
            }

            lst.Sort();

            int openCount = 0;
            int closeCount = 0;

            int[] intervalOpenOffset = new int[intervals.Length];

            int maxOverlap = 0;
            int maxOverlapInterval = 0;

            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].OpenCount == 1)
                {
                    lst[i].OpenCount = openCount;
                    lst[i].CloseCount = closeCount;
                    openCount += 1;
                    intervalOpenOffset[lst[i].IntervalId] = i;
                }
                else
                {
                    Boundary open = lst[intervalOpenOffset[lst[i].IntervalId]];
                    int overlap = open.OpenCount - open.CloseCount + openCount - open.OpenCount - 1;

                    if (overlap > maxOverlap)
                    {
                        maxOverlap = overlap;
                        maxOverlapInterval = lst[i].IntervalId;
                    }

                    closeCount += 1;
                }
            }

            return intervals[maxOverlapInterval];
        }

        public void Preprocess(Tuple<DateTime, DateTime>[] intervals)
        {
            boundaries = new List<Boundary>();

            foreach (var t in intervals)
            {
                boundaries.Add(new Boundary(t.Item1, 1, 0));
                boundaries.Add(new Boundary(t.Item2, 0, 1));
            }

            boundaries.Sort();

            int j = -1;
            int openCnt = 0;
            int closeCnt = 0;
            for(int i = 0; i < boundaries.Count; i++)
            {
                openCnt += boundaries[i].OpenCount;
                closeCnt += boundaries[i].CloseCount;
                if (i == 0 || boundaries[i].Time != boundaries[j].Time)
                {
                    ++j;
                    boundaries[j].Time = boundaries[i].Time;
                }
                
                boundaries[j].OpenCount = openCnt;
                boundaries[j].CloseCount = closeCnt;
                boundaries[j].UserCount = openCnt - closeCnt;
            }

            if (j < boundaries.Count - 1)
            {
                boundaries.RemoveRange(j + 1, boundaries.Count - 1 - j);
            }
        }

        public int FindUserCount(DateTime t)
        {
            int idx = FindLargestSmaller(boundaries, t);

            if (idx >= 0)
            {
                return boundaries[idx].UserCount;
            }
            else
                return 0;
        }

        static int FindLargestSmaller(List<Boundary> boundaries, DateTime t)
        {
            int l = 0;
            int h = boundaries.Count - 1;

            while (l <= h)
            {
                int m = (l + h) / 2;

                if (boundaries[m].Time == t)
                {
                    return m;
                }
                else if (boundaries[m].Time < t)
                {
                    if (m == boundaries.Count - 1 || boundaries[m + 1].Time > t)
                        return m;

                    l = m + 1;
                }
                else
                {
                    h = m - 1;
                }
            }

            return -1;
        }

        // Given a list of intervals, find the largest overlap between two intervals
        public static int LargestOverlap(List<Tuple<int, int>> lst)
        {
            if (lst == null || lst.Count <= 0)
                return 0;

            int cur = 0;
            int max = 0;

            for (int i = 1; i < lst.Count; i++)
            {
                int overlap = 0;
                if (lst[i].Item1 >= lst[cur].Item2)
                {
                    cur = i;
                }
                else if (lst[i].Item2 <= lst[cur].Item2)
                {
                    overlap = lst[i].Item2 - lst[i].Item1;
                }
                else
                {
                    overlap = lst[cur].Item2 - lst[i].Item1;
                    cur = i;
                }
                
                if (overlap > max)
                {
                    max = overlap;
                }
            }

            return max;
        }

        public static void UnitTest()
        {
            List<Tuple<DateTime, DateTime>> intervals = new List<Tuple<DateTime,DateTime>>();
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-12"), DateTime.Parse("2012-03-14")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-13"), DateTime.Parse("2012-03-18")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-15"), DateTime.Parse("2012-03-17")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-16"), DateTime.Parse("2012-03-20")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-19"), DateTime.Parse("2012-03-21")));

            Intervals interval = new Intervals();
            interval.Preprocess(intervals.ToArray());
            int userCount = interval.FindUserCount(new DateTime(2012, 3, 14, 3, 15, 0));

            List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
            ranges.Add(new Tuple<int, int>(1, 6));
            ranges.Add(new Tuple<int, int>(3, 9));
            ranges.Add(new Tuple<int, int>(4, 6));
            ranges.Add(new Tuple<int, int>(5, 9));
            ranges.Add(new Tuple<int, int>(9, 13));
            ranges.Add(new Tuple<int, int>(11, 19));
            ranges.Add(new Tuple<int, int>(12, 18));

            int overlap = LargestOverlap(ranges);

            Tuple<DateTime, DateTime> result = FindIntervalWithMostOverlap(intervals.ToArray());

        }
    }
}
