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
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode root = head;
        ListNode prev = null;
        while (head != null)
        {
            if (prev != null && head.val == prev.val)
            {
                prev.next = head.next;
            }
            else
            {
                prev = head;
            }
            head = head.next;
        }
        return root;
    }
}