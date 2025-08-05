using System;

public int IntegerReplacement(int n)
{
    int DFS(long num)
    {
        if (num == 1)
        {
            return 0;
        }
        int curMin = int.MaxValue;
        if (num % 2 == 0)
        {
            curMin = 1 + DFS(num / 2);
        }
        else
        {
            curMin = 1 + Math.Min(DFS(num + 1), DFS(num - 1));
        }
        return curMin;
    }

    return DFS(n);
}