namespace Practice_2;
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode SetNext(ListNode node)
    {
        this.next = node;
        return node;
    }
}
public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        var l1 = new ListNode(1);
        l1
            .SetNext(new ListNode(8));

        var l2 = new ListNode(0);
        // l2
        //     .SetNext(new ListNode(9))
        //     .SetNext(new ListNode(9))
        //     .SetNext(new ListNode(9));

        var res = solution.AddTwoNumbers(l1, l2);
        var str = "";
        while (res != null)
        {
            str += $"{res.val}";
            res = res.next;
            if (res != null) str += ",";
        }
        Console.WriteLine($"[{str}]");
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