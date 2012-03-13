#include "Stack.h";
#include "Queue.h";
using namespace std;

class TreeNode
{
public:
	int Value;
	TreeNode* LeftChild;
	TreeNode* RightChild;
	TreeNode* Parent;
	bool Visited;
	int Level;

	TreeNode(int value)
	{
		Value = value;
		LeftChild = NULL;
		RightChild = NULL;
		Parent = NULL;
		Visited = false;
	}
};

enum TraverseOrder
{
	InOrder = 0,
	PreOrder, 
	PostOrder
};

class BinaryTree
{
private:
	TreeNode* _pRoot;

public:
	BinaryTree()
	{
		_pRoot = NULL;
	}

	TreeNode* GetRoot()
	{
		return _pRoot;
	}
	
	void BuildTree(int* values, int aryLength)
	{
		for(int i = 0; i < aryLength; i++)
		{
			AddValue(values[i]);
		}
	}

	int GetKthSmallestValue(int K)
	{
		vector<int> smallest;
		rAddSmallestElement(_pRoot, smallest, K);

		if(smallest.size() == K)
			return smallest[smallest.size() - 1];
		else
			throw "Tree size is smaller than requested size"; 
	}

	void PrintBST(TraverseOrder order)
	{
		switch(order)
		{
		case InOrder:
			rInOrderTraverse(_pRoot);
			break;
		case PreOrder:
			rPreOrderTraverse(_pRoot);
			break;
		case PostOrder:
			rPostOrderTraverse(_pRoot);
			break;
		default:
			;
		}
	}

	int Serialize(ostream& stream)
	{
		int byte_count = 0;
		rPreOrderSerialize(_pRoot, stream, byte_count);
		return byte_count;
	}

	void Deserialize(istream& stream)
	{
		if (stream.eof())
			_pRoot = NULL;
		else
		{
			char c = 0;
			stream >> c;

			if (c == 'n')
				_pRoot = NULL;
			else
				_pRoot = rPreOrderDeserialize(stream);
		}
	}

	void PrintTreeByLevel()
	{
		Queue<TreeNode> queue;

		_pRoot->Level = 0;
		queue.Enqueue(_pRoot);

		while (!queue.IsEmpty())
		{
			TreeNode* current = queue.Dequeue();

			if (current->LeftChild != NULL)
			{
				current->LeftChild->Level = current->Level + 1;
				queue.Enqueue(current->LeftChild);
			}

			if (current->RightChild != NULL)
			{
				current->RightChild->Level = current->Level + 1;
				queue.Enqueue(current->RightChild);
			}

			cout << current->Value << " ";

			if (current->Level != queue.Head()->Level)
				cout << endl;
		}
	}

	void SortAndPrintBST()
	{
		TreeNode* head = NULL;
		TreeNode* tail = NULL;
		rBuildListOutofTree(_pRoot, &head, &tail);

		while(head != NULL)
		{
			cout << head->Value << " ";
			head = head->RightChild;
		}
	}

	void FindLowestCommonAncestor(TreeNode* curNode, TreeNode* node1, TreeNode* node2, TreeNode** nodeLCA)
	{
		if (curNode->LeftChild == NULL && curNode->RightChild == NULL)
		{
			return;
		}
		else if (curNode == node1 || curNode == node2)
		{
			*nodeLCA = curNode;
		}
		else if (curNode->LeftChild == NULL)
		{
			FindLowestCommonAncestor(curNode->RightChild, node1, node2, nodeLCA);
		}
		else if (curNode->RightChild == NULL)
		{
			if (curNode == node1 && FindNodeInSubtree(curNode->LeftChild, node2)
				|| curNode == node2 && FindNodeInSubtree(curNode->LeftChild, node1))
			{
				*nodeLCA = curNode;
			}
			else
				FindLowestCommonAncestor(curNode->LeftChild, node1, node2, nodeLCA);
		}

	}

	bool FindNodeInSubtree(TreeNode* subTreeRoot, TreeNode* nodeToFind)
	{
		if (subTreeRoot == nodeToFind)
		{
			return true;
		}
		
		if (subTreeRoot->LeftChild != NULL)
		{
			return FindNodeInSubtree(subTreeRoot->LeftChild, nodeToFind);
		}
		else if (subTreeRoot->RightChild != NULL)
		{
			return FindNodeInSubtree(subTreeRoot->RightChild, nodeToFind);
		}
		else
		{
			return false;
		}
	}

