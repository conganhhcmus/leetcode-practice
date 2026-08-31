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
        ListNode curr = head.next;
        int prev = head.val;
        int firstCp = -1, prevCp = -1;
        int idx = 1;
        int min = 100_000;

        while (curr != null && curr.next != null)
        {
            if (IsCritical(prev, curr.val, curr.next.val))
            {
                if (firstCp == -1)
                {
                    firstCp = idx;
                    prevCp = idx;
                }
                else
                {
                    if (idx - prevCp < min) min = idx - prevCp;
                    prevCp = idx;
                }
            }
            idx++;
            prev = curr.val;
            curr = curr.next;
        }

        if (firstCp == prevCp) return [-1, -1];
        return [min, prevCp - firstCp];

        bool IsCritical(int prev, int curr, int next)
        {
            return (prev < curr && curr > next) || (prev > curr && curr < next);
        }
    }
}