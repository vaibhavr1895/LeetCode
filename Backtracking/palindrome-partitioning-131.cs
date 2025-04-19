public IList<IList<string>> Partition(string s) {
    List<IList<string>> retVal = new List<IList<string>>();

    List<string> palindromes = new List<string>();

    DFS(retVal, s, palindromes, 0);
    return retVal;
}

private void DFS(IList<IList<string>> retVal, string s, List<string> subset, int i){
    if(i >= s.Length){
        retVal.Add(new List<string>(subset));
        return;
    }

    for(int j = i; j < s.Length; j++){
        if(IsPalindrome(s, i, j)){
            subset.Add(s.Substring(i, j - i + 1));
            DFS(retVal, s, subset, j + 1);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}

private bool IsPalindrome(string s, int i, int j){
    while(i <= j){
        if(s[i] != s[j]){
            return false;
        }
        i++;
        j--;
    }
    return true;
}