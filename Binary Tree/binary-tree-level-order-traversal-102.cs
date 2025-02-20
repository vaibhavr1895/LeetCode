// O(n) time complexity
// O(n) space complexity

public IList<IList<int>> LevelOrder(TreeNode root) {
	
	if(root == null){
		return new List<IList<int>>();
	}

	Queue<TreeNode> q1 = new Queue<TreeNode>();
	q.Enqueue(root);
	
	IList<IList<int>> res = new List<IList<int>>();
	while(q.Count() > 0){
		Queue<TreeNode> q2 = new Queue<TreeNode>();
		List<int> l = new List<int>();
		while(q.Count() > 0){
			var node = q1.Dequeue();
			l.Add(node.val);
			if(node.left != null){
				q2.Enqueue(node.left);
			}
			if(node.right != null){
				q2.Enqueue(node.right);
			}
		}
		if(l.Count() > 0){ 
			res.Add(l);
		}
		q1 = q2;
	}
	return res;
}