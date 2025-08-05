using System;

public int LongestIncreasingPath(int[][] matrix)
{
    int maxLength = 0;
    int rows = matrix.Length;
    int columns = matrix[0].Length;
    int[,] cache = new int[rows, columns];

    int DFS(int r, int c, int prevNum)
    {
        if (r < 0 || c >= columns || r >= rows || c < 0)
        {
            return 0;
        }

        if (prevNum >= matrix[r][c])
        {
            return 0;
        }

        if (cache[r, c] > 0)
        {
            return cache[r, c];
        }

        int ans = 1 + Math.Max(DFS(r + 1, c, matrix[r][c]), Math.Max(DFS(r - 1, c, matrix[r][c]), Math.Max(DFS(r, c + 1, matrix[r][c]), DFS(r, c - 1, matrix[r][c]))));
        maxLength = Math.Max(ans, maxLength);
        cache[r, c] = ans;
        return cache[r, c];
    }

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            DFS(i, j, -1);
        }
    }
    return maxLength;
}