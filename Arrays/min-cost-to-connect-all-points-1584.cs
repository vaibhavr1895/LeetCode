using System.Collections.Generic;
using System;

public int MinCostConnectPoints(int[][] points)
{
    int n = points.Length;
    List<Edge> edges = new List<Edge>();

    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            int cost = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
            edges.Add(new Edge(i, j, cost));
        }
    }

    edges.Sort((a, b) => a.Cost.CompareTo(b.Cost));

    int[] parent = new int[n];
    for (int i = 0; i < n; i++)
    {
        parent[i] = i;
    }

    int minCost = 0;
    int edgeCount = 0;

    foreach (Edge edge in edges)
    {
        int root1 = Find(parent, edge.From);
        int root2 = Find(parent, edge.To);

        if (root1 != root2)
        {
            parent[root1] = root2;
            minCost += edge.Cost;
            edgeCount++;

            if (edgeCount == n - 1)
            {
                break;
            }
        }
    }

    return minCost;
}

private int Find(int[] parent, int node)
{
    if (parent[node] != node)
    {
        parent[node] = Find(parent, parent[node]);
    }
    return parent[node];
}
}

public class Edge
{
    public int From { get; }
    public int To { get; }
    public int Cost { get; }

    public Edge(int from, int to, int cost)
    {
        From = from;
        To = to;
        Cost = cost;
    }