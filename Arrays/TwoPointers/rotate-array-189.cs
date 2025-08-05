public void Rotate(int[] nums, int k)
{
    k = k % nums.Length;
    Reverse(0, nums.Length - 1, nums);
    Reverse(0, k - 1, nums);
    Reverse(k, nums.Length - 1, nums);

}

private void Reverse(int i, int j, int[] nums)
{
    while (i < j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
        i++;
        j--;
    }
}