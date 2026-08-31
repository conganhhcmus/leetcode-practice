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
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        ListNode next = head.next;
        int idx = 0;
        List<int> arr = [];
        while (curr != null && next != null)
        {
            if (prev != null)
            {
                if (curr.val < prev.val && curr.val < next.val) arr.Add(idx);
                if (curr.val > prev.val && curr.val > next.val) arr.Add(idx);
            }
            idx++;
            prev = curr;
            curr = next;
            next = curr.next;
        }
        if (arr.Count < 2) return [-1, -1];
        int max = arr[^1] - arr[0];
        int min = int.MaxValue;
        for (int i = 1; i < arr.Count; i++)
        {
            if (min > arr[i] - arr[i - 1]) min = arr[i] - arr[i - 1];
        }
        return [min, max];
    }
}