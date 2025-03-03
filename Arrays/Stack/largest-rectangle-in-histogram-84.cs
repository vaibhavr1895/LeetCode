// O(n) time complexity
// O(n) space complexity
public int LargestRectangleArea(int[] heights) {
	Stack<int> index = new Stack<int>();
	Stack<int> height = new Stack<int>();
	int maxArea = 0;
	for(int i = 0; i < heights.Length; i++)
	{
		int startIndex = i;
		while(index.Count() > 0 && height.Peek() > heights[i])
		{
			var h = height.Pop();
			startIndex = index.Pop();
			maxArea = Math.Max(maxArea, (i - startIndex) * h);
		}
		index.Push(startIndex);
		height.Push(heights[i]);
	}

	while(height.Count() > 0)
	{
		var h = height.Pop();
		var i = index.Pop();
		maxArea = Math.Max(maxArea, (heights.Length - i) * h);
	}

	return maxArea;
}