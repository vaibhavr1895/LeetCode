public IList<IList<int>> ThreeSum(int[] nums) {
         Array.Sort(nums);
        
        List<IList<int>> retVal = new List<IList<int>>();

         for(int i = 0; i< nums.Length; i++){
            int left = i + 1;
            int right = nums.Length - 1;
            if(i > 0 && nums[i] == nums[i - 1]){
                continue;
            }
            while(left < right){
                int sum = nums[left] + nums[right];
                if(nums[i] + sum == 0){
                    retVal.Add(new List<int>(){nums[i], nums[left], nums[right]});
                    left++;
                    while(nums[left] == nums[left - 1] && left < right){
                        left++;
                    }
                }

                if(nums[i] + sum < 0){
                    left++;
                }
                if(nums[i] + sum > 0){
                    right--;
                }
            }
         }
         return retVal;
    }