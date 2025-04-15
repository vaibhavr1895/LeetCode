public IList<IList<int>> Permute(int[] nums) {
    List<IList<int>> retVal = new List<IList<int>>();
    retVal.Add(new List<int>());

    foreach(var n in nums){
        List<IList<int>> newPerms = new List<IList<int>>();
        foreach(var r in retVal){
            for(int i = 0; i < r.Count + 1; i++){
                var copy = new List<int>(r);
                copy.Insert(i, n);
                newPerms.Add(copy);
            }
        }
        retVal = newPerms;
    }

    return retVal;
}