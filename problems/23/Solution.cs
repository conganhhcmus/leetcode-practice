#if DEBUG
namespace Problems_23;
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
        ListNode ans = new ListNode(0);
        ListNode tail = ans;
        ListNode minNode = FindMinNodeAndRemove(lists);
        while (minNode != null)
        {
            tail.next = minNode;
            tail = tail.next;
            minNode = FindMinNodeAndRemove(lists);
        }
        tail.next = minNode;
        return ans.next;
    }

    private ListNode FindMinNodeAndRemove(ListNode[] lists)
    {
        int minIndex = -1;
        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] == null) continue;
            if (minIndex == -1 || lists[i].val < lists[minIndex].val)
            {
                minIndex = i;
            }
        }
        if (minIndex == -1) return null;
        ListNode minNode = lists[minIndex];
        lists[minIndex] = lists[minIndex].next;
        return minNode;
    }
}