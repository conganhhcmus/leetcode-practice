namespace Problem_328;

using Helpers.ListNode;

public class Solution
{
    public ListNode OddEvenList(ListNode head)
    {
        if (head is null || head.next is null) return head;

        ListNode oddHead = head;
        ListNode evenHead = head.next;
        ListNode tmp = evenHead;

        while (oddHead.next is not null && evenHead.next is not null)
        {
            oddHead.next = evenHead.next;
            oddHead = evenHead.next;

            evenHead.next = oddHead.next;
            evenHead = oddHead.next;
        }

        oddHead.next = tmp;
        return head;
    }

    public static void Execute()
    {
        var head = ListNodeHelper.CreateListFromArray([1, 2, 3, 4, 5, 6, 7, 8]);

        var solution = new Solution();
        var resHead = solution.OddEvenList(head);
        ListNodeHelper.PrintList(resHead);
    }
}