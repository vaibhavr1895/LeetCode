using System;

public int MinimumDifference(int[] nums, int k)
{
    Array.Sort(nums);

    int i = 0;
    int result = int.MaxValue;

    while (i + k - 1 < nums.Length)
    {
        result = Math.Min(result, Math.Abs(nums[i + k - 1] - nums[i]));
        i++;
    }

    return result;
}