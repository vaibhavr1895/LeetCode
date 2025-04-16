public IList<IList<int>> SubsetsWithDup(int[] nums) {
    Array.Sort(nums);
    var retVal = new List<IList<int>>();
    var subset = new List<int>();

    DFS(nums, retVal, subset, 0);
    return retVal;
}

private void DFS(int[] nums, List<IList<int>> retVal, List<int> subset, int i){
    if (i >= nums.Length)
    {
        var copy = new List<int>(subset);
        retVal.Add(copy);
        return;
    }

    subset.Add(nums[i]);
    DFS(nums, retVal, subset, i + 1);
    subset.RemoveAt(subset.Count - 1);

    while (i + 1 < nums.Length && nums[i] == nums[i + 1])
    {
        i++;
    }
    DFS(nums, retVal, subset, i + 1);
}