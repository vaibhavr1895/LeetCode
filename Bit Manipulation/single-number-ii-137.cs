public int SingleNumber(int[] nums)
{
    int ones = 0;
    int twos = 0;

    foreach (var n in nums)
    {
        ones = (ones ^ n) & (~twos);
        twos = (twos ^ n) & (~ones);
    }

    return ones;
}