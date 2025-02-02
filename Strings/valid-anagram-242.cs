 public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }
        int[] myList = new int[26];
        for(int i =0; i< s.Length; i++){
            myList[s[i] - 'a']++;
            myList[t[i] - 'a']--;
        }

        foreach(int x in myList){
            if(x!= 0){
                return false;
            }
        }
        return true;
}