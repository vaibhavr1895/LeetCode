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