// O(n) time complexity
// O(n) space complexity
public int[] PivotArray(int[] nums, int pivot) {
    int[] res = new int[nums.Length];

    int left = 0;
    int right = nums.Length - 1;
    int i = 0;
    int j = nums.Length - 1; 
    while(right >= 0 && left < nums.Length){
        if(nums[left] < pivot){
            res[i] = nums[left];
            i++;
        }

        if(nums[right] > pivot){
            res[j] = nums[right];
            j--;
        }
        left++;
        right--;
    }

    while(i <= j){
        res[i] = pivot;
        i++;
    }

    return res;
}