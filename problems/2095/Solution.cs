namespace Problem_2095;

using Helpers;
using Structures;

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

    public static void Execute()
    {
        var head = ListNodeHelper.CreateListFromArray([1, 3, 4, 7, 1, 2, 6]);
        var solution = new Solution();
        var resHead = solution.DeleteMiddle(head);
        ListNodeHelper.PrintList(resHead);
    }
}