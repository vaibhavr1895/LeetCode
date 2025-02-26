// O(m * n * 4^s) where m is the number of rows, n is the number of columns, and s is the length of the word
// O(m * n) where m is the number of rows and n is the number of columns

public IList<string> FindWords(char[][] board, string[] words) {
    HashSet<(int, int)> visited = new HashSet<(int, int)>();
    var root = new TrieNode();
    foreach(var w in words){
        root.AddWord(w);
    }
    HashSet<string> retVal = new HashSet<string>();
    for(int r = 0; r < board.Length; r++){
        for(int c = 0; c < board[0].Length; c++){
            DFS(r, c, board, root, "", visited, retVal);
        }
    }

    return retVal.ToList();
}

private void DFS(int r, int c, char[][] board, TrieNode node, string curStr, HashSet<(int, int)> path, HashSet<string> retVal){
    if(r < 0 || c < 0 || r == board.Length || c == board[0].Length || !node.children.ContainsKey(board[r][c]) || path.Contains((r,c))){
        return;
    }
    
    path.Add((r, c));
    curStr = curStr + board[r][c];
    node = node.children[board[r][c]];
    if(node.isEndOfWord){ 
        retVal.Add(curStr);
    }
    
    DFS(r + 1, c, board, node, curStr, path, retVal);
    DFS(r, c + 1, board, node, curStr, path, retVal);
    DFS(r - 1, c, board, node, curStr, path, retVal);
    DFS(r, c - 1, board, node, curStr, path, retVal);

    path.Remove((r, c));
}

public class TrieNode{
    public Dictionary<char, TrieNode> children;
    public bool isEndOfWord;

    public TrieNode(){
        children = new Dictionary<char, TrieNode>();
        isEndOfWord = false;
    }

    public void AddWord(string word)
    {
        var cur = this;

        foreach (var c in word)
        {
            if (!cur.children.ContainsKey(c))
            {
                cur.children[c] = new TrieNode();
            }
            cur = cur.children[c];
        }

        cur.isEndOfWord = true;
    }
}