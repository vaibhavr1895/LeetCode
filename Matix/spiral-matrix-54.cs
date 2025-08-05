using System.Collections.Generic;

public IList<int> SpiralOrder(int[][] matrix)
{
    int left = 0;
    int right = matrix[0].Length;
    int top = 0;
    int bottom = matrix.Length;

    IList<int> result = new List<int>();
    while (left < right && top < bottom)
    {
        for (int i = left; i < right; i++)
        {
            result.Add(matrix[top][i]);
        }

        top++;
        for (int i = top; i < bottom; i++)
        {
            result.Add(matrix[i][right - 1]);
        }
        right--;

        if (!(left < right && top < bottom))
        {
            break;
        }
        for (int i = right - 1; i > left - 1; i--)
        {
            result.Add(matrix[bottom - 1][i]);
        }
        bottom--;
        for (int i = bottom - 1; i > top - 1; i--)
        {
            result.Add(matrix[i][left]);
        }
        left++;
    }

    return result;
}