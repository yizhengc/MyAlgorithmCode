#include<algorithm>;

using namespace std;

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

void TestFindMedianOfSortedArrays()
{
	int elements[8] = {1, 3, 5, 6, 9, 12, 17, 20 };
	int elements2[8] = {2, 3, 4, 4, 11, 14, 17, 19 };

	int median = FindMedian(elements, elements2, 8);

	cout << "Test FindMedian() " << endl << "Median: " << median << endl;
}