#include <algorithm>;

using namespace std;

// Key: Use an auxiliary array to remember the largest element to the right of the current element. 
// If original is 12, 6, 1, 8, 9, 3, 2, 4, 10, 1
// aux will be 12, 10, 10, 10, 10, 10, 10, 10, 10, 1
// The aux just provides the information saying there is a bigger value after the current location which is say 10. 
// When found longest order pair starting from the current location i, there won't be pair in between that's longer.
// So if hitting a smaller value than current location in the aux array, then start search again at the location at the smaller value. 
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
