public int MinBitFlips(int start, int goal)
{
    int count = 0;
    int n = start ^ goal;
    while (n > 0)
    {
        count += n & 1;
        n = n >> 1;
    }
    return count;
}