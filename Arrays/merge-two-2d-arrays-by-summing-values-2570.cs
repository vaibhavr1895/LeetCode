// O(n + m) where n is the number of elements in nums1 and m is the number of elements in nums2 time complexity
// O(n + m) where n is the number of elements in nums1 and m is the number of elements in nums2 space complexity
public int[][] MergeArrays(int[][] nums1, int[][] nums2) {
    int i = 0;
    int j =0;
    List<int[]> result = new List<int[]>();

    while(i < nums1.Length || j < nums2.Length){
        if(i < nums1.Length && j < nums2.Length){
            if(nums1[i][0] == nums2[j][0]){
                var elem = new int[]{nums1[i][0], nums1[i][1] + nums2[j][1]};
                result.Add(elem);
                i++;
                j++;
            }else if(nums1[i][0] < nums2[j][0]){
                result.Add(nums1[i]);
                i++;
            }else{
                result.Add(nums2[j]);
                j++;
            }
        }else if(i < nums1.Length){
            result.Add(nums1[i]);
            i++;
        }else{
            result.Add(nums2[j]);
            j++;
        }
    }

    return result.ToArray();
}