public int RemoveDuplicates(int[] nums)
{
    int index = 1;
    int pre = 0;
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] != nums[pre])
        {
            nums[index] = nums[i];
            pre = index;
            index++;
        }
    }
    return index;
}