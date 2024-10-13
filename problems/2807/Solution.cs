namespace Problem_2807;

using Helpers.ListNode;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        var head = ListNodeHelper.CreateListFromArray([18, 6, 10, 3]);
        var res = solution.InsertGreatestCommonDivisors(head.next);
        ListNodeHelper.PrintList(res);
    }

    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var res = head;
        var prvHead = head;
        head = head.next;

        while (head is not null)
        {
            int gdc = GDC(prvHead.val, head.val);
            prvHead.next = new ListNode(gdc, head);

            prvHead = head;
            head = head.next;
        }

        return res;
    }

    private int GDC(int a, int b)
    {
        if (b == 0) return a;

        return GDC(b, a % b);
    }
}