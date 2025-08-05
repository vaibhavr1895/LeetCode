public string LongestPalindrome(string s)
{
    string result = "";
    int maxLength = 0;

    for (int i = 0; i < s.Length; i++)
    {

        // odd number pallindrom;
        int left = i;
        int right = i;

        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            if (maxLength < (right - left + 1))
            {
                maxLength = right - left + 1;
                result = s.Substring(left, maxLength);
            }
            left--;
            right++;
        }

        // even number pallindrome
        left = i;
        right = i + 1;

        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            if (maxLength < (right - left + 1))
            {
                maxLength = right - left + 1;
                result = s.Substring(left, maxLength);
            }
            left--;
            right++;
        }

    }
    return result;
}