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