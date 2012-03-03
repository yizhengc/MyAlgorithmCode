#include <vector>;

using namespace std;

class NumberTheory
{
public:
	static void PrintHeavyNumbers(int start, int end, int avg)
	{
		int digitsStart, digitsEnd;

		int* start = SplitNumber(start, digitsStart);

		int* end = SplitNumber(end, digitsEnd);

		if (digitsEnd == digitsStart)
		{
			int sum = avg * digitsEnd;

			
		}
	}

	static int DigitCount(int num)
	{
		int digits = 1;
		while(num >= 10)
		{
			num = (num - num % 10) / 10;
			digits++;
		}
	}

	static int* SplitNumber(int num, int& length)
	{
		int digits = DigitCount(num);
		length = digits;
		int* list = new int[digits];

		while(digits >= 0)
		{
			int residual = num % 10; 
			list[--digits] = residual;
			num = (num - num % 10) / 10;
		}
	}
};