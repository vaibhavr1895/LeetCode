using System.Collections.Generic;

public IList<IList<string>> SolveNQueens(int n)
{
    List<IList<string>> result = new List<IList<string>>();
    HashSet<int> col = new HashSet<int>();
    HashSet<int> positiveDiagonal = new HashSet<int>();
    HashSet<int> negativeDiagonal = new HashSet<int>();

    char[,] board = new char[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            board[i, j] = '.';
        }
    }
    void BackTrack4(int r)
    {
        if (r == n)
        {
            var list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string row = "";
                for (int j = 0; j < n; j++)
                {
                    row += board[i, j];
                }
                list.Add(row);
            }
            result.Add(list);
            return;
        }

        for (int c = 0; c < n; c++)
        {
            if (col.Contains(c) || positiveDiagonal.Contains(r + c) || negativeDiagonal.Contains(r - c))
            {
                continue;
            }

            col.Add(c);
            positiveDiagonal.Add(r + c);
            negativeDiagonal.Add(r - c);
            board[r, c] = 'Q';
            BackTrack4(r + 1);

            board[r, c] = '.';
            col.Remove(c);
            positiveDiagonal.Remove(r + c);
            negativeDiagonal.Remove(r - c);
        }
    }
    BackTrack4(0);
    return result;
}