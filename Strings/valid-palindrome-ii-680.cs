public bool ValidPalindrome(string s)
{
    int left = 0;
    int right = s.Length - 1;
    int uniqueChar = 0;
    while (left <= right)
    {
        if (s[left] == s[right])
        {
            left++;
            right--;
            continue;
        }
        break;
    }

    return IsPallindrome(s, left + 1, right) || IsPallindrome(s, left, right - 1);
}

private bool IsPallindrome(string s, int left, int right)
{
    while (left <= right)
    {
        if (s[left] != s[right])
        {
            return false;
        }
        left++;
        right--;
    }
    return true;
}