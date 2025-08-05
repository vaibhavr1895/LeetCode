public int Fib(int n)
{
    if (n == 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }
    int prev = 0;
    int cur = 1;

    for (int i = 2; i <= n; i++)
    {
        int temp = cur;
        cur = prev + cur;
        prev = temp;
    }

    return cur;
}