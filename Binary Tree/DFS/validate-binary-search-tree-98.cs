// O(n) time complexity
// O(n) space complexity
public bool IsValidBST(TreeNode root) {
	return IsValidBST(root, long.MinValue, long.MaxValue);
}

private bool IsValidBST(TreeNode node, long min, long max){
	if(node == null){
		return true;
	}

	if(!(node.val > min && node.val < max)){
		return false;
	}

	return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
}