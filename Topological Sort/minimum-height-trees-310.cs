public IList<int> FindMinHeightTrees(int n, int[][] edges)
{
    if (n == 1)
    {
        return new List<int>() { 0 };
    }
    Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
    for (int i = 0; i < edges.Length; i++)
    {
        if (!adj.ContainsKey(edges[i][0]))
        {
            var set = new List<int>();
            set.Add(edges[i][1]);
            adj.Add(edges[i][0], set);
        }
        else
        {
            adj[edges[i][0]].Add(edges[i][1]);
        }

        if (!adj.ContainsKey(edges[i][1]))
        {
            var set = new List<int>();
            set.Add(edges[i][0]);
            adj.Add(edges[i][1], set);
        }
        else
        {
            adj[edges[i][1]].Add(edges[i][0]);
        }
    }

    Dictionary<int, int> edgeCount = new Dictionary<int, int>();
    Queue<int> leaves = new Queue<int>();

    foreach (var a in adj)
    {
        if (a.Value.Count() == 1)
        {
            leaves.Enqueue(a.Key);
        }
        edgeCount.Add(a.Key, a.Value.Count());
    }

    while (leaves.Count() > 0)
    {
        if (n <= 2)
        {
            var result = new List<int>();
            while (leaves.Count() > 0)
            {
                result.Add(leaves.Dequeue());
            }
            return result;
        }
        int count = leaves.Count();
        for (int i = 0; i < count; i++)
        {
            var leaf = leaves.Dequeue();
            n--;
            foreach (var neighbor in adj[leaf])
            {
                edgeCount[neighbor]--;
                if (edgeCount[neighbor] == 1)
                {
                    leaves.Enqueue(neighbor);
                }
            }
        }
    }

    return new List<int>();
}