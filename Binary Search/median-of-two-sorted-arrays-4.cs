// O(Log(m + n)) time complexity
// O(1) space complexity
public double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
	if (nums1.Length > nums2.Length)
	{
		int[] temp = nums1;
		nums1 = nums2;
		nums2 = temp;
	}

	int m = nums1.Length;
	int n = nums2.Length;
	int l = 0;
	int r = m;

	while (l <= r)
	{
		int i = (l + r) / 2;
		int j = (m + n + 1) / 2 - i;

		int max1 = i > 0 ? nums1[i - 1] : int.MinValue;
		int max2 = j > 0 ? nums2[j - 1] : int.MinValue;

		int min1 = i < m ? nums1[i] : int.MaxValue;
		int min2 = j < n ? nums2[j] : int.MaxValue;

		if (max1 <= min2 && max2 <= min1)
		{
			if ((m + n) % 2 == 0)
			{
				return (Math.Max(max1, max2) + Math.Min(min1, min2)) / 2.0;
			}
			return Math.Min(min1, min2);
		}
		else if (max1 > min2)
		{
			r = i - 1;
		}
		else
		{
			l = i + 1;
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