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
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode dummy = new(0, head);
        int size = 1;
        int length = Count(head);
        while (size < length)
        {
            ListNode prev = dummy;
            ListNode curr = dummy.next;
            while (curr != null)
            {
                ListNode left = curr;
                ListNode right = Split(left, size);
                curr = Split(right, size);
                prev = Merge(left, right, prev);
            }
            size *= 2;
        }
        return dummy.next;
    }

    int Count(ListNode head)
    {
        int count = 0;
        while (head != null)
        {
            count++;
            head = head.next;
        }
        return count;
    }

    ListNode Split(ListNode head, int size)
    {
        if (head == null) return null;
        for (int i = 1; head.next != null && i < size; i++)
        {
            head = head.next;
        }

        ListNode next = head.next;
        head.next = null;
        return next;
    }

    ListNode Merge(ListNode p1, ListNode p2, ListNode into)
    {
        ListNode ans = into;
        while (p1 != null && p2 != null)
        {
            if (p1.val < p2.val)
            {
                into.next = p1;
                p1 = p1.next;
            }
            else
            {
                into.next = p2;
                p2 = p2.next;
            }
            into = into.next;
        }

        into.next = p1 ?? p2;
        while (ans.next != null) ans = ans.next;
        return ans;
    }
}