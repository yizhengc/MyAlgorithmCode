// MyTest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h";
//#include "Sort.h";
#include "Puzzles.h";
#include "Tree.h";
#include "List.h";
#include "LongestDistanceOrderedPair.h";
#include "CumulativeCount.h";
#include "Interval.h";
#include "PyramidCup.h";
#include "MergeBST.h";
//using namespace Util;
using namespace std;



int _tmain(int argc, _TCHAR* argv[])
{
	TestMergeTwoIntervalLists();

	TestMergeInterval();

	TestMergeBST();

	int input[10] = {1, 1, 2, 4, 4, 5, 6, 7, 7, 7};

	int outSize = 0;
	int* output = ConvertArray(input, 10, outSize);

	PrintArray(output, outSize);

	char** result = PermutatePhoneNumber("425", 3, outSize);

	PrintArray(result, outSize);

	bool isMatch = SimpleRegexMatch("aba", 3, "aa?b?a*", 7);

	//SortingUtil<int>::DutchFlagSort(elements, 10, 1, 2);
	//SortingUtil<int>::QuickSort(elements, 0, 10);

	//	PrintArray(elements, 10);

	/* Reverse Singly Linked List
	ListNode* head = CreateSinglyLinkedList(elements, 10);

	head = ReverseSinglyLinkedList(head);

	PrintList(head);

	{
		CopyOnWriteString aa("abcde");

		{
			CopyOnWriteString b = aa;

			b[2] = 'B';
		}
	}


	char* result = MultiplyLargeNumber("123456789", 9, "-96", 3);

	int a[4][5] = {{1, 2, 3, 4, 5}, {6, 7, 8, 9, 10}, {11, 12, 13, 14, 15}, {16, 17, 18, 19, 20}};

	PrintMatrix(a, 5, 4);

	*/
	/*
	BinaryTree* bst = new BinaryTree();
	
	bst->BuildTree(elements, 10);

	bst->Insert(new TreeNode(8));

	int bytecount = bst->Serialize(cout);

	BinaryTree* bst2 = new BinaryTree();
	bst2->Deserialize(cin);

	bst->PrintTreeByLevel();
	bst2->PrintTreeByLevel();

	TreeNode* nodeToDel = bst->SearchNode(5);

	bst->Delete(nodeToDel);

	bst->PrintTreeByLevel();

	
	bst->PrintBST(InOrder);
	cout << endl;

	bst->InOrderLoopTraverse();
	cout << endl;
	
	bst->PrintBST(PreOrder);
	cout << endl;

	bst->PreOrderLoopTraverse();
	cout << endl;

	bst->PrintBST(PostOrder);
	cout << endl;

	bst->PostOrderLoopTraverse();
	cout << endl;

	bst->SortAndPrintBST();

	cout << bst->GetKthSmallestValue(6);

	vector<int> ary(elements, elements + 10);
	Rotate(ary, 3);

	char* ret = balanceParanthesis("(ab(ab)n2)x)", 12);
	ret =  balanceParanthesis("))", 2);
	return 0;
	*/
}


