/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        int n = nums.Length;
        if (n == 0) return null;
        if (n == 1) return new TreeNode(nums[0]);
        int mid = n / 2;
        TreeNode root = new(nums[mid]);
        root.left = SortedArrayToBST(nums[..mid]); ;
        root.right = SortedArrayToBST(nums[(mid + 1)..]);
        return root;
    }
}