public IList<IList<int>> PacificAtlantic(int[][] heights) {
    if(heights.Length == 0 || heights[0].Length == 0){
        return new List<IList<int>>();
    }
    int rows = heights.Length;
    int cols = heights[0].Length; 

    bool[,] pacific = new bool[rows, cols];
    bool[,] atlantic = new bool[rows, cols];

    for(int i = 0; i < cols; i++){
        DFS(heights, 0, i, pacific, heights[0][i]);
        DFS(heights, rows - 1, i, atlantic, heights[rows - 1][i]);
    } 

    for(int i = 0; i < rows; i++){
        DFS(heights, i, 0, pacific, heights[i][0]);
        DFS(heights, i, cols - 1, atlantic, heights[i][cols - 1]);
    }   

    List<IList<int>> res = new List<IList<int>>();

    for(int r = 0; r < rows; r++){
        for(int c = 0; c < cols; c++){
            if(pacific[r,c] && atlantic[r,c]){
                res.Add(new List<int>(){r , c});
            }
        }
    }
    return res;
}

private void DFS(int[][] heights, int r, int c, bool[,] visited, int prevHeight){
    if(r < 0 || r == heights.Length || c < 0 || c == heights[0].Length
        || visited[r,c] || heights[r][c] < prevHeight){
            return;
        }

    visited[r,c] = true;

    DFS(heights, r - 1, c, visited, heights[r][c]);
    DFS(heights, r + 1, c, visited, heights[r][c]);
    DFS(heights, r, c - 1, visited, heights[r][c]);
    DFS(heights, r, c + 1, visited, heights[r][c]);
}