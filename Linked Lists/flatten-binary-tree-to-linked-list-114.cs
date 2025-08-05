public void Flatten(TreeNode root)
{
    void DFS(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        DFS(node.left);
        DFS(node.right);
        var temp = node.right;
        node.right = node.left;
        node.left = temp;
        var curNode = node;
        while (curNode.right != null)
        {
            curNode = curNode.right;
        }
        curNode.right = node.left;
        node.left = null;
    }

    DFS(root);
}