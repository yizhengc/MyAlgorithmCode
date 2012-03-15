#include <algorithm>;
using namespace std;

int* Sum(int* a, int len1, int* b, int len2, int& len)
{
	len = max(len1, len2) + 1;
	int* result = new int[len];

	int carry = 0;
	for(int i = 0; i < len; i++)
	{
		int sum = ((len1 - 1 - i) >= 0 ? a[len1 - 1 - i] : 0)
					+ ((len2 - 1 - i) >= 0 ? b[len2 - 1 - i] : 0) + carry;

		if (sum >= 10)
		{
			carry = sum / 10;
			result[len - 1 - i] = sum % 10;
		}
		else
		{
			carry = 0;
			result[len - 1 - i] = sum;
		}
	}

	return result;
}

int* Multiply(int* a, int len1, int* b, int len2, int& len)
{
	len = len1 + len2;
	int* result = new int[len];
	memset(result, 0, sizeof(int) * len);

	int carry = 0;
	for(int i = 0; i < len1; i++)
	{
		for(int j = 0; j < len2; j++)
		{
			int sum = a[len1 - 1 - i] * b[len2 - 1 - j] + carry + result[len - 1 - i - j];

			if (sum >= 10)
			{
				carry = sum / 10;
				result[len -1 - j - i] = sum % 10;
			}
			else
			{
				carry = 0;
				result[len -1 - j - i] = sum;
			}
		}

		result[len - 1 - i - len2] = carry;
		carry = 0;
	}

	return result;
}

void PrintLargeNumber(int* value, int length)
{
	bool leadingZero = true;
	for (int i = 0; i < length; i++)
	{
		if (leadingZero && value[i] == 0)
			continue;
		else
		{
			leadingZero = false;
			cout << value[i];
		}
	}

	cout << endl;
}

void TestLargeNumberFunctions()
{
	int number1[] = {1, 2, 3, 5};
	int number2[] = {4, 8, 1, 7, 9};

	int len = 0;
	int* result = Sum(number1, 4, number2, 5, len);

	PrintLargeNumber(result, len);

	result = Multiply(number1, 4, number2, 5, len);

	PrintLargeNumber(result, len);
}

