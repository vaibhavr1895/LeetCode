using System.Collections.Generic;

public int[] NextGreaterElement(int[] nums1, int[] nums2)
{
    int[] nextGreaterElement = new int[nums2.Length];
    Dictionary<int, int> map = new Dictionary<int, int>();
    Stack<int> monotonicStack = new Stack<int>();

    for (int i = 0; i < nums1.Length; i++)
    {
        map.Add(nums1[i], i);
    }
    int[] result = new int[nums1.Length];

    for (int i = nums2.Length - 1; i >= 0; i--)
    {
        while (monotonicStack.Count() > 0 && monotonicStack.Peek() < nums2[i])
        {
            monotonicStack.Pop();
        }

        nextGreaterElement[i] = monotonicStack.Count() > 0 ? monotonicStack.Peek() : -1;
        monotonicStack.Push(nums2[i]);
        if (map.ContainsKey(nums2[i]))
        {
            result[map[nums2[i]]] = nextGreaterElement[i];
        }
    }

    return result;
}