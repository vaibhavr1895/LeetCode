using System;

public int MinSubArrayLen(int target, int[] nums)
{
    int minLength = int.MaxValue;
    int left = 0;
    int right = 0;
    int sum = 0;
    while (left <= right && right < nums.Length)
    {
        sum += nums[right];
        while (left <= right && sum >= target)
        {
            minLength = Math.Min(right - left + 1, minLength);
            sum -= nums[left];
            left++;
        }
        right++;
    }
    return minLength == int.MaxValue ? 0 : minLength;
}