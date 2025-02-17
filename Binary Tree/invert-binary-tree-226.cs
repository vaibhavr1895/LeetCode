// O(n) time complexity
// O(n) space complexity
public TreeNode InvertTree(TreeNode root) {
	if(root == null){
		return null;
	}
	Queue<TreeNode> q = new Queue<TreeNode>();
	q.Enqueue(root);
	while(q.Count() > 0){
		var node = q.Dequeue();
		if(node.left != null){
			q.Enqueue(node.left);
		}
		if(node.right != null){
			q.Enqueue(node.right);
		}

		var temp = node.left;
		node.left = node.right;
		node.right = temp;
	}
	return root;
}