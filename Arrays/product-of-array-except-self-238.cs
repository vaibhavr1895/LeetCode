public int[] ProductExceptSelf(int[] nums) {
    int[] retVal = new int[nums.Length];
    int cur = 1;

    for(int i =0; i< nums.Length; i++){
        retVal[i] = 1;
        retVal[i] = cur * retVal[i];
        cur = cur * nums[i];
    }

    cur = 1;
    for(int i = nums.Length - 1; i >= 0; i--){
        retVal[i] = cur * retVal[i];
        cur = cur * nums[i];
    }

    return retVal;
}