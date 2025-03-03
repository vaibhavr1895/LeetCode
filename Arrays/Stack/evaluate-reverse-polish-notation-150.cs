// O(n) time complexity
// O(n) space complexity
public int EvalRPN(string[] tokens) {
	Stack<int> nums = new Stack<int>();
	for (int i = 0; i < tokens.Length; i++)
	{
		if (!IsOperator(tokens[i]))
		{
			nums.Push(int.Parse(tokens[i]));
		}
		else
		{
			var op = tokens[i];
			int num2 = nums.Pop();
			int num1 = nums.Pop();
			int result = GetResult(num1, num2, op);
			nums.Push(result);
		}
	}
	return nums.Pop();
}

private bool IsOperator(string token)
{
	return token == "+" || token == "-" || token == "*" || token == "/";
}

private int GetResult(int num1, int num2, string op)
{
	int result = 0;
	switch (op)
	{
		case "+":
			result = num1 + num2;
			break;
		case "-":
			result = num1 - num2;
			break;
		case "*":
			result = num1 * num2;
			break;
		case "/":
			result = num1 / num2;
			break;
	}
	return result;
}