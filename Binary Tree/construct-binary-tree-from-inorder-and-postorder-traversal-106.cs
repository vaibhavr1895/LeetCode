public TreeNode BuildTree(int[] inorder, int[] postorder)
{
    TreeNode BuildTree2(int leftStart, int leftEnd, int rightStart, int rightEnd)
    {
        if (leftStart > leftEnd)
        {
            return null;
        }

        if (rightStart > rightEnd)
        {
            return null;
        }

        var treeNode = new TreeNode(postorder[rightEnd]);

        int inOrderIndex = leftEnd;
        while (inorder[inOrderIndex] != postorder[rightEnd])
        {
            inOrderIndex--;
        }

        int postOrderIndex = rightStart;
        for (int i = 0; i < inOrderIndex - leftStart; i++)
        {
            postOrderIndex++;
        }

        treeNode.left = BuildTree2(leftStart, inOrderIndex - 1, rightStart, postOrderIndex - 1);
        treeNode.right = BuildTree2(inOrderIndex + 1, leftEnd, postOrderIndex, rightEnd - 1);

        return treeNode;
    }

    return BuildTree2(0, inorder.Length - 1, 0, postorder.Length - 1);
}