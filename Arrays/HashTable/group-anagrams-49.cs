public IList<IList<string>> GroupAnagrams(string[] strs) {
    int[] arr = new int[26];
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    foreach(var s in strs){
        for(int i =0; i<s.Length; i++){
            arr[s[i] - 'a'] = arr[s[i] - 'a'] + 1;
        }

        string key = "";
        foreach (int a in arr)
        {
            key = key + a.ToString() + "#";
        }

        if(!dict.ContainsKey(key)){
            dict[key] = new List<string>(){ s };
        }else{
            dict[key].Add(s);
        }
        arr = new int[26];
    }

    List<IList<string>> retVal = new List<IList<string>>();
    foreach(var d in dict){
        retVal.Add(d.Value);
    }

    return retVal;
}