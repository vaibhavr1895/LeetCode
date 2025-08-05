public int[] FindRedundantConnection(int[][] edges)
{
    int numberOfNodes = edges.Length;
    var parents = new int[numberOfNodes + 1];
    var rank = new int[numberOfNodes + 1];

    for (int i = 1; i <= numberOfNodes; i++)
    {
        rank[i] = numberOfNodes;
        parents[i] = i;
    }
    foreach (var edge in edges)
    {
        if (!Union(edge[0], edge[1], parents, rank))
        {
            return new int[] { edge[0], edge[1] };
        }
    }
    return new int[] { };
}

private int Find(int n, int[] parents)
{
    if (n != parents[n])
    {
        parents[n] = Find(parents[n], parents);
    }
    return parents[n];
}

private bool Union(int node1, int node2, int[] parents, int[] rank)
{
    var n1 = Find(node1, parents);
    var n2 = Find(node2, parents);

    if (n1 == n2)
    {
        return false;
    }

    if (rank[n1] > rank[n2])
    {
        parents[n2] = n1;
        rank[n1] += rank[n2];
    }
    else
    {
        parents[n1] = n2;
        rank[n2] += rank[n1];
    }
    return true;
}