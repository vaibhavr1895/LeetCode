using System.Collections.Generic;

public IList<string> FindItinerary(IList<IList<string>> tickets)
{
    Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>();

    foreach (var ticket in tickets)
    {
        if (adj.ContainsKey(ticket[0]))
        {
            adj[ticket[0]].Add(ticket[1]);
        }
        else
        {
            adj.Add(ticket[0], new List<string>() { ticket[1] });
        }
    }
    foreach (var destinations in adj.Values)
    {
        destinations.Sort((a, b) => a.CompareTo(b));
    }
    List<string> result = new List<string>();

    DFS("JFK", result, adj);
    result.Reverse();
    return result;
}

private void DFS(string src, List<string> result, Dictionary<string, List<string>> adj)
{
    while (adj.ContainsKey(src) && adj[src].Count > 0)
    {
        var nextDestination = adj[src][0];
        adj[src].RemoveAt(0);
        DFS(nextDestination, result, adj);
    }

    result.Add(src);
}