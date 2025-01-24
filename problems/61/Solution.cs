#if DEBUG
namespace Problems_61;
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
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0) return head;
        ListNode dummy = head, tail = null;
        int len = 0;
        while (dummy != null)
        {
            len++;
            tail = dummy;
            dummy = dummy.next;
        }

        k %= len;
        if (k == 0) return head;
        dummy = head;
        for (int i = 0; i < len - k - 1; i++)
        {
            dummy = dummy.next;
        }

        tail.next = head;
        head = dummy.next;
        dummy.next = null;
        return head;
    }
}