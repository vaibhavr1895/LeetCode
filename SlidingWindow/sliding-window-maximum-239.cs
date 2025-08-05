// O(n) time complexity
// O(n) space complexity
public int[] MaxSlidingWindow(int[] nums, int k) {
	List<int> result = new List<int>();
	List<int> q = new List<int>();

	int r = 0;
	int l = 0;

	while (r < nums.Length)
	{
		while (q.Count() > 0 && nums[q.Last()] < nums[r])
		{
			q.RemoveAt(q.Count() - 1);
		}
		q.Add(r);

		if (l > q.First())
		{
			q.RemoveAt(0);
		}

		if (r + 1 >= k)
		{
			result.Add(nums[q.First()]);
			l++;
		}
		r++;
	}
	return result.ToArray();
}