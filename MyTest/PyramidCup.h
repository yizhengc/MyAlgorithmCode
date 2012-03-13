
class PyramidCup
{
private:
	float remaining;
	float capacity;

public:
	PyramidCup()
	{
		this->capacity = 0;
		remaining = 0;
	}

	PyramidCup(int capacity)
	{
		this->capacity = capacity;
		remaining = 0;
	}

	void SetCapacity(float capacity)
	{
		this->capacity = capacity;
	}
	
	void AddWater(float amount)
	{
		remaining += amount;
	}

	bool IsSpill()
	{
		return remaining > capacity;
	}

	void UpdateWater(PyramidCup* leftChild, PyramidCup* rightChild)
	{
		float overflow = (remaining - capacity) / 2;

		if (leftChild != NULL)
			leftChild->AddWater(overflow);

		if (rightChild != NULL)
			rightChild->AddWater(overflow);

		remaining = capacity;
	}

	float Residual()
	{
		return remaining;
	}
};

// Cups pile up as 
//     1
//    2 3
//   4 5 6
//  7 8 9 10

class PyramidCups
{
public:
	static PyramidCup* GetPyramidCupWater(float totalWater, float capacity, int totalCups)
	{
		PyramidCup* list = new PyramidCup[totalCups];

		list[0].SetCapacity(capacity);
		list[0].AddWater(totalWater);

		for(int i = 0; i < totalCups; i++)
		{
			list[i].SetCapacity(capacity);

			if (list[i].IsSpill())
			{
				PyramidCup* left = NULL;
				PyramidCup* right = NULL;
				int leftChildIndex = LeftChild(i + 1) - 1;
				if (leftChildIndex < totalCups)
					left = list + leftChildIndex;
				
				if (leftChildIndex + 1 < totalCups)
					right = list + leftChildIndex + 1;

				list[i].UpdateWater(left, right);
			}
		}

		return list;
	}

private:
	static int LeftChild(int curr)
	{
		int totalCups = 0;
		int level = 0;

		while (totalCups < curr)
		{
			totalCups += ++level;
		}

		return curr + level;
	}
};

void TestPyramidCup()
{
	PyramidCup* cups = PyramidCups::GetPyramidCupWater(100, 5, 36);

	for(int i = 0; i < 36; i++)
	{
		cout << (cups + i)->Residual() << " ";
	}

	cout << endl;
}