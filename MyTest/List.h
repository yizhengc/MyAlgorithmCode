using namespace std;

struct ListNode
{
public:
	int Value;
	ListNode* Next;
};

ListNode* CreateSinglyLinkedList(int values[], int length)
{
	struct ListNode* head = new struct ListNode();
	struct ListNode* current = head;	

	for (int i = 0; i < length; i++)
	{
		current->Value = values[i];
		if (i < length - 1)
		{
			current->Next = new struct ListNode();
			current = current->Next;
		}
		else
			current->Next = NULL;
	}

	return head;
}

ListNode* ReverseSinglyLinkedList(ListNode* head)
{
	ListNode* next = head->Next;
	ListNode* prev = NULL;
	ListNode* current = head;

	while(next != NULL)
	{
		current->Next = prev;
		prev = current;
		current = next;
		next = next->Next;
	}

	current->Next = prev;

	return current;
}

void PrintList(ListNode* head)
{
	while (head != NULL)
	{
		cout << head->Value << ' ';
		head = head->Next;
	}
}