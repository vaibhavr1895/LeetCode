// O(log n) time complexity
// O(1) space complexity

public int Search(int[] nums, int target) {
	int left = 0;
	int right = nums.Length - 1;
	int mid = 0;
	while(left <= right){
		mid = (right + left) / 2;
		if(nums[mid] < target){
			left = mid + 1;
		}else if(nums[mid] > target){
			right = mid - 1;
		}else if(nums[mid] == target){
			return mid;
		}
	}
	return nums[mid] == target ? mid : -1;
}