	void AddValue(int value)
	{
		TreeNode* node = new TreeNode(value);

		Insert(node);
	}

	TreeNode* SearchNode(int key)
	{
		TreeNode* current = _pRoot;

		while (current != NULL)
		{
			if (current->Value == key)
				return current;
			else if (current->Value < key)
				current = current->RightChild;
			else
				current = current->LeftChild;
		}

		return NULL;
	}

	TreeNode* FindSmallest()
	{
		TreeNode* current = _pRoot;
		while (current->LeftChild != NULL)
		{
			current = current->LeftChild;
		}

		return current;
	}

	TreeNode* FindLargest()
	{
		TreeNode* current = _pRoot;
		while (current->RightChild != NULL)
		{
			current = current->RightChild;
		}

		return current;
	}

	void Insert(TreeNode* node)
	{
		TreeNode* current = _pRoot;
		TreeNode* parent = NULL;
		
		while (current != NULL)
		{
			parent = current;
			if (current->Value <= node->Value)
				current = current->RightChild;
			else
				current = current->LeftChild;
		}

		node->Parent = parent;

		if (parent == NULL)
			_pRoot = node;
		else if (node->Value < parent->Value)
			parent->LeftChild = node;
		else
			parent->RightChild = node;
	}

	void Delete(TreeNode* node)
	{
		TreeNode* current = NULL;

		if (node->LeftChild == NULL || node->RightChild == NULL)
			current = node;
		else
			current = FindSuccessor(node);

		TreeNode* next = NULL;
		if (current->LeftChild != NULL)
			next = current->LeftChild;
		else if (current->RightChild != NULL)
			next = current->RightChild;

		if (next != NULL)
			next->Parent = current->Parent;

		if (current->Parent == NULL)
			_pRoot = next;
		else if (current == current->Parent->LeftChild)
			current->Parent->LeftChild = next;
		else
			current->Parent->RightChild = next;

		if (current != node)
		{
			current->Parent = node->Parent;

			current->LeftChild = node->LeftChild;
			current->RightChild = node->RightChild;

			if (node->Parent == NULL)
				_pRoot = current;
			else if (node == node->Parent->LeftChild)
				node->Parent->LeftChild = current;
			else 
				node->Parent->RightChild = current;
		}
	}

	TreeNode* FindSuccessor(TreeNode* node)
	{
		TreeNode* successor = node;
		if (node->RightChild != NULL)
		{
			successor = node->RightChild;
			while (successor->LeftChild != NULL)
				successor = successor->LeftChild;
		}

		return successor;
	}

	void InOrderLoopTraverse()
	{
		Stack<TreeNode> stack(8);

		stack.Push(*_pRoot);

		while(!stack.IsEmpty())
		{
			if (stack.Top().LeftChild != NULL && stack.Top().LeftChild->Visited == false)
				stack.Push(*stack.Top().LeftChild);
			else
			{
				TreeNode& node = stack.Pop();
				node.Visited = true;
				cout << node.Value << " ";

				if (node.RightChild != NULL)
					stack.Push(*node.RightChild);
			}
		}
	}

	void PreOrderLoopTraverse()
	{
		Stack<TreeNode> stack(8);

		stack.Push(*_pRoot);

		while(!stack.IsEmpty())
		{
			TreeNode& node = stack.Pop();

			cout << node.Value << " ";
			
			if (node.RightChild != NULL)
				stack.Push(*node.RightChild);
			
			if (node.LeftChild != NULL)
				stack.Push(*node.LeftChild);
		}
	}
	
	void PostOrderLoopTraverse()
	{
		Stack<TreeNode> stack(8);

		stack.Push(*_pRoot);

		while(!stack.IsEmpty())
		{
			TreeNode& node = stack.Top();

			if (node.RightChild != NULL && node.RightChild->Visited == false)
				stack.Push(*node.RightChild);

			if (node.LeftChild != NULL && node.LeftChild->Visited == false)
				stack.Push(*node.LeftChild);

			if ((node.LeftChild == NULL || node.LeftChild->Visited == true)
				&& (node.RightChild == NULL || node.RightChild->Visited == true))
			{
				cout << node.Value << " ";
				node.Visited = true;
				stack.Pop();
			}
		}
	}
	
private:
	/*
	void rAddNode(TreeNode* srcNode, TreeNode* nodeToAdd)
	{
		if (srcNode->Value > nodeToAdd->Value)
		{
			if (srcNode->LeftChild == NULL)
			{
				srcNode->LeftChild = nodeToAdd;
			}
			else
			{
				rAddNode(srcNode->LeftChild, nodeToAdd);
			}
		}
		else
		{
			if (srcNode->RightChild == NULL)
			{
				srcNode->RightChild = nodeToAdd;
			}
			else
			{
				rAddNode(srcNode->RightChild, nodeToAdd);
			}
		}
	}
	*/
	void rAddSmallestElement(TreeNode* curNode, vector<int>& smallest, int K)
	{
		if (smallest.size() == K)
			return;

		if (curNode->LeftChild != NULL)
			rAddSmallestElement(curNode->LeftChild, smallest, K);

		if (smallest.size() < K)
			smallest.push_back(curNode->Value);
		
		if (smallest.size() < K && curNode->RightChild != NULL)
			rAddSmallestElement(curNode->RightChild, smallest, K);
	}

