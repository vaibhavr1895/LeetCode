public int[] TwoSum(int[] nums, int target) {
    Dictionary<int, int> map = new Dictionary<int, int>();
    for(int i =0; i< nums.Length; i++){
        int diff = target - nums[i];
        if(map.ContainsKey(diff)){
            return new int[] { i, map[diff]};
        }
        if(!map.ContainsKey(nums[i])){
                map.Add(nums[i], i);
        }
    }

    return new int[2];
}