// Most Optimal
// O(n) time
// O(1) space
public string MinWindow(string s, string t) {
	if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length){
		return "";
	}

	int[] map = new int[128];
	int count = t.Length;
	int start = 0;
	int end = 0;
	int minLen = int.MaxValue;
	int startIndex = 0;

	foreach(var c in t){
		map[c]++;
	}

	char[] chs = s.ToCharArray();

	while(end < chs.Length){
		if(map[chs[end++]]-- > 0){
			count--;
		}

		while(count == 0){
			if(end - start < minLen){
				startIndex = start;
				minLen = end - start;
			}

			if(map[chs[start++]]++ == 0){
				count++;
			}
		}
	}

	return minLen == int.MaxValue ? "" : new string(chs, startIndex, minLen);
}


//My Solution

public string MinWindow(string s, string t) {
	if(s.Length < t.Length){
		return "";
	}
	Dictionary<char, int> subStrCount = new Dictionary<char, int>();
	for(int i =0; i< t.Length; i++){
		if(subStrCount.ContainsKey(t[i])){
			subStrCount[t[i]]++;
		}else{
			subStrCount.Add(t[i], 1);
		}
	}

	int left = 0;
	int right = 0;
	Dictionary<char, int> mainStrCount = new Dictionary<char, int>();
	mainStrCount.Add(s[right], 1);
	string minStr = "";
	while(right < s.Length && left <= right){
		var doesContain = Contains(mainStrCount, subStrCount);
		if(doesContain){
			if(mainStrCount[s[left]] > 1){
				mainStrCount[s[left]]--;
			}else{
				mainStrCount.Remove(s[left]);
			}

			if(minStr == "" || minStr.Length > right - left + 1){
				minStr = s.Substring(left, right - left + 1);
			}
			left++;
			continue;
		}
		right++;
		if(right == s.Length){
			break;
		}
		if(mainStrCount.ContainsKey(s[right])){
			mainStrCount[s[right]]++;
		}else{
			mainStrCount.Add(s[right], 1);
		}
	}

	return minStr;
}

private bool Contains(Dictionary<char, int> c1, Dictionary<char, int> c2){
	foreach(var c in c2){
		if(!c1.ContainsKey(c.Key) || c1[c.Key] < c.Value){
			return false;
		}
	}
	return true;
}