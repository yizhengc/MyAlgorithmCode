#include <vector>;
#include "Sort.h";
#include <math.h>;
#include <algorithm>;

using namespace Util;


/*
void GenerateSubsets(int data[], int szData, int szSubset)
{
	if (szData > szSubset)
	{
		SortingUtil<int>::QuickSort(data, 0, szData);

		vector<int> values;
		vector<int> counts;

		for (int i = 0, j = 0; i < szData; i++)
		{
			if (i == 0 || data[i] == data[i - 1])
			{
				values.push_back(data[i]);
				counts.push_back(1);
				j++;
			}
			else
			{
				counts[j]++;
			}
		}

		
	}
}

vector<vector<int>>* GetPermutations(vector<int> values, vector<int> counts, int index, int selectionCount)
{
	if (index < values.size() && selectionCount > 0)
	{
		vector<vector<int>>* permutations = new vector<vector<int>>();

		for(int c = 0; c <= selectionCount && c < counts[index]; c++)
		{
			if (c == selectionCount)
			{
				
			}
			else
			{
				vector<vector<int>>* nextPermutations = GetPermutations(values, counts, index + 1, selectionCount - c);
			}
		}
	}

	return NULL;
}

vector<vector<int>>* AddPermutations(int currentValue, int selectedCount, vector<vector<int>>* source, vector<vector<int>>* target)
{
	for(int k = 1; k <= selectedCount; k++)
	{
		for (int i = 0; i < k; i++)
		{
			if (source != NULL)
			{
				for (int j = 0; j < source->size(); j++)
				{
					target->push_back(new vector<int>(source[j]));
				}
			}
		}

			for (int i = 0; i < k; i++)
				nextPermutations[j].push_back(values[index]);
		}
	}
}
*/

void Rotate(vector<int>& ary, int r);

char* balanceParanthesis(char* s, int length);

enum Direction
{
	Left,
	Right,
	Up, 
	Down
};

void PrintMatrix(int a[][5], int width, int height);

char* MultiplyLargeNumber(const char* number1, int len1, const char* number2, int len2);

int LargestMonotonicallyIncreaseSequence(int* set, int length, int& startIndex, int& endIndex);

class CopyOnWriteChar;

class CopyOnWriteBase
{
private:
	char* _value;
	int _strlen;
	int _refcount;

public:
	CopyOnWriteBase(char* value)
	{
		_strlen = strlen(value);
		_value = new char[_strlen + 1];
		strcpy(_value, value);
		
		_refcount = 1;
	}

	CopyOnWriteBase(const CopyOnWriteBase& value)
	{
		_value = new char[value._strlen + 1];
		strcpy(_value, value._value);
		_strlen = value._strlen;
		_refcount = 1;
	}

	~CopyOnWriteBase()
	{
		_strlen = 0;
		_refcount = 0;
		delete _value;

		cout << "destructing copyonwritebase" << endl;
	}

	void IncrementRefCount()
	{
		_refcount++;
		cout << "increment refcount to " << _refcount << endl;
	}

	void DecrementRefCount()
	{
		_refcount--;
		cout << "decrement refcount to " << _refcount << endl;
	}

	int RefCount() { return _refcount; }

	void Set(int index, char c)
	{
		_value[index] = c;
	}
};

class CopyOnWriteString
{
private:
	CopyOnWriteBase* _root;

friend class CopyOnWriteChar;

public:

	CopyOnWriteString(char* value)
	{
		_root = new CopyOnWriteBase(value);
	}

	CopyOnWriteString(const CopyOnWriteString& rhs)
	{
		this->_root = rhs._root;
		_root->IncrementRefCount();
	}

	~CopyOnWriteString()
	{
		if (_root->RefCount() == 1)
			delete _root;
		else
			_root->DecrementRefCount();
	}	

	CopyOnWriteChar operator [] (int);

private:
	void Clone()
	{
		CopyOnWriteBase* tmp = _root;
		_root = new CopyOnWriteBase(*tmp);
		tmp->DecrementRefCount();

		if (tmp->RefCount() == 0)
			delete tmp;
	}

	void Set(int index, char value)
	{
		Clone();
		_root->Set(index, value);
	}
};

class CopyOnWriteChar
{
private:
	CopyOnWriteString* _source;
	int _index;

public:
	CopyOnWriteChar(const CopyOnWriteString* src, int index)
	{
		_source = const_cast<CopyOnWriteString*>(src);
		_index = index;
	}

	void operator=(const char value)
	{
		_source->Set(_index, value);
	}
};

bool SimpleRegexMatch(char* value, int vallen, char* pattern, int patlen);

int* ConvertArray(int* input, int length, int& outSize);

char** PermutatePhoneNumber(const char* phoneNumber, int numSize, int& resultSize);