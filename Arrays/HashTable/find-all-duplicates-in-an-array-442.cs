using System.Collections.Generic;
using System;

public IList<int> FindDuplicates(int[] nums)
{
    List<int> result = new List<int>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[Math.Abs(nums[i]) - 1] < 0)
        {
            result.Add(Math.Abs(nums[i]));
        }
        else
        {
            nums[Math.Abs(nums[i]) - 1] = nums[Math.Abs(nums[i]) - 1] * -1;
        }

    }

    return result;
}