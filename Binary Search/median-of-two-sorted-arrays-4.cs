// O(Log(m + n)) time complexity
// O(1) space complexity
public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
	if(nums1.Length > nums2.Length){
		int[] temp = nums1;
		nums1 = nums2;
		nums2 = temp;
	}

	int m = nums1.Length;
	int n = nums2.Length;
	int l = 0;
	int r = m;
	
	while(true){
		int mid1 = (l + r)/2; // nums1
		int mid2 = ((m + n +1)/2) - mid1; // nums2

		int nums1Left = mid1 > 0 ? nums1[mid1 - 1] : int.MinValue;
		int nums1Right = (mid1) < m ? nums1[mid1] : int.MaxValue;
		
		int nums2Left = mid2 > 0 ? nums2[mid2 - 1] : int.MinValue;
		int nums2Right = mid2 < n ? nums2[mid2] : int.MaxValue;

		if(nums1Left <= nums2Right && nums2Left <= nums1Right){ // Correct partition
			if((m + n) % 2 == 0){ // even numbers
				return (Math.Max(nums1Left, nums2Left) + Math.Min(nums2Right, nums1Right)) / 2.0;
			}
			return Math.Max(nums1Left, nums2Left); // odd numbers
		}else if(nums1Left > nums2Right){
			r = mid1 - 1;
		}else{
			l = mid1 + 1;
		}
	}

	throw new ArgumentException("Input arrays are not sorted.");
}



// O(m+n) time complexity
// O(1) space complexity
public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
	int i = 0; 
	int j = 0;
	int k =0;
	int[] res = new int[nums1.Length + nums2.Length];
	while(i < nums1.Length || j < nums2.Length){
		if(i < nums1.Length && j < nums2.Length){
			if(nums1[i] < nums2[j]){
				res[k] = nums1[i];
				i++;
			}else{
				res[k] = nums2[j];
				j++;
			}
		}else if(i < nums1.Length){
			res[k] = nums1[i];
			i++;
		}else if(j < nums2.Length){
			res[k] = nums2[j];
			j++;
		}
		k++;
	}

	if((nums1.Length + nums2.Length) % 2 == 0){
		int mid = (nums1.Length + nums2.Length) / 2;
		double retVal = (res[mid] + res[mid - 1])/2.0;
		return retVal;
	}else{
		return res[(nums1.Length + nums2.Length)/2];
	}
}