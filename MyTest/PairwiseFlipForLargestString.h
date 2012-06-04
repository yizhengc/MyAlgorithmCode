struct IndexValue
{
	char Value;
	int Index;
};

int Comparer(IndexValue& a, IndexValue& b)
{
	if (a.Value < b.Value)
		return -1;
	else if(a.Value > b.Value)
		return 1;
	else if (a.Index < b.Value)
		return -1;
	else if (a.Index > b.Value)
		return 1;
	
	return 0;
}

char* PairwiseFlipForLargestString(char* input, int length, int moves)
{
	IndexValue* buf = new IndexValue[length];

	for(int i = 0; i < length; i++)
	{
		buf[i].Value = input[length];
		buf[i].Index = i;
	}

	SortUtil<IndexValue>::QuickSort(buf, 0, length, Comparer);

	char* result = new char[length];
	int lastMoveIndex = length;
	for(int i = 0; i < length; i++)
	{
		if (buf[i].Index <= moves)
		{
			result[i] = buf[i].Value;
			moves -= buf[i].Index < lastMoveIndex ? buf[i].Index : buf[i].Index - 1;

		}
		else
	}
}