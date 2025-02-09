// O(n) time complexity
// O(n) space complexity
public int EvalRPN(string[] tokens) {
	Stack<int> nums = new Stack<int>();
	string[] operators = new string[] { "+", "-", "*", "/" };
	for (int i = 0; i < tokens.Length; i++)
	{
		if (!operators.Contains(tokens[i]))
		{
			nums.Push(int.Parse(tokens[i]));
		}
		else
		{
			var op = tokens[i];
			int[] curNums = new int[2];
			int count = 1;
			while (nums.Count() > 0 && count >= 0)
			{
				var n = nums.Pop();
				curNums[count] = n;
				count--;
			}
			int result = GetResult(curNums, op);
			nums.Push(result);
		}
	}
	return nums.Count() > 0 ? nums.Pop() : 0;
}

private int GetResult(int[] curNums, string op)
{
	int result = 0;
	switch (op)
	{
		case "+":
			result = curNums[0] + curNums[1];
			break;
		case "-":
			result = curNums[0] - curNums[1];
			break;
		case "*":
			result = curNums[0] * curNums[1];
			break;
		case "/":
			result = curNums[0] / curNums[1];
			break;
	}
	return result;
}