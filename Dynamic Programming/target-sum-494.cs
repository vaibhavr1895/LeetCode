using System.Collections.Generic;

public int FindTargetSumWays(int[] nums, int target)
{
    Dictionary<(int, int), int> keyValuePairs = new Dictionary<(int, int), int>();

    int BackTrack(int i, int total)
    {
        if (i == nums.Length)
        {
            return total == target ? 1 : 0;
        }

        if (keyValuePairs.ContainsKey((i, total)))
        {
            return keyValuePairs[(i, total)];
        }

        keyValuePairs[(i, total)] = BackTrack(i + 1, total + nums[i]) + BackTrack(i + 1, total - nums[i]);

        return keyValuePairs[(i, total)];
    }

    return BackTrack(0, 0);
}