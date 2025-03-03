// Difficulty: Easy
// O(n * m) time complexity
// O(n) space complexity
public bool IsSubtree(TreeNode root, TreeNode subRoot) {
	if(subRoot == null){
		return true;
	}

	if(root == null){
		return false;
	}

	if(IsSameTree(root, subRoot)){
		return true;
	}

	return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
}

// O(s * t) time complexity
// O(s) space complexity
public bool IsSubtree(TreeNode root, TreeNode subRoot) {
	Queue<TreeNode> q = new Queue<TreeNode>();
	
	q.Enqueue(root);

	while(q.Count() > 0){
		var node = q.Dequeue();
		if(node.val == subRoot.val){
			var isSame = IsSameTree(node, subRoot);
			if(isSame){
				return true;
			}
		}

		if(node.left != null){
			q.Enqueue(node.left);
		}
		if(node.right != null){
			q.Enqueue(node.right);
		}
	}        

	return false;
}

private bool IsSameTree(TreeNode p, TreeNode q){
	if(p == null && q == null){
		return true;
	}

	if(p== null){
		return false;
	}

	if(q == null){
		return false;
	}

	if(p.val != q.val){
		return false;
	}

	var left = IsSameTree(p.left, q.left);
	var right = IsSameTree(p.right, q.right);

	return left && right;
}