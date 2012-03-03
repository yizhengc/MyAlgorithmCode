#include <algorithm>;

using namespace std;

int FindLongestDistanceOrderedPair(int* elements, int length, int& left, int& right)
{
	int* aux = new int[length];

	for(int i = length - 1; i >= 0; i--)
	{
		if (i == length - 1)
			aux[i] = elements[i];
		else
			aux[i] = max(aux[i + 1], elements[i]);
	}

	int distance = 0;

	for (int i = 0, j = 0; i < length && j < length; )
	{
		if (elements[i] < aux[j])
		{
			if (j - i > distance)
			{
				distance = j - i;
				left = i;
				right = j;
			}
			j++;
		}
		else
			i++;
	}

	return distance;
}

int FindMedian(int* list1, int* list2, int length)
{
	int medianOffset = (length - 1) / 2;

	if (medianOffset == 0)
	{
		if (length == 1)
			return min(list1[0], list2[0]);
		else if (length == 2)
		{
			return max(min(list1[0], list1[1]), min(list2[0], list2[1]));
		}
	}
	
	if (list1[medianOffset] == list2[medianOffset])
		return list1[medianOffset];
	else if (list1[medianOffset] < list2[medianOffset])
	{
		return FindMedian(list1 + medianOffset, list2, length - medianOffset);
	}
	else if (list1[medianOffset] > list2[medianOffset])
	{
		return FindMedian(list2 + medianOffset, list1, length - medianOffset);
	}
}