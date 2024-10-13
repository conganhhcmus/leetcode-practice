namespace Problem_2;

using Helpers.ListNode;

public class Solution
{
    public static void Execute()
    {
        var l1 = ListNodeHelper.CreateListFromArray([1, 8]);
        var l2 = ListNodeHelper.CreateListFromArray([0]);

        var solution = new Solution();
        var res = solution.AddTwoNumbers(l1, l2);

        ListNodeHelper.PrintList(res);
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var carry = 0;
        ListNode tmp = new(0);
        var res = tmp;
        while (l1 != null || l2 != null || carry != 0)
        {
            var digit1 = l1 == null ? 0 : l1.val;
            var digit2 = l2 == null ? 0 : l2.val;
            var sum = digit1 + digit2 + carry;
            carry = sum / 10;
            tmp.next = new ListNode(sum % 10);
            tmp = tmp.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        return res.next;
    }
}