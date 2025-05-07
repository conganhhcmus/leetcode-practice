#if DEBUG
namespace Problems_147;
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
    public ListNode InsertionSortList(ListNode head)
    {
        ListNode dummy = new(0, head);
        ListNode curr = dummy.next;
        while (curr != null)
        {
            // find position
            ListNode p1 = dummy;
            ListNode p2 = dummy.next;

            while (p2 != null && p2.val < curr.val)
            {
                p1 = p2;
                p2 = p2.next;
            }

            ListNode prev = p2;
            while (p2 != curr)
            {
                prev = p2;
                p2 = p2.next;
            }
            // insert
            if (prev != curr)
            {
                prev.next = curr.next;
                curr.next = p1.next;
                p1.next = curr;
            }

            curr = prev.next;
        }

        return dummy.next;
    }
}