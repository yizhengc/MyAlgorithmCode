#include "Stack.h";

int MaxRectAreaUnderHistogram(int hist[], int length)
{
	int maxSoFar = 0;
	for (int i = 0; i < length; i++)
	{
		for (int j = i + 1; j < length; j++)
		{
			if (hist[j] < hist[i])
			{
				int area = hist[i] * (j - i);

				if (area > maxSoFar)
					maxSoFar = area;

				break;
			}
		}
	}

	return maxSoFar;
}

int* FindNearestSmaller(int input[], int length, bool l2r=true)
{
	Stack<int> values(length);
	Stack<int> positions(length);
	int* result = new int[length];

	for (int i = 0; i < length; i++)
	{
		int idx = l2r ? i : length - 1 - i;

		while(!values.IsEmpty() && values.Top() > input[idx])
		{
			values.Pop();
			positions.Pop();
		}

		if (!values.IsEmpty())
			result[idx] = positions.Top();
		else
			result[i] = l2r ? -1 : length;

		values.Push(input[idx]);
		positions.Push(idx);
	}

	return result;
}

int MaxRectAreaUnderHistogramLinear(int hist[], int length)
{
	int* nearestSmallerOnLeft = FindNearestSmaller(hist, length);
	int* nearestSmallerOnRight = FindNearestSmaller(hist, length, false);

	int maxSofar = 0;
	for(int i = 0; i < length; i++)
	{
		int area = hist[i] * (nearestSmallerOnRight[i] - nearestSmallerOnLeft[i] - 1) ;
		if (area > maxSofar)
			maxSofar = area;
	}

	return maxSofar;
}

void TestMaxRectangularAreaUnderHistogram()
{
	int input[] = {3, 4, 2, 5, 2, 1};

	cout << MaxRectAreaUnderHistogramLinear(input, sizeof(input)/sizeof(int));
}