using System.Collections.Generic;

public int ClimbStairs(int n)
{
    Dictionary<int, int> memo = new Dictionary<int, int>();

    return Climb(0, n, memo);
}

private int Climb(int i, int n, Dictionary<int, int> memo)
{
    if (n == i)
    {
        return 1;
    }
    if (i > n)
    {
        return 0;
    }
    if (memo.ContainsKey(i))
    {
        return memo[i];
    }
    var c = Climb(i + 1, n, memo) + Climb(i + 2, n, memo);
    memo.Add(i, c);
    return c;
}