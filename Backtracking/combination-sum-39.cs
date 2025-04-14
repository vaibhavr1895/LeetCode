public IList<IList<int>> CombinationSum(int[] candidates, int target) {
    List<IList<int>> retVal = new List<IList<int>>();
    DFS(0, new List<int>(), retVal, candidates, 0, target);
    return retVal;
}

private void DFS(int i, List<int> cur, IList<IList<int>> retVal,
                int[] candidates, int total, int target){
    if(total == target){
        var copy = new List<int>(cur);
        retVal.Add(copy);
        return;
    }
    
    if(i >= candidates.Length || total > target){
        return;
    }

    cur.Add(candidates[i]);
    DFS(i, cur, retVal, candidates, total + candidates[i], target);

    cur.RemoveAt(cur.Count - 1);
    DFS(i + 1, cur, retVal, candidates, total, target);
}