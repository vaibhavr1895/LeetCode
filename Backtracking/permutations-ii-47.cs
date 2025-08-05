using System.Collections.Generic;

public IList<IList<int>> PermuteUnique(int[] nums)
{
    List<IList<int>> result = new List<IList<int>>();
    DFS(nums, new List<int>(), new List<int>(), result, new HashSet<string>());
    return result;
}

private void DFS(int[] nums, List<int> subset, List<int> indices, List<IList<int>> result, HashSet<string> visited)
{
    if (subset.Count() == nums.Length && !visited.Contains(string.Join("", subset.ToArray())))
    {
        var copy = new List<int>(subset);
        visited.Add(string.Join("", copy.ToArray()));
        result.Add(copy);
        return;
    }

    for (int i = 0; i < nums.Length; i++)
    {
        if (!indices.Contains(i))
        {
            subset.Add(nums[i]);
            indices.Add(i);
            DFS(nums, subset, indices, result, visited);
            subset.RemoveAt(subset.Count() - 1);
            indices.RemoveAt(indices.Count() - 1);
        }
    }
}