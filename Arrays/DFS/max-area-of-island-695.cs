public int MaxAreaOfIsland(int[][] grid) {
    int rows = grid.Length;
    int cols = grid[0].Length;

    bool[,] visited = new bool[rows,cols];
    int maxArea = 0;
    for(int i =0; i< rows; i++){
        for(int j = 0; j < cols; j++){
            maxArea = Math.Max(maxArea, DFS(grid, i, j, visited));
        }
    }
    return maxArea;
}

public int DFS(int[][] grid, int r, int c, bool[,] visited){
    if(r < 0 || r == grid.Length || c < 0 || c == grid[0].Length || grid[r][c] == 0
    || visited[r,c] == true){
        return 0;
    }

    visited[r,c] = true;
    return (1 + DFS(grid, r + 1, c, visited) + 
                DFS(grid, r - 1, c, visited) +
                DFS(grid, r, c + 1, visited) +
                DFS(grid, r, c - 1, visited));
}