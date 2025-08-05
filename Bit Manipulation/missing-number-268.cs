public int MissingNumber(int[] nums)
{
    int full = nums.Length;
    int missing = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        full = full ^ i;
        missing = missing ^ nums[i];
    }

    return full ^ missing;
}