	void rBuildListOutofTree(TreeNode* node, TreeNode** head, TreeNode** tail)
	{
		if (node->LeftChild != NULL)
		{
			rBuildListOutofTree(node->LeftChild, head, tail);

			(*tail)->RightChild = node;
			node->LeftChild = *tail;
		}
		else
		{
			*head = node;
		}

		if (node->RightChild != NULL)
		{
			TreeNode* rightHead;
			rBuildListOutofTree(node->RightChild, &rightHead, tail);

			node->RightChild = rightHead;
			rightHead->LeftChild = node;
		}
		else
		{
			*tail = node;
		}
	}

	TreeNode* rFindLargestNode(TreeNode* node)
	{
		if (node->RightChild == NULL)
			return node;
		else
			return rFindLargestNode(node->RightChild);
	}

	TreeNode* rFindSmallestNode(TreeNode* node)
	{
		if (node->LeftChild == NULL)
			return node;
		else
			return rFindSmallestNode(node->RightChild);
	}

	TreeNode* rSearchNode(TreeNode* node, int key)
	{
		if (node->Value == key)
			return node;
		else if (node->Value < key)
			return node->RightChild == NULL ? NULL : rSearchNode(node->RightChild, key);
		else 
			return node->LeftChild == NULL ? NULL : rSearchNode(node->LeftChild, key);
	}

	void rInOrderTraverse(TreeNode* node)
	{
		if (node->LeftChild != NULL)
			rInOrderTraverse(node->LeftChild);

		cout << node->Value << " ";

		if (node->RightChild != NULL)
			rInOrderTraverse(node->RightChild);
	}

	void rPreOrderTraverse(TreeNode* node)
	{
		cout << node->Value << " ";

		if (node->LeftChild != NULL)
			rPreOrderTraverse(node->LeftChild);

		if (node->RightChild != NULL)
			rPreOrderTraverse(node->RightChild);
	}

	void rPreOrderSerialize(TreeNode* node, ostream& stream, int& byte_count)
	{
		if (node->LeftChild == NULL && node->RightChild == NULL)
			stream << 'L' << node->Value;
		else
			stream << 'N' << node->Value;

		byte_count += 5;

		if (node->LeftChild != NULL)
			rPreOrderSerialize(node->LeftChild, stream, byte_count);
		else
		{
			stream << 'n' ;
			byte_count += 1;
		}

		if (node->RightChild != NULL)
		{
			rPreOrderSerialize(node->RightChild, stream, byte_count);
		}
		else
		{
			stream << 'n';
			byte_count += 1;
		}
	}

	TreeNode* rPreOrderDeserialize(istream& stream)
	{
		TreeNode* node = NULL;
		try
		{
			if (!stream.eof())
			{
				int value = 0;
				stream >> value; 
				node = new TreeNode(value);

				char c;
				stream >> c;
				if (c != 'n')
					node->LeftChild = rPreOrderDeserialize(stream);
				else
					node->LeftChild = NULL;

				stream >> c;
				if (c != 'n')
					node->RightChild = rPreOrderDeserialize(stream);
				else
					node->RightChild = NULL;
			}

			return node;
		}
		catch(...)
		{
			if (node != NULL)
				delete node;

			throw "stream is corrupted.";
		}
	}

	void rPostOrderTraverse(TreeNode* node)
	{
		if (node->LeftChild != NULL)
			rPostOrderTraverse(node->LeftChild);

		if (node->RightChild != NULL)
			rPostOrderTraverse(node->RightChild);

		cout << node->Value << " ";
	}
};