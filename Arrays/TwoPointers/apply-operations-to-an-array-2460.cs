// O(n) where n is the number of elements in the nums array
// O(n) space complexity
public int[] ApplyOperations(int[] nums) {
    var n = nums.Length;

    var result = new int[n];
    
    for (var i = 0; i < n-1; i++)
    {
        if (nums[i] == nums[i+1])
        {
            nums[i] = nums[i] * 2;
            nums[i+1] = 0;
        }
    }
    var resultIndex = 0;
    for (var i = 0; i < n; i++)
    {
        if (nums[i] != 0)
        {
            result[resultIndex] = nums[i];
            resultIndex++;
        }
    }
    return result;
}