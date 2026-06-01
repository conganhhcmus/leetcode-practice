/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    public TreeNode SortedListToBST(ListNode head)
    {
        List<int> arr = [];
        while (head != null)
        {
            arr.Add(head.val);
            head = head.next;
        }

        return Build(arr, 0, arr.Count - 1);
    }

    TreeNode Build(List<int> arr, int st, int ed)
    {
        if (st > ed) return null;
        if (st == ed) return new TreeNode(arr[st]);

        int mid = st + (ed - st) / 2;
        TreeNode root = new TreeNode(arr[mid]);
        root.left = Build(arr, st, mid - 1);
        root.right = Build(arr, mid + 1, ed);
        return root;
    }
}
