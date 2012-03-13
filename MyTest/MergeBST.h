
void rMergeBST(TreeNode* left, TreeNode* right, vector<int>& values)
{
	if (left == NULL && right == NULL)
		return;

	if (left != NULL && left->LeftChild != NULL)
		rMergeBST(left->LeftChild, right, values);

	if (right != NULL && right->LeftChild != NULL)
		rMergeBST(left, right->LeftChild, values);

	if (right == NULL || left != NULL && left->Value < right->Value)
	{
		values.push_back(left->Value);
		
		if (left->RightChild != NULL)
			rMergeBST(left->RightChild, right, values);
	}
	else
	{
		values.push_back(right->Value);
		if (right->RightChild != NULL)
			rMergeBST(left, right->RightChild, values);
	}
}

void MergeBST(TreeNode* left, TreeNode* right)
{
	TreeNode* leftCur = left;
	TreeNode* rightCur = right;

	vector<int> final;

	while (leftCur != NULL || rightCur != NULL)
	{
		if (leftCur != NULL && leftCur->LeftChild != NULL && leftCur->LeftChild->Visited == false)
		{
			leftCur = leftCur->LeftChild;
			continue;
		}
		
		if (rightCur != NULL && rightCur->LeftChild != NULL && rightCur->RightChild->Visited == false)
		{
			rightCur = rightCur->LeftChild;
			continue;
		}

		if (leftCur != NULL && leftCur->Visited)
		{
			leftCur = leftCur->Parent;
			continue;
		}

		if (rightCur != NULL && rightCur->Visited)
		{
			rightCur = rightCur->Parent;
			continue;
		}

		if (rightCur == NULL || leftCur->Value < rightCur->Value)
		{
			final.push_back(leftCur->Value);
		}
		else
		{
			final.push_back(rightCur->Value);
		}

		if (leftCur != NULL && leftCur->RightChild != NULL && leftCur->RightChild->Visited == false)
		{
			leftCur = leftCur->RightChild;
		}
	
		if (leftCur != NULL)
		{
			leftCur->Visited = true;
		}

		if (rightCur != NULL && rightCur->RightChild != NULL && rightCur->RightChild->Visited == false)
		{
			rightCur = rightCur->RightChild;
		}

		if (rightCur != NULL)
		{
			rightCur->Visited = true;
		}
	}

	for(int i = 0; i < final.size(); i++)
	{
		cout << i << " ";
	}
}

void TestMergeBST()
{
	int elements1[10] = {12, 6, 1, 8, 9, 3, 2, 4, 10, 11 };
	int elements2[10] = {10, 3, 8, 12, 1, 9, 19, 13, 16, 15};

	BinaryTree* bst1 = new BinaryTree();
	BinaryTree* bst2 = new BinaryTree();

	bst1->BuildTree(elements1, 10);
	bst2->BuildTree(elements2, 10);

	vector<int> values;
	rMergeBST(bst1->GetRoot(), bst2->GetRoot(), values);

	for(int i = 0; i < values.size(); i++)
	{
		cout << values[i] << " ";
	}

	cout << endl;

	MergeBST(bst1->GetRoot(), bst2->GetRoot());
}