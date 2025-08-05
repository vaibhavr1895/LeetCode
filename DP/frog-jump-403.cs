public bool CanCross(int[] stones)
{
    Dictionary<int, int> stoneIndices = new Dictionary<int, int>();
    for (int i = 0; i < stones.Length; i++)
    {
        stoneIndices.Add(stones[i], i);
    }

    int[,] memo = new int[2001, 2001];
    for (int i = 0; i < 2001; i++)
    {
        for (int j = 0; j < 2001; j++)
        {
            memo[i, j] = -1;
        }
    }
    bool CanJump(int currentStoneIndex, int jump)
    {
        if (jump <= 0)
        {
            return false;
        }
        if (currentStoneIndex == stones.Length - 1)
        {
            return true;
        }
        if (memo[currentStoneIndex, jump] != -1)
        {
            return memo[currentStoneIndex, jump] == 1;
        }

        if (!stoneIndices.ContainsKey(stones[currentStoneIndex] + jump))
        {
            return false;
        }

        int nextStoneIndex = stoneIndices[stones[currentStoneIndex] + jump];
        if (CanJump(nextStoneIndex, jump - 1)
            || CanJump(nextStoneIndex, jump)
            || CanJump(nextStoneIndex, jump + 1))
        {
            memo[currentStoneIndex, jump] = 1;
        }
        else
        {
            memo[currentStoneIndex, jump] = 0;
        }
        return memo[currentStoneIndex, jump] == 1;
    }
    return CanJump(0, 1);
}