public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0){
            return 0;
        }

        HashSet<int> set = new HashSet<int>();
        foreach(var n in nums){
            if(!set.Contains(n)){
                set.Add(n);
            }
        }

        int max =0;
        int curMax = 1;

        foreach(var elem in set){
            if(set.Contains(elem - 1)){
                continue;
            }

            while(set.Contains(elem + curMax)){
                curMax++;
            }
            max = Math.Max(curMax, max);
            curMax = 1;
        }
        return max;
    }