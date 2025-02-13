// O(log n) time complexity
// O(1) space complexity
public int FindMin(int[] nums) {
	int left = 0;
	int right = nums.Length - 1;
	int res = nums[0];
	while(left <= right){
		if(nums[left] < nums[right]){
			res = Math.Min(res, nums[left]);
			break;
		}

		int m = (left + right)/2;
		res = Math.Min(res, nums[m]);

		if(nums[m] >= nums[left]){
			left = m + 1;
		}else if (nums[m] < nums[right]){
			right = m - 1;
		}

	}

	return res;
}