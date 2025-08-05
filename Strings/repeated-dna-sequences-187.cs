using System.Collections.Generic;

public IList<string> FindRepeatedDnaSequences(string s)
{
    Dictionary<string, int> map = new Dictionary<string, int>();
    int i = 0;
    string curStr = "";
    while (i < s.Length && i < 10)
    {
        curStr += s[i];
        i++;
    }
    map.Add(curStr, 1);

    while (i < s.Length)
    {
        curStr = curStr.Substring(1, 9);
        curStr += s[i];
        if (map.ContainsKey(curStr))
        {
            map[curStr] += 1;
        }
        else
        {
            map.Add(curStr, 1);
        }
        i++;
    }
    List<string> result = new List<string>();
    foreach (var m in map)
    {
        if (m.Value > 1)
        {
            result.Add(m.Key);
        }
    }

    return result;
}