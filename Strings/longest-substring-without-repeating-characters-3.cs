// O(n) time
// O(n) space
public int LengthOfLongestSubstring(string s) {
	HashSet<char> set = new HashSet<char>();
	int left = 0;
	int right = 0;
	int maxLength = 0;

	while(right < s.Length){
		if(set.Contains(s[right])){
			set.Remove(s[left]);
			left++;
		}else{
			set.Add(s[right]);
			maxLength = Math.Max(maxLength, right - left + 1);
			right++;
		}
	}
	return maxLength;
}