// O(logn) time complexity
// O(1) space complexity
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
	while(root != null){
			if(p.val > root.val && q.val > root.val){
			root = root.right;
		}else if(p.val < root.val && q.val < root.val){
			root = root.left;
		}else{
			return root;
		}
	}
	return root;
}