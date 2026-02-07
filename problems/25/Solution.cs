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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (k == 1) return head;
        int len = 0;
        ListNode dummy = head;
        while (dummy is not null)
        {
            dummy = dummy.next;
            len++;
        }

        ListNode prev = null, curr = head;
        ListNode lastPrev = prev, lastCurr = curr;
        for (int i = 0; i < (len / k); i++)
        {
            for (int j = 0; j < k; j++)
            {
                ListNode temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            if (lastPrev is not null)
            {
                ListNode temp = lastPrev.next;
                lastPrev.next = prev;
                lastPrev = temp;
            }
            else
            {
                lastPrev = head;
                head = prev;
            }
            lastCurr.next = curr;
            lastCurr = curr;
        }

        return head;
    }
}