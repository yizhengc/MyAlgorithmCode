class Interval
{
public:
    int LB;
    int RB;
	Interval* Next;
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

Interval* MergeTwoIntervalLists(Interval* range1, Interval* range2)
{
	Interval* head = new Interval();
	Interval* current = NULL;
	Interval* toAdd = NULL;

	while (range1 != NULL || range2 != NULL)
	{
		if (range1 == NULL || range1->LB >= range2->LB)
		{
			toAdd = range2;
			range2 = range2->Next;
		}
		else if (range2 == NULL || range1->LB < range2->LB)
		{
			toAdd = range1;
			range1 = range1->Next;
		}

		if (current == NULL)
		{
			current = head;
			current->LB = toAdd->LB;
			current->RB = toAdd->RB;
		}
		else if (current->RB >= toAdd->LB)
		{
			current->RB = max(current->RB, toAdd->RB);
		}
		else
		{
			current->Next = new Interval();
			current = current->Next;
			current->LB = toAdd->LB;
			current->RB = toAdd->RB;
		}
	}

	current->Next = NULL;

	return head;
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
    int ranges[7][2] = { {1, 6}, {3, 9}, {4, 6}, {5, 8}, {9, 10}, {11, 19}, {12, 18}};

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

Interval* CreateIntervalList(int ranges[][2], int start, int end)
{
	if (start >= end)
		return NULL;

	Interval* head = new Interval();
	Interval* range = NULL;
    for(int i = start; i < end; i++)
    {
		if (range == NULL)
			range = head;
		else
		{
			range->Next = new Interval();
			range = range->Next;
		}

        range->LB = ranges[i][0];
        range->RB = ranges[i][1];
		range->Next = NULL;
    }

	return head;
}

void TestMergeTwoIntervalLists()
{
	int ranges[7][2] = { {1, 6}, {3, 9}, {4, 6}, {5, 8}, {9, 10}, {11, 19}, {12, 18}};

	Interval* range1 = CreateIntervalList(ranges, 0, 4);
	Interval* range2 = CreateIntervalList(ranges, 4, 7);

	Interval* final = MergeTwoIntervalLists(range1, range2);

	while(final != NULL)
	{
		cout << final->LB << " " << final->RB << endl;
		final = final->Next;
	}
}