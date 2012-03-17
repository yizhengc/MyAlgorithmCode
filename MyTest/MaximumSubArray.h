#include <algorithm>

using namespace std;

int MaximumSubarray(int input[], int length)
{
	int maxSofar = 0;
	int maxEndHere = 0;

	for (int i = 0;  i < length; i++)
	{
		maxEndHere = max(0, maxEndHere + input[i]);

		if (maxSofar < maxEndHere)
		{
			maxSofar = maxEndHere;
		}
	}

	return maxSofar;
}

int MaximumSubarray(int input[], int length, int& l, int& u)
{
	int maxSofar = 0;
	int maxEndHere = 0;

	l = 0;
	u = 0;

	for (int i = 0;  i < length; i++)
	{
		maxEndHere = max(0, maxEndHere + input[i]);

		if (maxEndHere == 0)
			l = i + 1;

		if (maxSofar < maxEndHere)
		{
			maxSofar = maxEndHere;
			u = i;
		}
	}

	return maxSofar;
}

void TestMaxSubarray()
{
	int input[] = {2, -1, 0, -3, 5, 4, -6, 7};

	cout << MaximumSubarray(input, 8) << endl;;

	int l, u;

	cout << l << " " << u << " " << MaximumSubarray(input, 8, l, u) << endl;
}