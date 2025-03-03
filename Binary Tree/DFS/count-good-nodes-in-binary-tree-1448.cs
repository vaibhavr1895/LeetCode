// O(n) time complexity
// O(n) space complexity
public int GoodNodes(TreeNode root) {
	int curGreatest = root.val;
	int leftGoodNodes = Traverse(root.left, curGreatest);
	int rightGoodNodes = Traverse(root.right, curGreatest);

	return leftGoodNodes + rightGoodNodes + 1;
}

private int Traverse(TreeNode node, int curGreatest){
	if(node == null){
		return 0;
	}
	int res = 0;
	if(node.val >= curGreatest){
		curGreatest = node.val;
		res++;
	}

	res += Traverse(node.left, curGreatest);
	res += Traverse(node.right, curGreatest);
	return res;
}