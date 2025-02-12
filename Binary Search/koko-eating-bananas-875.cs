// O(log(n) * p) time complexity
// O(1) space complexity

public int MinEatingSpeed(int[] piles, int h) {
	Array.Sort(piles);
	int left = 1;
	int right = piles[piles.Length - 1];

	int eatingSpeed = right;

	while (left <= right)
	{
		int curEatingSpeed = (left + right) / 2;
		long hours = 0;
		foreach(var p in piles)
		{
			hours += (int) Math.Ceiling(p / (decimal) curEatingSpeed);
		}

		if(hours <= h)
		{
			eatingSpeed = Math.Min(curEatingSpeed, eatingSpeed);
			right = curEatingSpeed - 1;
		}
		else
		{
			left = curEatingSpeed + 1;
		}
	}

	return eatingSpeed;
}