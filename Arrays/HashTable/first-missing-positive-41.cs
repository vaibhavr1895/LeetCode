using System;

public int FirstMissingPositive(int[] nums)
{
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] < 0)
        {
            nums[i] = 0;
        }
    }

    for (int i = 0; i < nums.Length; i++)
    {
        var currentIndex = Math.Abs(nums[i]) - 1;
        if (currentIndex >= 0 && currentIndex < nums.Length)
        {
            if (nums[currentIndex] > 0)
            {
                nums[currentIndex] *= -1;
            }
            else if (nums[currentIndex] == 0)
            {
                nums[currentIndex] = -1 * (nums.Length + 1);
            }
        }
    }

    for (int i = 1; i < nums.Length + 1; i++)
    {
        if (nums[i - 1] >= 0)
        {
            return i;
        }
    }

    return nums.Length + 1;
}