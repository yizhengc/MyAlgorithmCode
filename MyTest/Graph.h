#include "Queue.h";

enum Color
{
	White = 0,
	Grey,
	Black
};

class Vertex
{
public:
	int Value;
	Color Color; 
	Vertex* Neighbors;

	Vertex(int value)
	{
		Value = value;
		Color = White;
		Neighbors = NULL;
	}
}

void BFS(Vertex* start)
{
	Queue<Vertex> queue;

	queue.Enqueue(start);

	while(!queue.IsEmpty())
	{

	}
}

void DFS(Vertex* start)
{
}