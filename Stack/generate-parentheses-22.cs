// O(n) time complexity
// O(n) space complexity
public IList<string> GenerateParenthesis(int n) {
	Stack<string> paranthesis = new Stack<string>();
	List<string> result = new List<string>();

	GetResult(0,0, n, paranthesis, result);
	return result;
}

private void GetResult(int open, int close, int total, Stack<string> s, List<string> result){
	if (open == total && close == total)
	{
		string str = "";
		foreach(var x in s)
		{
			str = str + x;
		}
		result.Add(str);
	}

	if (open < total)
	{
		s.Push(")");
		GetResult(open + 1, close, total, s, result);
		s.Pop();
	}

	if (close < open)
	{
		s.Push("(");
		GetResult(open, close + 1, total, s, result);
		s.Pop();
	}
}   