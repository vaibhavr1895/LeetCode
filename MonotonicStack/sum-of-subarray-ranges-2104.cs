using System.Collections.Generic;

public long SubArrayRanges(int[] nums)
{

    var previousSmallerIndices = GetPreviousSmallerElementIndices(nums);
    var nextSmallerIndices = GetNextSmallerElementIndices(nums);

    var previousGreaterIndices = GetPreviousGreaterElementIndices(nums);
    var nextGreaterIndices = GetNextGreaterElementIndices(nums);
    long minTotal = 0;
    long maxTotal = 0;
    long mod = 1000000007L;
    for (int i = 0; i < nums.Length; i++)
    {
        long leftMin = i - previousSmallerIndices[i];
        long rightMin = nextSmallerIndices[i] - i;

        long leftMax = i - previousGreaterIndices[i];
        long rightMax = nextGreaterIndices[i] - i;

        minTotal = (minTotal + ((leftMin * rightMin * nums[i])));
        maxTotal = (maxTotal + ((leftMax * rightMax * nums[i])));
    }
    return maxTotal - minTotal;
}

private int[] GetPreviousSmallerElementIndices(int[] arr)
{
    int[] previousSmallerIndices = new int[arr.Length];
    Stack<int> smallerElementStack = new Stack<int>();
    for (int i = 0; i < arr.Length; i++)
    {
        while (smallerElementStack.Count() > 0 && arr[smallerElementStack.Peek()] >= arr[i])
        {
            smallerElementStack.Pop();
        }
        previousSmallerIndices[i] = smallerElementStack.Count() > 0 ? smallerElementStack.Peek() : -1;
        smallerElementStack.Push(i);
    }

    return previousSmallerIndices;
}

private int[] GetNextSmallerElementIndices(int[] arr)
{
    int[] nextSmallerIndices = new int[arr.Length];
    Stack<int> smallerElementStack = new Stack<int>();
    for (int i = arr.Length - 1; i >= 0; i--)
    {
        while (smallerElementStack.Count > 0 && arr[smallerElementStack.Peek()] > arr[i])
        {
            smallerElementStack.Pop();
        }

        nextSmallerIndices[i] = smallerElementStack.Count() > 0 ? smallerElementStack.Peek() : arr.Length;
        smallerElementStack.Push(i);
    }

    return nextSmallerIndices;
}

private int[] GetPreviousGreaterElementIndices(int[] arr)
{
    int[] previousLargerIndices = new int[arr.Length];
    Stack<int> largerElementStack = new Stack<int>();
    for (int i = 0; i < arr.Length; i++)
    {
        while (largerElementStack.Count() > 0 && arr[largerElementStack.Peek()] <= arr[i])
        {
            largerElementStack.Pop();
        }
        previousLargerIndices[i] = largerElementStack.Count() > 0 ? largerElementStack.Peek() : -1;
        largerElementStack.Push(i);
    }

    return previousLargerIndices;
}

private int[] GetNextGreaterElementIndices(int[] arr)
{
    int[] nextGreaterIndices = new int[arr.Length];
    Stack<int> largerElementStack = new Stack<int>();
    for (int i = arr.Length - 1; i >= 0; i--)
    {
        while (largerElementStack.Count > 0 && arr[largerElementStack.Peek()] < arr[i])
        {
            largerElementStack.Pop();
        }

        nextGreaterIndices[i] = largerElementStack.Count() > 0 ? largerElementStack.Peek() : arr.Length;
        largerElementStack.Push(i);
    }

    return nextGreaterIndices;
}