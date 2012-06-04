#ifndef __STACK_H__
#define __STACK_H__

template <typename T>
class Stack
{
private:
	T** _ary;
	int _top;
	int _size;

public:
	Stack(int size)
	{
		_top = -1;
		_ary = new T*[size];
		_size = size;
	}

	~Stack()
	{
		delete _ary;
	}

	void Push(T& e)
	{
		if (_top + 1 >= _size)
		{
			_ary = new T*[_size*=2];
		}

		_ary[++_top] = &e;	
	}

	T& Pop()
	{
		return *(_ary[_top--]);
	}

	T& Top()
	{
		return *(_ary[_top]);
	}

	bool IsEmpty()
	{
		return _top == -1;
	}
};

#endif