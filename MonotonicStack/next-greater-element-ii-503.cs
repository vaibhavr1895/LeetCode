using System.Collections.Generic;

public int[] NextGreaterElements(int[] nums)
{
    int n = nums.Length;

    int[] result = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        result[i] = -1;
    }
    Stack<int> s = new Stack<int>();

    for (int i = 0; i < nums.Length; i++)
    {
        int j = i + 1;
        s.Push(i);
        while (s.Count() > 0 && j < i + n)
        {
            if (nums[j % n] > nums[s.Peek()])
            {
                int index = s.Pop();
                result[index] = nums[j % n];
                break;
            }
            j++;
        }
    }
    return result;
}