class Node
{
public:
	Node* Left;
	Node* Right;
	Node* Parent;
	int Index;
	int Count;
	int Value;

	Node(int value, int index)
	{
		this->Value = value;
		this->Index = index;
		Count = 0;
		Parent = Left = Right = NULL;
	}
};

class IndexedBST
{
private:
	Node* root; 

public:
	IndexedBST()
	{
		root = NULL;
	}
	
	void Insert(int value, int index)
	{
		Node* node = new Node(value, index);

		if (root == NULL)
		{
			root = node;
			return;
		}
		
		Node* current = root;
		Node* prev = NULL;
		while(current != NULL)
		{
			if (current->Value > node->Value)
			{
				if (node->Index < current->Index)
				{
					node->Count++;
				}

				if (current->Left == NULL)
				{
					current->Left = node;
					break;
				}
				else
					current = current->Left;
			}
			else
			{
				if (current->Right == NULL)
				{
					current->Right = node;
					break;
				}
				else
					current = current->Right;
			}
		}
	}

	void PrintTree()
	{

	}
};