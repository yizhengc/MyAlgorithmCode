#include "stdafx.h";
#include "Puzzles.h";

void PrintMatrix(int a[][5], int width, int height)
{
	int r = 0, c = 0;
	Direction dir = Right;
	int upperbound = 0;
	int lowerbound = height;
	int leftbound = 0;
	int rightbound = width;

	int printed = 0;

	while (printed < width * height)
	{
		cout << a[r][c] << endl;
		printed++;
		switch(dir)
		{
		case Right:
			if (c == rightbound - 1)
			{
				dir = Down;
				upperbound++;
				r++;
			}
			else
				c++;
			break;
		case Down:
			if (r == lowerbound - 1)
			{
				dir = Left;
				rightbound--;
				c--;
			}
			else
				r++;
			break;
		case Left:
			if (c == leftbound)
			{
				dir = Up;
				lowerbound--;
				r--;
			}
			else
				c--;
			break;
		case Up:
			if (r == upperbound)
			{
				dir = Right;
				leftbound++;
				c++;
			}
			else
				r--;
			break;
		default:
			;
		}
	}
}

void Rotate(vector<int>& ary, int r)
{
	if (r > ary.size())
		return;

	vector<int> cache;

	for(int i = ary.size() - r - 1; i >= 0; i--)
	{
		cache.push_back(ary[i + r]);
		ary[i + r] = ary[i];
	}

	for (int i = r - 1; i >= 0; i--)
	{
		ary[i] = cache[r - 1 - i];
	}
}

char* balanceParanthesis(char* s, int length)
{
	int openParanthesisCount = 0;
	int closeParanthesisCount = 0;

	for(int i = 0; i < length; i++)
	{
		if (s[i] == '(')
			openParanthesisCount++;
		else if (s[i] == ')')
			closeParanthesisCount++;
	}

	char charToRemove = ' ';
	int countDiff = 0;

	if (openParanthesisCount == closeParanthesisCount)
	{
		return NULL;
	}
	else if (openParanthesisCount > closeParanthesisCount)
	{
		charToRemove = '(';
		countDiff = openParanthesisCount - closeParanthesisCount;
	}
	else
	{
		charToRemove = ')';
		countDiff = closeParanthesisCount - openParanthesisCount;
	}

	if (countDiff == length)
		return NULL;

	char* strRet = new char[length - countDiff];

	for(int i = 0, j = 0; i < length; i++)
	{
		if (s[i] == charToRemove && countDiff > 0)
		{
			countDiff--;
			continue;
		}
		else
		{
			strRet[j++] = s[i];
		}
	}

	return strRet;
}


int SingleDigitToInt(char c)
{
	int v = c - '0';

	if (v > 9 || v < 0)
		throw "This is not a 0-9 char";
	else
		return v;
}

char SingleDigitIntToChar(int c)
{
	if (c > 9 || c < 0)
		throw "This is not a 0-9 int";
	else
		return '0' + c;
}

char* SumLargeNumber(const char* number1, int len1, int shift, char* buffer, int buffer_size)
{
	int carryover = 0;

	if (len1 + shift + 2 > buffer_size)
		return NULL;

	int idx1 = len1 - 1;
	int idx2 = buffer_size - shift - 1;
	for (; idx1 >= 0; idx1--, idx2--)
	{
		int value = SingleDigitToInt(number1[idx1]) + SingleDigitToInt(buffer[idx2]) + carryover;
		if (value >= 10)
		{
			carryover = 1;
			value %= 10;
		}
		else
			carryover = 0;

		buffer[idx2] = SingleDigitIntToChar(value);
	}

	if (carryover != 0)
	{
		buffer[idx2] = SingleDigitIntToChar(carryover);
		return buffer + idx2;
	}
	else
		return buffer + idx2 + 1;
}

char* MultiplyLargeNumber(const char* number1, int len1, char number2, char* result, int result_sz)
{
	int singleDigit = atoi(&number2);

	int buf_size = 8;
	char* buffer = new char[buf_size + 1];
	buffer[buf_size] = '\0';
	char* bufferComputed = new char[buf_size + 2];
	char* ret = result;

	int iter = 0;
	while (len1 > 0)
	{
		int len = min(len1, buf_size);
		strncpy(buffer, number1 + max(0, len1 - buf_size), len);
		buffer[len] = '\0';
		int bufferValue = atoi(buffer);
		bufferComputed = itoa(bufferValue * singleDigit, bufferComputed, 10);

		int bufferComputed_size = strlen(bufferComputed);

		if (iter == 0)
		{
			strcpy(result + result_sz - bufferComputed_size, bufferComputed);
		}
		else
		{
			ret = SumLargeNumber(bufferComputed, bufferComputed_size, buf_size * iter, result, result_sz);
		}

		iter++;
		len1 -= min(len1, buf_size);
	}

	return ret;
}

