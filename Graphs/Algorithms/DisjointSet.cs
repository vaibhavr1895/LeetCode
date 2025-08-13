public class DisjointSet
{
    private int[] Parent;
    private int[] Rank;
    private int[] Size;
    public DisjointSet(int n)
    {
        Parent = new int[n + 1];
        Rank = new int[n + 1];
        Size = new int[n + 1];

        for (int i = 0; i <= n; i++)
        {
            Parent[i] = i;
            Size[i] = 1;
        }
    }

    public int FindPar(int u)
    {
        if (u == Parent[u])
        {
            return u;
        }

        Parent[u] = FindPar(Parent[u]);
        return Parent[u];
    }

    public void UnionByRank(int u, int v)
    {
        var ult_u = FindPar(u);
        var ult_v = FindPar(v);

        if (ult_u == ult_v)
        {
            return;
        }

        if (Rank[ult_u] > Rank[ult_v])
        {
            Parent[ult_v] = ult_u;
        }
        else if (Rank[ult_v] > Rank[ult_u])
        {
            Parent[ult_u] = ult_v;
        }
        else
        {
            Parent[u] = v;
            Rank[v]++;
        }
    }

    public void UnionBySize(int u, int v)
    {
        var ult_u = FindPar(u);
        var ult_v = FindPar(v);

        if (ult_u == ult_v)
        {
            return;
        }
        if (Size[ult_u] > Size[ult_v])
        {
            Parent[ult_v] = ult_u;
            Size[ult_u] += Size[ult_v];
        }
        else if (Size[ult_v] > Size[ult_u])
        {
            Parent[ult_u] = ult_v;
            Size[ult_v] += Size[ult_u];
        }
        else
        {
            Parent[u] = v;
            Rank[v]++;
            Size[v] += Size[u];
        }
    }
}