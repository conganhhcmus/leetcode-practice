namespace Helpers;

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

    public static string PrintList(ListNode head)
    {
        List<int> vals = [];
        while (head is not null)
        {
            vals.Add(head.val);
            head = head.next;
        }

        return JsonConvert.SerializeObject(vals);
    }
}