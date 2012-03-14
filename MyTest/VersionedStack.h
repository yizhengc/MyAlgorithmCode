#include <vector>;
using namespace std;

class StackItem
{
public:
	int Value;
	StackItem* Parent;

	StackItem(int value)
	{
		Value = value;
		Parent = NULL;
	}
};

class VersionedStack
{
private:
	vector<StackItem*> Versions;

public:
	VersionedStack()
	{
	}

	void Push(int value)
	{
		StackItem* toAdd = new StackItem(value);
		toAdd->Parent = Versions.size() == 0 ? NULL : Versions[Versions.size() - 1];;
		Versions.push_back(toAdd);
	}

	void Pop()
	{
		StackItem* head = Versions.size() == 0 ? NULL : Versions[Versions.size() - 1];
		Versions.push_back(head == NULL ? NULL : head->Parent);
	}

	void PrintStack(int version)
	{
		StackItem* cur = Versions[version];

		while(cur != NULL)
		{
			cout << cur->Value << " ";
			cur = cur->Parent;
		}

		cout << endl;
	}
};

void TestVersionedStack()
{
	int elements[14] = {2, -1, 1, 4, -1, 3, -1, 9, 6, 8, 5, -1, 0, 7};

	VersionedStack* stack = new VersionedStack();

	for(int i = 0; i < 14; i++)
	{
		if (elements[i] == -1)
			stack->Pop();
		else
			stack->Push(elements[i]);
	}

	stack->PrintStack(1);

	stack->PrintStack(4);

	stack->PrintStack(8);
}