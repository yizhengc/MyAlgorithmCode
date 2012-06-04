using namespace std;

namespace Util
{

#define ARRAYSIZE(a) sizeof(a) / sizeof(*(a))

	inline void PrintArray(int elements[], int size)
	{
		for(int i = 0; i < size; i++)
		{
			cout << elements[i] << " ";
		}

		cout << endl;
	}

	inline void PrintArray(char* elements[], int size)
	{
		for(int i = 0; i < size; i++)
		{
			cout << elements[i] << endl;
		}
	}

	template<class T> inline  int Max(T* elements, int sz)
	{
		T max = elements[0];
		for (int i = 0; i < sz; i++)
		{
			if (elements[i] > max)
			{
				max = elements[i];
			}
		}

		return max;
	}

	template<class T>  inline int Min(T* elements, int sz)
	{
		T min = elements[0];
		for (int i = 0; i < sz; i++)
		{
			if (elements[i] < min)
			{
				min = elements[i];
			}
		}

		return min;
	}

	template <typename T>
	class SortingUtil
	{
	public:
		static void DutchFlagSort(T elements[], int size, T lowValue, T highValue)
		{
			int low = -1;
			int high = size;

			for (int i = 0; i < high; )
			{
				if (elements[i] < lowValue)
				{
					Swap(elements[i], elements[++low]);
					i++;
				}
				else if (elements[i] >= highValue)
				{
					Swap(elements[i], elements[--high]);
				}
				else
				{
					i++;
				}
			}
		}

		static void QuickSort(T elements[], int low, int high, int (*Comparer)(T&,T&))
		{
			if (low < high)
			{
				int pivot = (high - low) / 2 + low;

				Swap(elements[pivot], elements[high - 1]);

				int q = low;
				int i;
				for (i = low; i < high - 1; i++) 
				{
					if ((*Comparer)(elements[i], elements[high - 1]) < 0)
					{
						Swap(elements[i], elements[q++]);
					}
				}

				Swap(elements[q], elements[high - 1]);

				QuickSort(elements, low, q);
				QuickSort(elements, q + 1, high);
			}
		}
		
		static void Swap(T& a, T& b)
		{
			T temp = a;
			a = b;
			b = temp;
		}
	};
}