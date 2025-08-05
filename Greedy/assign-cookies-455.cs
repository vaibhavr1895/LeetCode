using System;

public int FindContentChildren(int[] g, int[] s)
{
    Array.Sort(g);
    Array.Sort(s);

    int child = 0;
    int cookie = 0;
    int result = 0;
    while (child < g.Length && cookie < s.Length)
    {
        if (g[child] - s[cookie] <= 0)
        {
            result++;
            child++;
            cookie++;
        }
        else
        {
            cookie++;
        }
    }

    return result;
}
}