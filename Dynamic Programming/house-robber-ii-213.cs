using System;

public int Rob(int[] nums)
{
    int first = 0;
    int second = 0;
    if (nums.Length == 1)
    {
        return nums[0];
    }
    for (int i = 1; i < nums.Length; i++)
    {
        int temp = Math.Max(second, first + nums[i]);
        first = second;
        second = temp;
    }

    int newFirst = 0;
    int newSecond = 0;

    for (int i = 0; i < nums.Length - 1; i++)
    {
        int temp = Math.Max(newSecond, newFirst + nums[i]);
        newFirst = newSecond;
        newSecond = temp;
    }

    return Math.Max(newSecond, second);
}