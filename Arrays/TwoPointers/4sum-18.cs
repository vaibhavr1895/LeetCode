using System.Collections.Generic;
using System;

public IList<IList<int>> FourSum(int[] nums, int target)
{
    Array.Sort(nums);
    IList<IList<int>> allQuadruplets = new List<IList<int>>();
    for (int i = 0; i < nums.Length - 3; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1])
        {
            continue;
        }
        for (int j = i + 1; j < nums.Length - 2; j++)
        {
            if (j > i + 1 && nums[j] == nums[j - 1])
            {
                continue;
            }

            int low = j + 1;
            int high = nums.Length - 1;
            long targetSum = (long)target - nums[i] - nums[j];
            while (low < high)
            {
                long currentSum = (long)nums[low] + nums[high];
                if (currentSum == targetSum)
                {
                    allQuadruplets.Add(new List<int>() { nums[i], nums[j], nums[low], nums[high] });
                    while (low < high && nums[low] == nums[low + 1])
                    {
                        low++;
                    }
                    while (high > low && nums[high] == nums[high - 1])
                    {
                        high--;
                    }
                    low++;
                    high--;
                }
                else if (currentSum > targetSum)
                {
                    high--;
                }
                else
                {
                    low++;
                }
            }
        }
    }
    return allQuadruplets;
}