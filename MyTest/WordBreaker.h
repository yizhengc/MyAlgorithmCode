#include <vector>;
using namespace std;

class Dictionary
{
private:
	vector<const char*> words;
public:
	bool Contains(const char* word, int length)
	{
		for(int i = 0; i < words.size(); i++)
		{
			if (strlen(words[i]) == length && strncmp(words[i], word, length) == 0)
			{
				return true;
			}
		}

		return false;
	}

	void AddWord(const char* word)
	{
		int len = strlen(word);
		if (!Contains(word, len))
			words.push_back(word);
	}
};

// Create a (N + 1) X N table R
// R[0][j] indicates the number of legit words start at this location
// R[i][j] indicates the length of the legit word
void BreakWords(const char* stream, int length, int** results, Dictionary* dict)
{
	for (int i = length - 1; i >=0; i--)
	{
		for (int j = i + 1; j <= length; j++)
		{
			if ((j == length || results[0][j] > 0) && dict->Contains(stream + i, j - i))
			{
				results[0][i]++;
				results[results[0][i]][i] = j - i;
			}
		}
	}
}

void PrintAllWords(const char* stream, int length, int** results, int start)
{
	char* buff = new char[length +1];
	for (int i = 1; i < results[0][start] + 1; i++)
	{
		strncpy(buff, stream + start, results[i][start]);
		buff[results[i][start]] = '\0';
		cout << buff;

		if (start + results[i][start] == length)
			cout << endl;
		else
		{
			cout << " ";
			PrintAllWords(stream, length, results, start + results[i][start]);
		}
	}
}

void TestWordBreaker()
{
	Dictionary* dict = new Dictionary();

	char* words[] = {"there", "are", "we", "wear", "e", "re"};

	for(int i = 0; i < 6; i++)
	{
		dict->AddWord(words[i]);
	}

	const char* stream = "thereweare";
	int len = strlen(stream);
	int** results = new int*[len + 1];
	for(int i = 0; i <= len; i++)
	{
		results[i] = new int[len];
		memset(results[i], 0, sizeof(int)*len);
	}

	BreakWords(stream, len, results, dict);

	PrintAllWords(stream, len, results, 0);
}