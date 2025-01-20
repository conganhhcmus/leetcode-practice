#if DEBUG
namespace Problems_92;
#endif

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
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (left == right) return head;
        int idx = 1;
        ListNode prev = null, curr = head;
        while (idx < left)
        {
            prev = curr;
            curr = curr.next;
            idx++;
        }

        ListNode lastPrev = prev;
        ListNode lastCurr = curr;

        while (idx <= right)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
            idx++;
        }

        if (lastPrev != null)
        {
            lastPrev.next = prev;
        }
        else
        {
            head = prev;
        }

        lastCurr.next = curr;
        return head;
    }
}