public class NumArray
{
	private int[] segmentTreeArray;
	private int[] myNums;
	public NumArray(int[] nums)
	{
		int count = nums.Length;
		myNums = nums;
		segmentTreeArray = new int[4 * count];
		BuildTree(0, 0, count - 1);
	}

	private int BuildTree(int i, int left, int right)
	{
		if (left == right)
		{
			segmentTreeArray[i] = myNums[left];
			return segmentTreeArray[i];
		}
		int mid = (left + right) / 2;
		segmentTreeArray[i] = BuildTree(2 * i + 1, left, mid) + BuildTree(2 * i + 2, mid + 1, right);
		return segmentTreeArray[i];
	}

	public void Update(int index, int val)
	{
		Update(index, val, 0, 0, myNums.Length - 1);
	}

	private void Update(int index, int val, int i, int left, int right)
	{
		if (left == right)
		{
			segmentTreeArray[i] = val;
			return;
		}
		int mid = (left + right) / 2;
		if (index > mid)
		{
			Update(index, val, 2 * i + 2, mid + 1, right);
		}
		else
		{
			Update(index, val, 2 * i + 1, left, mid);
		}

		segmentTreeArray[i] = segmentTreeArray[2 * i + 1] + segmentTreeArray[2 * i + 2];
	}

	public int SumRange(int left, int right)
	{
		return SumRange(left, right, 0, myNums.Length - 1, 0);
	}

	public int SumRange(int left, int right, int leftRange, int rightRange, int index)
	{
		if (leftRange >= left && rightRange <= right)
		{
			return segmentTreeArray[index];
		}

		if (left > rightRange || right < leftRange)
		{
			return 0;
		}

		int sum = 0;
		int mid = (leftRange + rightRange) / 2;


		sum = SumRange(left, right, mid + 1, rightRange, 2 * index + 2) + SumRange(left, right, leftRange, mid, 2 * index + 1);
		return sum;
	}
}
