#if DEBUG
namespace Problems_160;
#endif

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        int n1 = 0, n2 = 0;
        ListNode dummy = headA;
        while (dummy != null)
        {
            n1++;
            dummy = dummy.next;
        }

        dummy = headB;
        while (dummy != null)
        {
            n2++;
            dummy = dummy.next;
        }
        int diff = n1 - n2;
        if (diff > 0)
        {
            while (diff-- > 0)
            {
                headA = headA.next;
            }
        }
        else
        {
            while (diff++ < 0)
            {
                headB = headB.next;
            }
        }

        while (headA != null && headB != null)
        {
            if (headA == headB) return headA;
            headA = headA.next;
            headB = headB.next;
        }
        return null;
    }
}