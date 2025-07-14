#if DEBUG
namespace Problems_1290;
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
    public int GetDecimalValue(ListNode head)
    {
        ListNode dummy = head;
        int len = 0;
        while (dummy != null)
        {
            len++;
            dummy = dummy.next;
        }
        int ret = 0;
        while (head != null)
        {
            len--;
            ret += head.val << (len);
            head = head.next;
        }
        return ret;
    }
}