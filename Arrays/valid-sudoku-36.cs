public bool IsValidSudoku(char[][] board) {
        int n = 9;
        HashSet<char>[] colArray = new HashSet<char>[n];
        HashSet<char>[] rowArray = new HashSet<char>[n];
        HashSet<char>[] boxArray = new HashSet<char>[n];

        for(int i =0; i< n; i++)
        {
            colArray[i] = new HashSet<char>();
            rowArray[i] = new HashSet<char>();
            boxArray[i] = new HashSet<char>();
        }

        for(int r =0; r < n; r++)
        {
            for(int c = 0; c < n; c++)
            {
                var value = board[r][c];

                if (value == '.')
                {
                    continue;
                }

                if (colArray[c].Contains(value))
                {
                    return false;
                }
                colArray[c].Add(value);

                if (rowArray[r].Contains(value))
                {
                    return false;
                }
                rowArray[r].Add(value);

                var index = (r / 3) * 3 + (c / 3);
                if (boxArray[index].Contains(value))
                {
                    return false;
                }
                boxArray[index].Add(value);
            }
        }
        return true;
    }