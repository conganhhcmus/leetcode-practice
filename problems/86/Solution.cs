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
    public ListNode Partition(ListNode head, int x)
    {
        ListNode before = new(0), after = new(0);
        ListNode curr1 = before, curr2 = after;

        while (head != null)
        {
            if (head.val < x)
            {
                curr1.next = head;
                curr1 = curr1.next;
            }
            else
            {
                curr2.next = head;
                curr2 = curr2.next;
            }
            head = head.next;
        }

        curr2.next = null;
        curr1.next = after.next;

        return before.next;
    }
}