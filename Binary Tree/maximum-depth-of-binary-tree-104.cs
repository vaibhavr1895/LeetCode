// O(n)	time complexity
// O(n)	space complexity
public int MaxDepth(TreeNode root) {
	if(root == null){
		return 0;
	}

	int left = MaxDepth(root.left);
	int right = MaxDepth(root.right);
	int max = Math.Max(left , right);
	return max + 1;
}