char* MultiplyLargeNumber(const char* number1, int len1, const char* number2, int len2)
{
	if (number1 == NULL || number2 == NULL || len1 == 0 || len2 == 0)
		return NULL;

	char* buffer = new char[len1 + len2 + 2];
	buffer[len1 + len2 + 1] = '\0';
	int buffer_strlen = len1 + len2 + 1;
	char* result = new char[len1 + len2 + 2];
	result[len1 + len2 + 1] = '\0';
	int result_strlen = len1 + len2 + 1;

	int i; 
	for (i = 0; i < len1 + len2 + 1; i++)
		buffer[i] = result[i] = '0';

	char* ret = buffer;

	bool isNum1Negative = number1[0] == '-';
	bool isNum2Negative = number2[0] == '-';
	bool isResultNegative = isNum1Negative && !isNum2Negative || !isNum1Negative && isNum2Negative;

	for (i = len2 - 1; i >= (isNum2Negative ? 1 : 0); i--)
	{
		ret = MultiplyLargeNumber(isNum1Negative ? number1 + 1 : number1, isNum1Negative ? len1 - 1: len1, number2[i], buffer, buffer_strlen);

		if (i != len2 - 1)
			ret = SumLargeNumber(ret, buffer_strlen - (ret - buffer), 1, result, result_strlen);
		else
			ret = strncpy(result + (ret - buffer), ret, buffer_strlen - (ret - buffer));
	}

	// Shift final results
	for (i = 0; i < result_strlen - (ret - result); i++)
		result[i + (isResultNegative ? 1 : 0)] = ret[i];

	result[i + (isResultNegative ? 1 : 0)] = '\0';

	if (isResultNegative)
		result[0] = '-';

	delete buffer;

	return result;
}

int LargestMonotonicallyIncreaseSequence(int* set, int length, int& startIndex, int& endIndex)
{
	if (set == NULL || length == 0)
		startIndex = endIndex = -1;

	startIndex = 0;
	endIndex = 0;
	int longest = 1;

	int iter = 0;

	for (int i = 0; i < length && i + longest < length; )
	{
		if (set[i + longest] >= set[i])
		{
			int j;
			for (j = i + longest - 1; j >= i; j--)
			{
				if (set[j] > set[j+1])
					break;
			}

			if (j < i)
			{
				startIndex = i;
				//for(j = i + longest
			}
		}
		else
			i = i + longest;
	}
	
	return 0;
}

CopyOnWriteChar CopyOnWriteString::operator [] (int index)
{
	return CopyOnWriteChar(this, index);
}

bool SimpleRegexMatch(char* value, int vallen, char* pattern, int patlen)
{
	if (value == NULL || pattern == NULL)
		return false;

	if (vallen == 0 && patlen == 0)
		return true;
	else if (patlen == 0 && vallen != 0)
		return false;

	char char_pat = pattern[patlen - 1];
	char char_special = ' ';
	if (char_pat == '?' || char_pat == '*')
	{
		char_special = char_pat;
		char_pat = pattern[patlen - 2];
		if(char_pat == '*' || char_pat == '?')
			throw "Pattern error";

		if (vallen == 0)
			return SimpleRegexMatch(value, vallen, pattern, patlen - 2);
		else if (char_pat != value[vallen - 1])
			return SimpleRegexMatch(value, vallen, pattern, patlen - 2);
		else
		{
			return SimpleRegexMatch(value, vallen - 1, pattern, patlen - (char_special == '?' ? 2 : 0)) || SimpleRegexMatch(value, vallen, pattern, patlen - 2);
		}
	}
	else if (vallen != 0 && char_pat == value[vallen - 1])
		return SimpleRegexMatch(value, vallen - 1, pattern, patlen - 1);
	else
		return false;
}	

int* ConvertArray(int* input, int length, int& outSize)
{
	if (input == NULL)
		return NULL;

	int lastNumber = input[0];
	int count = 1;
	int* output = new int[2*length];

	int k = 0;
	for(int i = 1; i < length; i++)
	{
		if (input[i] == lastNumber)
			count++;
		else
		{
			output[k++] = count;
			output[k++] = lastNumber;
			lastNumber = input[i];
			count = 1;
		}
	}

	output[k++] = count;
	output[k++] = lastNumber;

	outSize = k;
	int* actualOutput = new int[k--];

	while (k >= 0)
	{
		actualOutput[k] = output[k];
		k--;
	}

	delete output;

	return actualOutput;
}

char** PermutatePhoneNumber(const char* phoneNumber, int numSize, int& resultSize)
{
	char* map[] = {"0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

	int totalPerm = 1;

	for(int i = 0; i < numSize; i++)
		totalPerm *= strlen(map[SingleDigitToInt(phoneNumber[i])]);

	char** result = new char*[totalPerm];
	resultSize = totalPerm;

	for (int i = 0; i < totalPerm; i++)
		result[i] = new char[numSize + 1];

	for (int i = 0, j = 0; i < 4^10 && j < totalPerm; i++)
	{
		int k = numSize - 1;
		int value = i; 
		for (; k >= 0; k--)
		{
			int offset = value & 0x3;
			if (offset >= strlen(map[SingleDigitToInt(phoneNumber[k])]))
				break;
			else
				result[j][k] = map[SingleDigitToInt(phoneNumber[k])][offset];

			value = value >> 2;
		}

		if (k == -1)
		{
			result[j][numSize] = '\0';
			j++;
		}
	}

	return result;
}
