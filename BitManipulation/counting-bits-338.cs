public int[] CountBits(int n)
{
    int[] result = new int[n + 1];
    int highestDegreeOfTwo = 1;

    for (int i = 1; i < result.Length; i++)
    {
        if (i == (highestDegreeOfTwo * 2))
        {
            highestDegreeOfTwo *= 2;
        }
        result[i] = 1 + result[i - highestDegreeOfTwo];
    }

    return result;
}