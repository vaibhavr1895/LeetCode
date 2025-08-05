public char FindTheDifference(string s, string t)
{
    int[] chars = new int[26];

    int i = 0;
    int j = 0;

    while (i < s.Length || j < t.Length)
    {
        if (i < s.Length)
        {
            chars[s[i] - 'a'] -= 1;
        }
        i++;
        if (j < t.Length)
        {
            chars[t[j] - 'a'] += 1;
        }
        j++;
    }
    i = 0;
    while (i < 26)
    {
        if (chars[i] > 0)
        {
            return (char)(i + 'a');
        }
        i++;
    }

    return ' ';
}