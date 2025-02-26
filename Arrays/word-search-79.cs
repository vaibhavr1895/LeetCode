// O(m * n * 4^s) where m is the number of rows, n is the number of columns, and s is the length of the word
// O(s) where s is the length of the word
public bool Exist(char[][] board, string word) {
    HashSet<(int, int)> visited = new HashSet<(int, int)>();
    for (int r = 0; r < board.Length; r++) { 
        for(int c = 0;  c < board[0].Length; c++)
        {
            if(DFS(r, c, board, word, 0, visited))
            {
                return true;
            }
        }
    }
    return false;
}

private bool DFS(int r, int c, char[][] board, string word, int i, HashSet<(int, int)> path)
{
    if(i == word.Length){
        return true;
    }
    
    if(r < 0 || c < 0 || r >= board.Length || c >= board[r].Length || word[i] != board[r][c] || path.Contains((r, c))){
        return false;
    }
    path.Add((r, c));   
    var result = DFS(r + 1, c, board, word, i + 1, path) ||
                DFS(r, c + 1, board, word, i + 1, path) ||
                DFS(r - 1, c, board, word, i + 1, path) ||
                DFS(r, c - 1, board, word, i + 1, path);
    path.Remove((r, c));

    return result;
}