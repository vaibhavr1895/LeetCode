// O(n) time complexity
// O(h) space complexity
public bool IsBalanced(TreeNode root) {
	var (depth, isBalanced) = DFS(root);
	return isBalanced;
}

public (int, bool) DFS(TreeNode root){
	if(root == null){
		return (0,true);
	}

	var (leftDepth, leftIsBalanced) = DFS(root.left);
	if(!leftIsBalanced){
		return (leftDepth, false);
	}
	var (rightDepth, rightIsBalanced) = DFS(root.right);
	if(!rightIsBalanced){
		return (rightDepth, false);
	}

	bool isBalanced = Math.Abs(leftDepth - rightDepth) <= 1;

	return (Math.Max(leftDepth, rightDepth) +1, isBalanced);
}