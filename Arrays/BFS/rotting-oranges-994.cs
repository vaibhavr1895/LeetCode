public int OrangesRotting(int[][] grid) {
    Queue<(int, int)> toBeVisited = new Queue<(int, int)>();
    int goodOranges = 0;
    for(int i = 0; i < grid.Length; i++){
        for(int j = 0; j < grid[0].Length; j++){
            if(grid[i][j] == 2){
                toBeVisited.Enqueue((i, j));
            }
            if(grid[i][j] == 1){
                goodOranges++;
            }
        }
    }

    int timeElapsed = 0;
    while(toBeVisited.Count > 0){
        Queue<(int, int)> toBeVisited2 = new Queue<(int, int)>();
        while(toBeVisited.Count > 0){
            var (i, j) = toBeVisited.Dequeue();
            if(IsValidIndex(i + 1, j, grid)){
                grid[i + 1][j] = 2;
                goodOranges--;
                toBeVisited2.Enqueue((i + 1, j));
            }
            if(IsValidIndex(i - 1, j, grid)){
                grid[i - 1][j] = 2;
                goodOranges--;
                toBeVisited2.Enqueue((i - 1, j));
            }
            if(IsValidIndex(i, j + 1, grid)){
                grid[i][j + 1] = 2;
                goodOranges--;
                toBeVisited2.Enqueue((i, j + 1));
            }
            if(IsValidIndex(i, j - 1, grid)){
                grid[i][j - 1] = 2;
                goodOranges--;
                toBeVisited2.Enqueue((i, j - 1));
            }
        }
        toBeVisited = toBeVisited2;
        if(toBeVisited.Count > 0){
            timeElapsed++;
        }
    }
    return goodOranges == 0 ? timeElapsed : -1;
}

private bool IsValidIndex(int i, int j, int[][] grid){
    if(i == grid.Length || i < 0 || j == grid[0].Length || j < 0 || grid[i][j] == 2 || grid[i][j] == 0){
        return false;
    }
    return true;
}