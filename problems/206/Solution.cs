namespace Problem_206;

using Helpers;
using Structures;

public class Solution
{
    public static void Execute()
    {
        var head = ListNodeHelper.CreateListFromArray([1, 2, 3, 4, 5]);
        var solution = new Solution();
        var resHead = solution.ReverseList(head);

        ListNodeHelper.PrintList(resHead);
    }
    public ListNode ReverseList(ListNode head)
    {
        if (head is null || head.next is null) return head;

        var cloneHead = head;
        ListNode resHead = head;
        ListNode prevNode = null;

        while (cloneHead.next is not null)
        {
            resHead = cloneHead;
            cloneHead = cloneHead.next;

            resHead.next = prevNode;
            prevNode = resHead;
            resHead = cloneHead;
        }

        resHead.next = prevNode;

        return resHead;
    }
}