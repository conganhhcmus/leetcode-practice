#if DEBUG
namespace Problems_108_2;
#endif

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
        int l = 0, r = nums.Length - 1;
        return BuildTree(nums, l, r);
    }

    TreeNode BuildTree(int[] nums, int l, int r)
    {
        if (l > r) return null;
        int mid = l + (r - l) / 2;
        TreeNode root = new(nums[mid]);
        root.left = BuildTree(nums, l, mid - 1);
        root.right = BuildTree(nums, mid + 1, r);
        return root;
    }
}