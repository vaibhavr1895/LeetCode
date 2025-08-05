using System;

public int MaxProduct(string[] words)
{
    int[] state = new int[words.Length];
    int maxResult = 0;
    for (int i = 0; i < words.Length; i++)
    {
        foreach (var w in words[i])
        {
            state[i] = state[i] | (1 << w - 'a');
        }

        for (int j = 0; j < i; j++)
        {
            if ((state[i] & state[j]) == 0)
            {
                maxResult = Math.Max(maxResult, words[i].Length * words[j].Length);
            }
        }
    }

    return maxResult;

}