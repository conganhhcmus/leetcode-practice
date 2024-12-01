namespace Helpers;

using Structures;

public static class ListNodeHelper
{
    public static ListNode CreateListFromArray(int[] nums)
    {
        ListNode dummy = new();
        ListNode current = dummy;

        foreach (var num in nums)
        {
            current.next = new ListNode(num);
            current = current.next;
        }

        return dummy.next;
    }

    public static void PrintList(ListNode head)
    {
        List<int> vals = [];
        while (head is not null)
        {
            vals.Add(head.val);
            head = head.next;
        }

        Console.WriteLine($"[{string.Join(",", vals)}]");
    }
}