using System;

public int Rob(int[] nums)
{
    int first = 0;
    int second = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        int temp = Math.Max(second, first + nums[i]);
        first = second;
        second = temp;
    }
    return second;
}