public bool IsPalindrome(string s) {
    
    int start = 0;
    int end = s.Length - 1;

    while(start < end){
        var c1 = s[start];
        var c2 = s[end];
        if(!IsAlphanumeric(c1)){
            start++;
            continue;
        }
        if(!IsAlphanumeric(c2)){
            end--;
            continue;
        }

        if(IsAlphanumeric(c1) && IsAlphanumeric(c2) && ToLower(c1) != ToLower(c2)){
            return false;
        }
        start++;
        end--;
    }
    return true;
}

private static bool IsAlphanumeric(char c)
{
    return c is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or >= '0' and <= '9';
}

private static char ToLower(char c)
{
    if (c is >= 'A' and <= 'Z')
        return (char)(c + 32);
    
    return c;
}