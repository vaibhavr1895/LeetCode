using System.Collections.Generic;

public IList<int> EventualSafeNodes(int[][] graph)
{


    Dictionary<int, bool> safeNodes = new Dictionary<int, bool>();

    bool DFS(int i)
    {
        if (safeNodes.ContainsKey(i))
        {
            return safeNodes[i];
        }
        safeNodes.Add(i, false);

        foreach (var neighbor in graph[i])
        {
            if (!DFS(neighbor))
            {
                return safeNodes[i];
            }
        }
        safeNodes[i] = true;
        return safeNodes[i];
    }
    List<int> result = new List<int>();
    for (int i = 0; i < graph.Length; i++)
    {
        if (DFS(i))
        {
            result.Add(i);
        }
    }
    return result;
}