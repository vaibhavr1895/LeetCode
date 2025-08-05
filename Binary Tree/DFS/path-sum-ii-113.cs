using System.Collections.Generic;

public IList<IList<int>> PathSum(TreeNode root, int targetSum)
{
    var result = new List<IList<int>>();
    if (root == null)
    {
        return result;
    }
    DFS(root, root.val, targetSum, result, new List<int>() { root.val });
    return result;
}

private void DFS(TreeNode node, int curSum, int targetSum, List<IList<int>> result, List<int> curPath)
{
    if (node.left == null && node.right == null && curSum == targetSum)
    {
        var copy = new List<int>(curPath);
        result.Add(copy);
        return;
    }
    if (node.left != null)
    {
        curPath.Add(node.left.val);
        DFS(node.left, curSum + node.left.val, targetSum, result, curPath);
        curPath.RemoveAt(curPath.Count() - 1);
    }
    if (node.right != null)
    {
        curPath.Add(node.right.val);
        DFS(node.right, curSum + node.right.val, targetSum, result, curPath);
        curPath.RemoveAt(curPath.Count() - 1);
    }
}