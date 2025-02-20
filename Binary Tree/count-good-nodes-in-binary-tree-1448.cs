// O(n) time complexity
// O(n) space complexity

int goodNodes = 0;
public int GoodNodes(TreeNode root) {
	goodNodes++;
	int curGreatest = root.val;
	Traverse(root.left, curGreatest);
	Traverse(root.right, curGreatest);

	return goodNodes;
}

private void Traverse(TreeNode node, int curGreatest){
	if(node == null){
		return;
	}

	if(node.val >= curGreatest){
		curGreatest = node.val;
		goodNodes++;
	}

	Traverse(node.left, curGreatest);
	Traverse(node.right, curGreatest);
}