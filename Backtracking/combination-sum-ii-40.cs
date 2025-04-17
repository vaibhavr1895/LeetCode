public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
    Array.Sort(candidates);
    var retVal = new List<IList<int>>();
    var subset = new List<int>();

    DFS(0, target, 0, subset, retVal, candidates);
    return retVal;
}

private void DFS(int i, int target, int curSum, List<int> subset, List<IList<int>> retVal, int[] candidates){
    
    if(curSum == target){
        var copy = new List<int>(subset);
        retVal.Add(copy);
        return;
    }
    if(curSum > target){
        return;
    }
    if (i >= candidates.Length)
    {
        return;
    }
    
    subset.Add(candidates[i]);
    DFS(i + 1, target, curSum + candidates[i], subset, retVal, candidates);
    subset.RemoveAt(subset.Count - 1);

    while(i + 1 < candidates.Length && candidates[i] == candidates[i + 1]){
        i++;
    }
    DFS(i + 1, target, curSum, subset, retVal, candidates);
}