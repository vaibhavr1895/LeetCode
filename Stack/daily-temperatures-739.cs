// O(n) time complexity
// O(n) space complexity
public int[] DailyTemperatures(int[] temperatures) {
	
	int[] result = new int[temperatures.Length];
	Stack<int> s = new Stack<int>();

	for(int i = 0; i < temperatures.Length; i++){
		while(s.Count() > 0 && temperatures[s.Peek()] < temperatures[i]){
			var index = s.Pop();
			result[index] = i - index;
		}
		s.Push(i);
	}

	return result;
}