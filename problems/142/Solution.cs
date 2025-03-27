#if DEBUG
namespace Problems_142;
#endif

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        while (slow != null && fast != null)
        {
            slow = slow.next;
            fast = fast.next?.next;
            if (slow == fast) break;
        }

        // slow = X + k
        // fast = 2X + 2k
        // fast = 2X + 2k = X + k + nC
        // X + k = nC => k = nC - X
        // slow + X = X + k + X = X + nC - X + X = X + nC

        if (slow == null || fast == null) return null;
        ListNode ret = head;
        while (ret != slow)
        {
            ret = ret.next;
            slow = slow.next;
        }
        return ret;
    }
}