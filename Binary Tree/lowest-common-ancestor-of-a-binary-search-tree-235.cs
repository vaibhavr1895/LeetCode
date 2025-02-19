// O(logn) time complexity
// O(1) space complexity
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
	TreeNode node = root;

	TreeNode lca = root;
	while(node != null){
			if(p.val > node.val && q.val > node.val){
			node = node.right;
		}else if(p.val < node.val && q.val < node.val){
			node = node.left;
		}else{
			lca = node;
			break;
		}
	}
	return lca;
}