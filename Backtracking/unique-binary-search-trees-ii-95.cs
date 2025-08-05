public IList<TreeNode> GenerateTrees(int n)
{
    return Generate(1, n);
}

private IList<TreeNode> Generate(int left, int right)
{
    if (left == right)
    {
        return new List<TreeNode>() { new TreeNode(left) };
    }
    if (left > right)
    {
        return new List<TreeNode>() { null };
    }
    List<TreeNode> result = new List<TreeNode>();
    for (int i = left; i <= right; i++)
    {
        foreach (var leftTree in Generate(left, i - 1))
        {
            foreach (var rightTree in Generate(i + 1, right))
            {
                var root = new TreeNode(i, leftTree, rightTree);
                result.Add(root);
            }
        }
    }
    return result;
}