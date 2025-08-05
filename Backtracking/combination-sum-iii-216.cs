using System.Collections.Generic;

public IList<IList<int>> CombinationSum3(int k, int n)
{
    List<IList<int>> result = new List<IList<int>>();
    List<int> curCombination = new List<int>();

    for (int i = 1; i < 10; i++)
    {
        curCombination.Add(i);
        DFS(i, n, result, curCombination, 1, i, k);
        curCombination.RemoveAt(curCombination.Count() - 1);
    }
    return result;
}

private void DFS(int index, int targetSum, List<IList<int>> result, List<int> curCombination, int curCount, int curSum, int k)
{

    if (k == curCount && targetSum == curSum)
    {
        var copy = new List<int>(curCombination);
        result.Add(copy);
        return;
    }

    if (curSum > targetSum)
    {
        return;
    }

    for (int i = index + 1; i < 10; i++)
    {
        curCombination.Add(i);
        DFS(i, targetSum, result, curCombination, curCount + 1, curSum + i, k);
        curCombination.RemoveAt(curCombination.Count() - 1);
    }
}