class Node
{
public:
	int Count;
	int LeftChildCount;
	int Index;
	Node* Left;
	Node* Right;

	Node(int count, int idx)
	{
		Count = count;
		Index = idx;
		Left = Right = NULL;
		LeftChildCount = 0;
	}
};

void InsertToTree(Node* root, Node* node)
{
	Node* cur = root;

	while (cur != NULL)
	{
		if (node->Count > cur->LeftChildCount)
		{
			if (cur->Right != NULL)
			{
				node->Count -= cur->LeftChildCount + 1;
				cur = cur->Right;
			}				
			else
			{
				cur->Right = node;
				break;
			}
		}
		else
		{
			cur->LeftChildCount++;

			if (cur->Left != NULL)
				cur = cur->Left;
			else
			{
				cur->Left = node;
				break;
			}
		}
	}
}

void PrintTreeToArray(Node* node, int* origArray, int& value)
{
	if (node->Left != NULL)
		PrintTreeToArray(node->Left, origArray, value);

	origArray[node->Index] = ++value;

	if (node->Right != NULL)
		PrintTreeToArray(node->Right, origArray, value);
}

int* RecoverArrayFromCountArray(int* countarray, int length)
{
	Node* root = NULL;
	for (int i = length - 1; i >= 0; i--)
	{
		Node* node = new Node(countarray[i], i);

		if (root == NULL)
			root = node;
		else
			InsertToTree(root, node);
	}

	int* origArray = new int[length];

	int value = 0;
	PrintTreeToArray(root, origArray, value);

	return origArray;
}