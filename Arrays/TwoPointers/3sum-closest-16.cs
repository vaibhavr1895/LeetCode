using System;

public int ThreeSumClosest(int[] nums, int target)
{
    Array.Sort(nums);
    int difference = int.MaxValue;
    int sum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        int low = i + 1;
        int high = nums.Length - 1;
        while (low < high)
        {
            int currentSum = nums[i] + nums[low] + nums[high];
            int currentDifference = Math.Abs(target - currentSum);
            if (currentDifference < difference)
            {
                difference = currentDifference;
                sum = currentSum;
            }

            if (currentSum == target)
            {
                return currentSum;
            }
            else if (currentSum > target)
            {
                high--;
            }
            else
            {
                low++;
            }
        }
    }

    return sum;
}