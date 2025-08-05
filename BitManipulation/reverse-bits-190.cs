public int ReverseBits(int n)
{
    int right = 0;
    int left = 31;
    int ans = 0;

    while (right < 32)
    {
        int temp = (n >> right) & 1;
        ans = ans | (temp << left);
        right++;
        left--;
    }

    return ans;
}