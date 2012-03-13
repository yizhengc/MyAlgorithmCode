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

void TestFindLongestDistanceOrderedPair()
{
	int elements[10] = {12, 6, 1, 8, 9, 3, 2, 4, 10, 11 };

	int left, right;

	int distance = FindLongestDistanceOrderedPair(elements, 10, left, right);
}
