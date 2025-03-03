// O(n) time complexity
// O(n) space complexity

int depthReached = 0;
public IList<int> RightSideView(TreeNode root) {
	List<int> res = new List<int>();
	if(root == null){
		return res;
	}

	res.Add(root.val);
	int curDepth = 0;
	TraverseTree(root.right, curDepth + 1, res);
	TraverseTree(root.left, curDepth + 1, res);

	return res;
}

private void TraverseTree(TreeNode n, int curDepth, List<int> res){
	if(n == null){
		return;
	}

	if(curDepth > depthReached){
		res.Add(n.val);
		depthReached++;
	}

	TraverseTree(n.right, curDepth + 1, res);
	TraverseTree(n.left, curDepth + 1, res);
}