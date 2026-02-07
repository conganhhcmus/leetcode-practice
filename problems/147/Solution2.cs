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
        if (head == null || head.next == null) return head;
        ListNode prev = head;
        ListNode curr = head.next;
        while (curr != null)
        {
            if (curr.val < prev.val)
            {
                prev.next = curr.next;

                ListNode nodePrev = null;
                ListNode nodeNext = head;
                while (nodeNext != null && curr.val > nodeNext.val)
                {
                    nodePrev = nodeNext;
                    nodeNext = nodeNext.next;
                }

                if (nodePrev == null)
                {
                    curr.next = head;
                    head = curr;
                }
                else
                {
                    nodePrev.next = curr;
                    curr.next = nodeNext;
                }
                curr = prev.next;
            }
            else
            {
                prev = curr;
                curr = curr.next;
            }
        }
        return head;
    }
}