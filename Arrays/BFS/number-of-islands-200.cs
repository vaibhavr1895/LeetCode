public int NumIslands(char[][] grid) {
    int rows = grid.Length;
    int cols = grid[0].Length;

    bool[,] visited = new bool[rows,cols];
    int islands = 0;

    for(int i = 0; i< rows; i++){
        for(int j =0; j < cols; j++){
            if(grid[i][j] == '1' && !visited[i,j]){
                Bfs(i, j, visited, grid);
                islands++;
            }
        }
    }

    return islands;
}

private void Bfs(int r, int c, bool[,] visited, char[][] grid){
    Queue<(int, int)> queue = new Queue<(int, int)>();
    visited[r, c] = true;
    queue.Enqueue((r, c));
    int rows = grid.Length;
    int cols = grid[0].Length;
    while(queue.Count > 0){
        var (row, col) = queue.Dequeue();
        var directions = new List<(int,int)>() { (1, 0), (-1, 0), (0, 1), (0, -1)};
        foreach(var (dr, dc) in directions){
            r = row + dr;
            c = col + dc;
            if(r >= 0 && c >= 0 && r < rows && c < cols && grid[r][c] == '1' && !visited[r,c]){
                queue.Enqueue((r, c));
                visited[r,c] = true;
            }
        }
    }
}