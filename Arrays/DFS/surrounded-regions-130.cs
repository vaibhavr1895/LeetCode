public void Solve(char[][] board) 
{
    int rows = board.Length;
    int cols = board[0].Length;

    for(int i =0; i< rows; i++){
        for(int j =0; j< cols; j++){
            if(board[i][j] == 'O' && ((i == 0 || i == rows - 1) || (j == 0 || j == cols -1))){
                Capture(board, i, j);
            }
        }
    }

    for(int i =0; i< rows; i++){
        for(int j =0; j< cols; j++){
            if(board[i][j] == 'O'){
                board[i][j] = 'X';
            }
        }
    }

    for(int i =0; i< rows; i++){
        for(int j =0; j< cols; j++){
            if(board[i][j] == 'T'){
                board[i][j] = 'O';
            }
        }
    }
}

private void Capture(char[][] board, int r, int c)
{
    int rows = board.Length;
    int cols = board[0].Length;

    if(r < 0 || c < 0 || r == rows || c == cols || board[r][c] != 'O'){
        return;
    }
    
    board[r][c] = 'T';
    Capture(board, r + 1, c);
    Capture(board ,r - 1, c);
    Capture(board, r, c + 1);
    Capture(board, r, c - 1);
}