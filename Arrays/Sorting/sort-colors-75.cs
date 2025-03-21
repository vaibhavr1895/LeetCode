// Quick Sort
// Time complexity O(n)
// Space complexity O(1)
public void SortColors(int[] nums) {
    int i = 0;
    int left = 0;
    int right = nums.Length - 1;

    while(i <= right){
        if(nums[i] == 0){
            Swap(nums, i, left);
            left++;
        }else if(nums[i] == 2){
            Swap(nums, i, right);
            right--;
            i--;
        }
        i++;
    }
}

private void Swap(int[] nums, int i, int j){
    int temp = nums[i];
    nums[i] = nums[j];
    nums[j] = temp;
}