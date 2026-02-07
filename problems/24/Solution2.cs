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
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode dummy = new(0, head);
        ListNode current = dummy;
        while (current.next != null && current.next.next != null)
        {
            ListNode first = current.next;
            ListNode second = first.next;

            // swap
            first.next = second.next;
            current.next = second;
            second.next = first;

            // next
            current = current.next.next;
        }

        return dummy.next;
    }
}