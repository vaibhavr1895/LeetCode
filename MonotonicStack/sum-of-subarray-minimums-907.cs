using System.Collections.Generic;

public int SumSubarrayMins(int[] arr)
{
    var previousSmallerIndices = GetPreviousSmallerElementIndices(arr);
    var nextSmallerIndices = GetNextSmallerElementIndices(arr);
    long total = 0;
    long mod = 1000000007L;
    for (int i = 0; i < arr.Length; i++)
    {
        long left = i - previousSmallerIndices[i];
        long right = nextSmallerIndices[i] - i;

        total = (total + ((left * right * arr[i]) % mod)) % mod;
    }

    return (int)(total % mod);
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