public int ArrayPairSum(int[] nums)
{
    int[] bucket = new int[20001];

    foreach (var n in nums)
    {
        bucket[n + 10000] += 1;
    }

    int result = 0;
    bool flag = true;
    for (int i = 0; i < 20001; i++)
    {
        while (bucket[i] > 0)
        {
            if (flag)
            {
                result += i - 10000;
            }
            flag = !flag;
            bucket[i] -= 1;
        }
    }

    return result;
}