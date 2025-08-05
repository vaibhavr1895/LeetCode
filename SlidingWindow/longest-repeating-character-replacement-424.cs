// O(n) time
// O(1) space or O(26) space

public int CharacterReplacement(string s, int k) {
	int[] charCount = new int[26];
	int left = 0;
	int right = 0;
	int ans = 0;
	int maxCount = 0;

	while(right < s.Length){
		charCount[s[right] - 'A'] = charCount[s[right] - 'A'] + 1;
		maxCount = Math.Max(charCount[s[right] - 'A'], maxCount);
		int total = right - left + 1 - maxCount;
		if(total <= k){
			ans = Math.Max(ans, right - left + 1);
		}else{
			charCount[s[left] - 'A'] = charCount[s[left] - 'A'] - 1;
			left++;
		}
		right++;
	}
	return ans;
}