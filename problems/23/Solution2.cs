#if DEBUG
namespace Problems_23_2;
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
    public ListNode MergeKLists(ListNode[] lists)
    {
        return Merge(lists, 0, lists.Length - 1);
    }

    private ListNode Merge(ListNode[] lists, int l, int r)
    {
        if (l > r) return null;
        if (l == r) return lists[r];
        int m = l + (r - l) / 2;
        ListNode left = Merge(lists, l, m);
        ListNode right = Merge(lists, m + 1, r);
        return MergeTwoLists(left, right);
    }

    private ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        if (l1.val < l2.val)
        {
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }
}