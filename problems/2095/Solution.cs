public class Solution
{
    public ListNode DeleteMiddle(ListNode head)
    {
        if (head is null || head.next is null) return null;

        int n = 0;
        var tmp = head;

        while (tmp is not null)
        {
            n++;
            tmp = tmp.next;
        }

        n /= 2;
        tmp = head;
        while (--n > 0)
        {
            tmp = tmp.next;
        }
        tmp.next = tmp.next.next;
        return head;
    }
}