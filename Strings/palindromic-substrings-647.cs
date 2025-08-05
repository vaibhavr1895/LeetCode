public int CountSubstrings(string s)
{
    int result = 0;

    for (int i = 0; i < s.Length; i++)
    {
        int l = i;
        int r = i;
        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            result++;
            l--;
            r++;
        }

        l = i;
        r = i + 1;
        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            result++;
            l--;
            r++;
        }
    }
    return result;
}