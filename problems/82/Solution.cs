#if DEBUG
namespace Problems_82;
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
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode curr = head;
        ListNode ans = new(0), tailAns = ans;
        while (curr != null)
        {
            int count = 0;
            while (curr.next != null && curr.val == curr.next.val)
            {
                count++;
                curr = curr.next;
            }
            if (count == 0)
            {
                tailAns.next = curr;
                tailAns = tailAns.next;
            }
            curr = curr.next;
        }

        tailAns.next = null;

        return ans.next;
    }
}