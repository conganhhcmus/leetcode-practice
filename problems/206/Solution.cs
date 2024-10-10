namespace Problem_206;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class Solution
{
    public static void Execute()
    {
        int[] nums = [1, 2, 3, 4, 5];

        ListNode head = null;
        if (nums.Length > 0) head = new ListNode(nums[0]);
        var tmp = head;
        for (int i = 1; i < nums.Length; i++)
        {
            tmp.next = new ListNode(nums[i]);
            tmp = tmp.next;
        }
        var solution = new Solution();
        var resHead = solution.ReverseList(head);

        List<int> ans = [];
        while (resHead is not null)
        {
            ans.Add(resHead.val);
            resHead = resHead.next;
        }

        Console.WriteLine($"[{string.Join(",", ans)}]");
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