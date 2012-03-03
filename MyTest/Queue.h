template <typename T>
class Queue
{
private:
	T** _ary;
	int _size;
	int _tail;
	int _head;

public:
	Queue()
	{
		_ary = new T*[8];
		_size = 8;
		_tail = -1;
		_head = 0;
	}

	bool IsEmpty()
	{
		return _head > _tail;
	}

	void Enqueue(T* e)
	{
		if (_tail + 1 >= _size)
			_ary = new T*[_size*=2];

		_ary[++_tail] = e;
	}

	T* Dequeue()
	{
		T* ret = _ary[_head++];

		if (IsEmpty())
		{
			_head = 0;
			_tail = -1;
		}

		return ret;
	}

	T* Head()
	{
		return _ary[_head];
	}
};