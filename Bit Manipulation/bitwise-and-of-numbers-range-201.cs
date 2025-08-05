public int RangeBitwiseAnd(int left, int right)
{
    int i = 1;
    if (right - left == 0)
    {
        return left;
    }
    while (i < 32)
    {
        left = left >> 1;
        right = right >> 1;
        if (left == 0 && right > 0)
        {
            return 0;
        }
        if (left == right)
        {
            break;
        }
        i++;
    }

    int j = 1;
    while (j <= i)
    {
        left = left << 1;
        j++;
    }
    return (int)left;
}