// Find the index of the target value if found.
// Otherwise return -1;
int BinarySearch(int list[], int length, int target)
{
	int low = 0;
	int high = length - 1;

	while(low <= high)
	{
		int m = (low + high) / 2;

		if (list[m] == target)
			return m;
		else if (list[m] < target)
			low = m + 1;
		else 
			high = m - 1;
	}

	return -1;
}

// Find the first index of the target value if found.
// Otherwise return -1;
int BinarySearchFirst(int list[], int length, int target)
{
	int low = 0;
	int high = length - 1;

	while(low <= high)
	{
		int m = (low + high) / 2;

		if (list[m] == target && (m == 0 || list[m-1] != target))
			return m;
		else if (list[m] < target)
			low = m + 1;
		else 
			high = m - 1;
	}

	return -1;
}

// Find the first index of the target value if found.
// Otherwise return the largest one that's smaller than target
// otherwise return -1
int BinarySearchLargestSmaller(int list[], int length, int target)
{
	int low = 0;
	int high = length - 1;

	while(low <= high)
	{
		int m = (low + high) / 2;

		if (list[m] == target && (m == 0 || list[m-1] != target))
			return m;
		else if (list[m] < target)
			if (m == length - 1 || list[m + 1] >= target)
				return m;
			else
				low = m + 1;
		else 
			high = m - 1;
	}

	return -1;
}

void TestBinarySearch()
{
	int elements[] = {1, 2, 3, 3, 5, 5, 6};

	cout << BinarySearch(elements, 7, 3) << endl;

	cout << BinarySearchFirst(elements, 7, 5) << endl;

	cout << BinarySearchLargestSmaller(elements, 7, 0) << endl;
}