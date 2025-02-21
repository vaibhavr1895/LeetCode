// O(n) time complexity
// O(n) space complexity

public int KthSmallest(TreeNode root, int k) {
	Stack<TreeNode> s = new Stack<TreeNode>();

	GetSorted(root, s);

	int i = 0;
	int result = 0;
	while(i < k){
		var node = s.Pop();
		result = node.val;
		i++;
	}

	return result;
}

private void GetSorted(TreeNode root, Stack<TreeNode> s){
	if(root == null){
		return;
	}

	GetSorted(root.right, s);
	s.Push(root);
	GetSorted(root.left, s);
}