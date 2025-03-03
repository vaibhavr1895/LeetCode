// O(n) time complexity
// o(h) space complexity
public int DiameterOfBinaryTree(TreeNode root) {
	var (maxDepth, maxDiameter) = GetDiameter(root);

	return maxDiameter;
}

private (int, int) GetDiameter(TreeNode node){
	if(node == null){
		return (0, 0);
	}

	var (leftDepth, maxLeftDiameter) = GetDiameter(node.left);
	var (rightDepth, maxRightDiameter) = GetDiameter(node.right);

	int curMaxDepth = Math.Max(leftDepth, rightDepth) + 1;
	int curMaxDiameter = Math.Max(leftDepth + rightDepth, Math.Max(maxLeftDiameter, maxRightDiameter));
	return (curMaxDepth, curMaxDiameter);
}