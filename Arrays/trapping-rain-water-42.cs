// Brute Force 
// O(n) time 
// O(n) space

public int Trap(int[] height) {
		int[] leftMax = new int[height.Length];
		int[] rightMax = new int[height.Length];

		int left = 0;
		for(int i =0; i< height.Length - 1; i++){
			left = Math.Max(left, height[i]);
			leftMax[i] = left;
		}

		int right = 0;
		for(int i = height.Length - 1; i >= 0; i--){
			right = Math.Max(right, height[i]);
			rightMax[i] = right;
		}
		
		int totalArea = 0;
		for(int i = 0; i < height.Length; i++){
			int curArea = Math.Min(leftMax[i], rightMax[i]) - height[i];
			if(curArea > 0){
				totalArea += curArea;
			}
		}

		return totalArea;
}

// Optimal 
// O(n) time 
// O(1) space

public int Trap(int[] height) {
		int left = 0;
		int right = height.Length - 1;

		int total = 0;
		int leftMax = height[0];
		int rightMax = height[height.Length -1];

		while(left < right){
			if(height[left] < height[right]){
				leftMax = Math.Max(leftMax, height[left]);
				var area = leftMax - height[left];
				if(area > 0){
					total += area;
				}
				left++;
			}else{
				rightMax = Math.Max(rightMax, height[right]);
				var area = rightMax - height[right];
				if(area > 0){
					total += area;
				}
				right--;
			}
		}

		return total;
	}