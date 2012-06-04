// Rotate a nxn matrix
void RotateMatrix(int** matrix, int n)
{
	int startX = 0;
	int endX = n - 1;
	int endY = (n - 1)/ 2;

	for(int y = 0; y <= endY; y++)
	{
		for (int x = startX; x < endX; x++)
		{
			int temp = matrix[y][x];
			matrix[y][x] = matrix[n - 1 - x][y];
			matrix[n - 1 - x][y] = matrix[n - 1 - y][n - 1 - x];
			matrix[n - 1 - y][n - 1 - x] = matrix[x][n - 1 - y];
			matrix[x][n - 1 - y] = temp;
		}

		startX++;
		endX--;
	}
}

void PrintMatrix(int** matrix, int size)
{
	for(int r = 0; r < size; r++)
	{
		for(int c = 0; c < size; c++)
		{
			cout << matrix[r][c] << " ";
		}

		cout << endl;
	}
}

void TestRotateMatrix()
{
	int matrix[5][5] = {{1, 2, 3, 4, 5}, {6, 7, 8, 9, 10}, {11, 12, 13, 14, 15}, {16, 17, 18, 19, 20}, {21, 22, 23, 24, 25}};

	int** realMatrix = new int*[5];

	for(int i = 0; i < 5; i++)
	{
		realMatrix[i] = matrix[i];
	}

	PrintMatrix(realMatrix, 5);

	RotateMatrix(realMatrix, 5);

	PrintMatrix(realMatrix, 5);
}