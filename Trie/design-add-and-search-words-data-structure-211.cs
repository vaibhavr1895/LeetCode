public class WordDictionary {
    public TrieNode root;
    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
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
        return search(cur, word);
    }

    private bool search(TrieNode node, string word){
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == '.')
            {
                var allChildren = node.children;
                foreach (var child in allChildren)
                {
                    if (search(child.Value, word.Substring(i + 1)))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                if (!node.children.ContainsKey(word[i]))
                {
                    return false;
                }
                node = node.children[word[i]];
            }
        }
        return node.isEndOfWord;
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