public int[] SingleNumber(int[] nums)
{
    long xor = 0;

    foreach (var n in nums)
    {
        xor = xor ^ n;
    }

    long rightMost = (xor & (xor - 1)) ^ xor;
    long num1 = 0;
    long num2 = 0;

    foreach (var n in nums)
    {
        if ((n & rightMost) > 0)
        {
            num1 = num1 ^ n;
        }
        else
        {
            num2 = num2 ^ n;
        }
    }

    return new int[] { (int)num1, (int)num2 };
}