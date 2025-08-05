public int LongestPalindrome(string s)
{
    Dictionary<char, int> map = new Dictionary<char, int>();

    int result = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (map.ContainsKey(s[i]))
        {
            map[s[i]]++;
        }
        else
        {
            map.Add(s[i], 1);
        }
        if (map[s[i]] % 2 == 0)
        {
            result += 2;
        }
    }

    foreach (var m in map)
    {
        if (m.Value % 2 == 1)
        {
            result += 1;
            break;
        }
    }
    return result;
}