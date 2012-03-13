class Interval
{
public:
	int LB;
	int RB;
};

int LargestOverlap(Interval* intervals, int length, int& idx1, int& idx2)
{
	int rb = 0;
	int maxOverlap = 0;
	int lastIndex = -1;
	for(int i = 0; i < length; i++)
	{
		if (rb == 0)
		{
			rb = intervals[i].RB;
			lastIndex = i;
		}
		else if (intervals[i].LB < rb && intervals[i].RB <= rb)
		{
			if (intervals[i].RB - intervals[i].LB > maxOverlap)
			{
				idx1 = lastIndex;
				idx2 = i;
				maxOverlap = intervals[i].RB - intervals[i].LB;
			}
		}
		else if (intervals[i].LB < rb && intervals[i].RB > rb)
		{
			if (rb - intervals[i].LB > maxOverlap)
			{
				idx1 = lastIndex;
				idx2 = i;
				maxOverlap = rb - intervals[i].LB;
			}

			lastIndex = i;
			rb = intervals[i].RB;
		}
		else if (intervals[i].LB >= rb)
		{
			rb = intervals[i].RB;
			lastIndex = i;
		}
	}

	return maxOverlap;
}

int MergeIntervals(Interval* range, int length)
{
	int j = 0;
	for(int i = 1; i < length; i++)
	{
		if (range[i].LB <= range[j].RB)
		{
			range[j].RB = max(range[i].RB, range[j].RB);
		}
		else
		{
			j++;
			range[j].LB = range[i].LB;
			range[j].RB = range[i].RB;
		}
	}

	return j + 1;
}

void TestLargestOverlapIntervals()
{
	int ranges[7][2] = { {1, 6}, {3, 9}, {4, 6}, {5, 9}, {9, 13}, {11, 19}, {12, 18}};

	Interval* intervals = new Interval[7];

	for(int i = 0; i < 7; i++)
	{
		intervals[i].LB = ranges[i][0];
		intervals[i].RB = ranges[i][1];
	}

	int idx1, idx2;
	int overlap = LargestOverlap(intervals, 7, idx1, idx2);
}

void TestMergeInterval()
{
	int ranges[7][2] = { {1, 6}, {3, 9}, {4, 6}, {5, 9}, {9, 10}, {11, 19}, {12, 18}};

	Interval* intervals = new Interval[7];

	for(int i = 0; i < 7; i++)
	{
		intervals[i].LB = ranges[i][0];
		intervals[i].RB = ranges[i][1];
	}

	int len = MergeIntervals(intervals, 7);

	for(int i = 0; i < len; i++)
	{
		cout << intervals[i].LB << " " << intervals[i].RB << endl;
	}
}