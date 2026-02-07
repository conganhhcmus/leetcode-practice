public class Solution
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root is null) return null;
        if (root.val > key)
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (root.val < key)
        {
            root.right = DeleteNode(root.right, key);
        }
        else
        {
            if (root.left is null)
            {
                return root.right;
            }

            if (root.right is null)
            {
                return root.left;
            }

            TreeNode curr = root.right;
            while (curr.left is not null)
            {
                curr = curr.left;
            }
            root.val = curr.val;
            root.right = DeleteNode(root.right, curr.val);
        }
        return root;
    }
}