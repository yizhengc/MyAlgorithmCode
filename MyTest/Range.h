#include <math.h>;
#include <algorithm>;
#include <vector>;

using namespace std;

class RangeNode
{
public:
	int LB;
	int RB;

	RangeNode* LN;
	RangeNode* RN;

	RangeNode(int lb, int rb)
	{
		LB = lb;
		RB = rb;
		LN = RN = NULL;
	}

	bool IsOverlapWith(RangeNode* node)
	{
		return (node->LB > LB && node->LB < RB || LB < node->RB && LB > node->LB);
	}

	void MergeRange(RangeNode* node)
	{
		LB = min(LB, node->LB);
		RB = max(RB, node->RB);
	}

};

class RangeSet
{
	RangeNode* MergeRanges(RangeNode* left, int leftLength, RangeNode* right, int rightLength)
	{
		vector<RangeNode> nodes;

		for (int idx1 = 0, idx2 = 0; idx1 < leftLength && idx2 < rightLength; )
		{
			if (left[idx1].IsOverlapWith(right + idx2))
			{
				left[idx1].MergeRange(right + idx2);
				idx2++;
			}
			else if (left[idx1].IsOverlapWith(left + idx1 + 1))
			{
				left[idx1 + 1].MergeRange(left + idx1);
				idx1++;
			}
			else
			{
				nodes.push_back(left[idx1]);
				idx1++;
			}
		}
	}
};

class RangeTree
{
private:
	RangeNode* _root;

public:
	void Insert(int lb, int rb)
	{
		RangeNode* node = new RangeNode(lb, rb);

		if (_root == NULL)
		{
			_root = node;
		}

		RangeNode* current = _root;
		bool insertNode = true;

		while(true)
		{
			if (!current->IsOverlapWith(node))
			{
				if (node->RB <= current->LB)
				{
					if (current->LN == NULL)
					{
						if (insertNode)
							current->LN = node;

						break;
					}
					else
						current = current->LN;
				}
				else if (node->LB >= current->RB)
				{
					if (current->RN == NULL)
					{
						if (insertNode)
							current->RN = node;

						break;
					}
					else
						current = current->RN;
				}
			}
			else if (current->LN != NULL)
			{
				if (!current->LN->IsOverlapWith(node))
				{
					current->MergeRange(node);
				}
			}
		}
	}

	void UpdateSubtree(RangeNode* root, RangeNode* node)
	{
		if (!root->IsOverlapWith(node))
			return;

		RangeNode* current = root;

		while(current != NULL)
		{
			if (current->LB
		}
	}

private:

}