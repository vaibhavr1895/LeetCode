// o(LOG(M*N)) time complexity
// O(1) space complexity
public bool SearchMatrix(int[][] matrix, int target) {
	var rows = matrix.GetLength(0);
	var cols = matrix[0].GetLength(0);

	int rStart = 0;
	int rEnd = rows - 1;
	int row = 0;
	while(rStart <= rEnd)
	{
		row = (rStart + rEnd) / 2;

		if (target > matrix[row][cols - 1])
		{
			rStart = row + 1;
		}
		else if(target < matrix[row][0])
		{
			rEnd = row - 1;
		}
		else
		{
			break;
		}
	}

	if(rStart > rEnd)
	{
		return false;
	}

	int left = 0;
	int right = cols - 1;
	int mid = 0;
	while(left <= right)
	{
		mid = (left + right) / 2;

		if(target > matrix[row][mid])
		{
			left = mid + 1;
		}else if (target < matrix[row][mid])
		{
			right = mid - 1;
		}
		else
		{
			return true;
		}
	}

	return false;
}