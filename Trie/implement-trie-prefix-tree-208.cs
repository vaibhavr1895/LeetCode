public class Trie {
    public TrieNode root;
    public Trie() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        var cur = root;

        foreach(var c in word){
            if(!cur.children.ContainsKey(c)){
                cur.children[c] = new TrieNode();
            }
            cur = cur.children[c];
        }

        cur.isEndOfWord = true;
    }
    
    public bool Search(string word) {
        var cur = root;

        foreach(var c in word){
            if(!cur.children.ContainsKey(c)){
                return false;
            }
            cur = cur.children[c];
        }

        return cur.isEndOfWord;
    }
    
    public bool StartsWith(string prefix) {
        var cur = root;

        foreach(var c in prefix){
            if(!cur.children.ContainsKey(c)){
                return false;
            }
            cur = cur.children[c];
        }

        return true;
    }
}

public class TrieNode{
    public Dictionary<char, TrieNode> children;
    public bool isEndOfWord;

    public TrieNode(){
        children = new Dictionary<char, TrieNode>();
        isEndOfWord = false;
    }
}