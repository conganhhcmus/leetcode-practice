#if DEBUG
namespace Problems_141;
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
    public bool HasCycle(ListNode head)
    {
        ListNode slow = head, fast = head;
        while (slow != null && fast != null)
        {
            slow = slow.next;
            fast = fast.next?.next;
            if (slow == fast && fast != null) return true;
        }
        return false;
    }
}