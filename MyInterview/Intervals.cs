using System;
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
            public int OpenCount;
            public int CloseCount;
            public int UserCount;

            public Boundary(DateTime t, int op, int cl)
            {
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

        public static void UnitTest()
        {
            List<Tuple<DateTime, DateTime>> intervals = new List<Tuple<DateTime,DateTime>>();
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-12"), DateTime.Parse("2012-03-13")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-13"), DateTime.Parse("2012-03-14")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-12"), DateTime.Parse("2012-03-17")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-15"), DateTime.Parse("2012-03-16")));
            intervals.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2012-03-17"), DateTime.Parse("2012-03-20")));

            Intervals interval = new Intervals();
            interval.Preprocess(intervals.ToArray());
            int userCount = interval.FindUserCount(new DateTime(2012, 3, 14, 3, 15, 0));
        }
    }
}
