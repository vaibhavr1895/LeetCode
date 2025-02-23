// Encodes a tree to a single string.
public string serialize(TreeNode root) {
    List<string> sb = new List<string>();
    DFS(root, sb);
    return string.Join(",", sb.ToArray());
}

private void DFS(TreeNode root, List<string> sb){
    if(root == null){
        sb.Add("N");
        return;
    }

    sb.Add(root.val.ToString());
    DFS(root.left, sb);
    DFS(root.right, sb);
}
private int index = 0;
// Decodes your encoded data to tree.
public TreeNode deserialize(string data) {
    index = 0;
    var strArray = data.Split(",");
    return DFS(strArray);
}

public TreeNode DFS(string[] data){
    if(index > data.Length - 1){
        return null;
    }

    if(data[index] == "N"){
        index++;
        return null;
    }

    var node = new TreeNode(int.Parse(data[index]));
    index++;
    node.left = DFS(data);
    node.right = DFS(data);
    return node;
}