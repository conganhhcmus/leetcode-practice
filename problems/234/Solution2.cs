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
    public bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null) return true;
        ListNode slow = head;
        ListNode fast = head;
        ListNode prev = head;

        bool odd = false;

        while (slow != null && fast != null)
        {
            prev = slow;
            slow = slow.next;
            if (fast.next == null)
            {
                odd = true;
                break;
            }
            fast = fast.next?.next;
        }

        prev.next = null;
        if (!odd) prev = null;

        while (slow != null)
        {
            ListNode next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }

        while (head != prev)
        {
            if (head.val != prev.val) return false;
            head = head.next;
            prev = prev.next;
        }
        return true;
    }
}