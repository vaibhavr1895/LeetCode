public int UniquePaths(int m, int n)
{
    int maxPaths = 0;
    int[,] cache = new int[m, n];
    int DFS(int r, int c)
    {
        if (r >= m || c >= n)
        {
            return 0;
        }
        if (r == m - 1 && c == n - 1)
        {
            return 1;
        }
        if (cache[r, c] > 0)
        {
            return cache[r, c];
        }

        int down = DFS(r + 1, c);
        int right = DFS(r, c + 1);

        cache[r, c] = down + right;
        return cache[r, c];
    }

    return DFS(0, 0);
}