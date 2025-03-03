// O(log n) time complexity
// O(1) space complexity
public int Search(int[] nums, int target) {
	int left = 0;
	int right = nums.Length - 1;
	int mid = (left + right)/2;

	while(left <= right){
		mid = (left + right)/2;
		if(nums[mid] == target){
			return mid;
		}
		
		if(nums[left] <= nums[mid]) { // left sorted portion
			if(target > nums[mid] || target < nums[left]){
				left = mid + 1;
			}else {
				right = mid - 1;
			}
		}else{ // right sorted portion
			if(target < nums[mid] || target > nums[right]){
				right = mid - 1;
			}else{
				left = mid + 1;
			}
		}
	} 

	return -1;
}