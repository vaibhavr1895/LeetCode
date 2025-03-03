// O(n) time complexity
// O(logh) space complexity
private int MaxValue;
public int MaxPathSum(TreeNode root) {
	MaxValue = root.val;
	DFS(root);
	return MaxValue;
}

private int DFS(TreeNode root){
	if(root == null){
		return 0;
	}

	int leftMax = Math.Max(DFS(root.left), 0);
	int rightMax = Math.Max(DFS(root.right), 0);

	MaxValue = Math.Max(MaxValue, leftMax + rightMax + root.val);

	return root.val + Math.Max(leftMax, rightMax);
}