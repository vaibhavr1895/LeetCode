using System.Collections.Generic;
using System;

public IList<string> RestoreIpAddresses(string s)
{
    List<string> result = new List<string>();
    BackTrack(0, s, "", 0, result);
    return result;
}

private void BackTrack(int i, string s, string curIP, int dots, List<string> result)
{
    if (dots == 4 && i == s.Length)
    {
        result.Add(curIP.Substring(0, curIP.Length - 1));
    }

    if (dots > 4)
    {
        return;
    }

    for (int j = i; j < Math.Min(i + 3, s.Length); j++)
    {
        if (int.Parse(s.Substring(i, j - i + 1)) <= 255 && (i == j || s[i] != '0'))
        {
            BackTrack(j + 1, s, curIP + s.Substring(i, j - i + 1) + '.', dots + 1, result);
        }
    }
}