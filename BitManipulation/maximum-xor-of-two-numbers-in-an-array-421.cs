using System;

public int FindMaximumXOR(int[] nums)
{
    int maxResult = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            maxResult = Math.Max(nums[i] ^ nums[j], maxResult);
        }
    }

    return maxResult;
}