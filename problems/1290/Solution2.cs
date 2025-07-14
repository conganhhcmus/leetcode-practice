#if DEBUG
namespace Problems_1290_2;
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
        int ret = 0;
        while (head != null)
        {
            ret = ret * 2 + head.val;
            head = head.next;
        }
        return ret;
    }
}