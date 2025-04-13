public IList<IList<int>> Subsets(int[] nums) {
        List<int> subset = new List<int>();
        List<IList<int>> retVal = new List<IList<int>>();

        DFS(0, retVal, nums, subset);
        return retVal;
    }

    private void DFS(int i, IList<IList<int>> retVal, int[] nums, List<int> subset){
        if(i >= nums.Length){
            var newSubset = new List<int>(subset);;
            retVal.Add(newSubset);
            return;
        }

        subset.Add(nums[i]);
        DFS(i + 1, retVal, nums, subset);

        int j = subset.Count - 1;
        subset.RemoveAt(j);
        DFS(i + 1, retVal, nums, subset);
    }