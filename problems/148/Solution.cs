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
        if (head == null) return head;
        ListNode p1 = head;
        int len = 0;
        while (p1 != null)
        {
            len++;
            p1 = p1.next;
        }
        return MergeSort(head, 0, len - 1);
    }

    ListNode Merge(ListNode p1, ListNode p2)
    {
        ListNode dummy = new(0);
        ListNode p = dummy;
        while (p1 != null && p2 != null)
        {
            if (p1.val < p2.val)
            {
                p.next = p1;
                p1 = p1.next;
            }
            else
            {
                p.next = p2;
                p2 = p2.next;
            }
            p = p.next;
        }
        p.next = p1 ?? p2;
        return dummy.next;
    }

    ListNode MergeSort(ListNode head, int l, int r)
    {
        if (l < r)
        {
            int mid = l + (r - l) / 2;
            ListNode tmp = head;
            for (int i = l; i <= mid; i++) tmp = tmp.next;
            ListNode p1 = MergeSort(head, l, mid);
            ListNode p2 = MergeSort(tmp, mid + 1, r);
            return Merge(p1, p2);
        }
        head.next = null;
        return head;
    }
}