using System;

public double FindMaxAverage(int[] nums, int k)
{
    double average = 0.0;
    int sum = 0;
    int i = 0;
    int j = 0;
    while (i < k)
    {
        sum += nums[i];
        i++;
    }
    average = (double)sum / k;

    while (i < nums.Length)
    {
        int curSum = sum - nums[j] + nums[i];
        double curAverage = (double)curSum / k;
        average = Math.Max(average, curAverage);
        sum = curSum;
        i++;
        j++;
    }
    return average;
}