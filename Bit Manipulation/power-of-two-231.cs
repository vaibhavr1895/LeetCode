public bool IsPowerOfTwo(int n)
{
    long i = 1;

    while (i < n)
    {
        i = i << 1;
    }

    return i == n;
}