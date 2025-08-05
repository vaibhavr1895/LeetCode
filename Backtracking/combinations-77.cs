using System.Collections.Generic;

public IList<IList<int>> Combine(int n, int k)
{
    List<IList<int>> result = new List<IList<int>>();
    DFS(1, n, k, result, new List<int>());

    return result;
}

private void DFS(int i, int n, int k, List<IList<int>> result, List<int> subset)
{
    if (subset.Count() == k)
    {
        var copy = new List<int>(subset);
        result.Add(copy);
        return;
    }
    if (i > n)
    {
        return;
    }

    subset.Add(i);
    DFS(i + 1, n, k, result, subset);
    subset.RemoveAt(subset.Count() - 1);
    DFS(i + 1, n, k, result, subset);
}