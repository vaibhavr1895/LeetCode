// O(n) time
// O(1) space

public bool CheckInclusion(string s1, string s2) {
	if(s1.Length > s2.Length){
		return false;
	}

	int[] arr1 = new int[26];
	int[] arr2 = new int[26];

	for(int i = 0; i < s1.Length; i++){
		arr1[s1[i] - 'a']++;
		arr2[s2[i] - 'a']++;
	}

	int left = 0;

	while(left < s2.Length - s1.Length){
		if(Matches(arr1, arr2)){
			return true;
		}
		arr2[s2[left + s1.Length] - 'a']++;
		arr2[s2[left] - 'a']--;
		left++;
	}
	return Matches(arr1, arr2);
}

private bool Matches(int[] arr1, int[] arr2){
	for(int i =0; i< 26; i++){
		if(arr1[i] != arr2[i]){
			return false;
		}
	}
	return true;
}