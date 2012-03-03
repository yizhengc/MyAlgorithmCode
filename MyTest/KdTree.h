#include <vector>;

using namespace std;

template <typename T>
class Point
{
private:
	T* position;

public:
	Point(int dim)
	{
		position = new T[dim];
	}

	T GetValueAtDim(int index)
	{
		return position[index];
	}
};

class KdTree
{
private:
	vector<Point<int>> points;


}